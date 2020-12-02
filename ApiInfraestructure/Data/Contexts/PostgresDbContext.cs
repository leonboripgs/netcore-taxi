using ApiDomain.Entities;
using ApiInfraestructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiInfraestructure.Data.Contexts
{
    public class PostgresDbContext : DbContext
    {
        #region Attributes
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<CodigoValidacion> CodigosValidacion { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<TipoCuenta> TiposCuenta { get; set; }
        public DbSet<CuentaUsuario> CuentasUsuario { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<VehiculoPosicion> VehiculoPosicion { get; set; }
        public DbSet<EstatusViaje> EstatusViajes { get; set; }
        public DbSet<MotivoCancelacion> MotivosCancelacion { get; set; }
        public DbSet<CancelacionViaje> CancelacionesViajes { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<ViajeConductor> ViajesConductores { get; set; }
        public DbSet<ViajeUsuario> ViajesUsuarios { get; set; }
        #endregion
        #region Constructor
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {
        }

        #endregion

        #region Methods
        public override int SaveChanges()
        {

            int result;
            result = base.SaveChanges();
            foreach (var dbEntityEntry in ChangeTracker.Entries().ToArray())
                if (dbEntityEntry.Entity != null)
                    try
                    {
                        dbEntityEntry.State = EntityState.Detached;
                    }
                    catch
                    {
                        continue;
                    }

            return result;
        }
        /// <summary>
        /// Contruye los modelos usados por el contexto de base de datos
        /// </summary>
        /// <param name="builder">Contructor de modelos</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PaisEntityConfiguration());
            builder.ApplyConfiguration(new EntidadEntityConfiguration());
            builder.ApplyConfiguration(new MunicipioEntityConfiguration());
            builder.ApplyConfiguration(new CodigoValidacionEntityConfiguration());
            builder.ApplyConfiguration(new UsuarioEntityConfiguration());
            builder.ApplyConfiguration(new CuentaUsuarioEntityConfiguration());
            builder.ApplyConfiguration(new TipoCuentaEntityConfiguration());
            builder.ApplyConfiguration(new ImagenEntityConfiguration());
            builder.ApplyConfiguration(new DocumentoEntityConfiguration());
            builder.ApplyConfiguration(new TipoDocumentoEntityConfiguration());
            builder.ApplyConfiguration(new MarcaEntityConfiguration());
            builder.ApplyConfiguration(new ModeloEntityConfiguration());
            builder.ApplyConfiguration(new VehiculoEntityConfiguration());
            builder.ApplyConfiguration(new VehiculoPosicionEntityConfiguration());
            builder.ApplyConfiguration(new MotivoCancelacionEntityConfiguration());
            builder.ApplyConfiguration(new ViajeConductorEntityConfiguration());
            builder.ApplyConfiguration(new ViajeUsuarioEntityConfiguration());
            builder.ApplyConfiguration(new ViajeEntityConfiguration());
            builder.ApplyConfiguration(new EstatusViajeEntityConfiguration());
            builder.ApplyConfiguration(new CancelacionViajeEntityConfiguration());
        }
        #endregion
    }
}
