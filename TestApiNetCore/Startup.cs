using ApiInfraestructure.Data.Contexts;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net;
using System.Reflection;
using System.Text;
using FaxiApiNetCore.Configurations;
using FaxiApiNetCore.Mappings;
using ApiApiNetCore.WebSocketManager;
using ApiApiNetCore.Socket;

namespace FaxiApiNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JWTTokenGenerator.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var presentationAssembly = Assembly.GetExecutingAssembly();
            var coreAssembly = Assembly.Load(nameof(ApiDomain));
            var infraestructureAssembly = Assembly.Load(nameof(ApiInfraestructure));

            services.AddCors();
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddWebSocketManager();
            services.AddAuthentication((configuration) =>
            {
                configuration.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                configuration.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                configuration.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.GetSection("ISSUER").Value,
                    ValidAudience = Configuration.GetSection("AUDIENCE").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AUDIENCE_KEY").Value))
                };
            });

            services.Configure<IdentityOptions>(o =>
            {
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(120);
                o.Lockout.MaxFailedAccessAttempts = 5;
                o.Lockout.AllowedForNewUsers = true;
            });
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("10.10.1.3"));
            });
            services.AddAutofac();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyTypes(
                presentationAssembly,
                coreAssembly,
                infraestructureAssembly
                ).AsImplementedInterfaces();

            var csName = "quality_assurance";
#if DEBUG
            csName = "development";
#endif

            var optionsBuilder = new DbContextOptionsBuilder<PostgresDbContext>();
            builder.RegisterType<PostgresDbContext>()
                .WithParameter("options", optionsBuilder.UseNpgsql(Configuration.GetConnectionString(csName)).Options)
                .SingleInstance();

            builder.Register(c => new MapperConfiguration(x => x.AddMaps(presentationAssembly)))
                .AsSelf().SingleInstance();

            return new AutofacServiceProvider(builder.Build());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseAuthentication();
            app.UseWebSockets();
            app.MapWebSocketManager("/wsMessage", serviceProvider.GetService<ChatHandler>());
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseMvc();
        }
    }
}
