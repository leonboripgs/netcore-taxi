using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FaxiApiNetCore.Configurations
{
    /// <summary>
    /// Clase encargada del ciclo de vida de los tokens JWT
    /// </summary>
    public class JWTTokenHandler : DelegatingHandler
    {
        /// <summary>
        /// Obtiene el token de una petición http
        /// </summary>
        /// <param name="request">Petición http</param>
        /// <param name="token">Token de autenticación</param>
        /// <returns>El token de autenticación.</returns>
        private static bool RetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;

            if (!request.Headers.TryGetValues("Authorization", out IEnumerable<string> authorizationHeaders) || authorizationHeaders.Count() > 1)
                return false;

            var bearerToken = authorizationHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        /// <summary>
        /// Valida el token de autorización para una petición http.
        /// </summary>
        /// <param name="request">Petición http</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;

            if (!RetrieveToken(request, out string token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                return base.SendAsync(request, cancellationToken);
            }

            try
            {
                var secretKey = ConfigurationManager.AppSettings["AUDIENCE_KEY"];
                var audienceToken = ConfigurationManager.AppSettings["AUDIENCE"];
                var issuerToken = ConfigurationManager.AppSettings["ISSUER"];
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var validationParams = new TokenValidationParameters(){
                    ValidAudience = audienceToken,
                    ValidIssuer = issuerToken,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = LifetimeValidator,
                    IssuerSigningKey = securityKey,
                };

                Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationParams, out SecurityToken securityToken);
                //RequestContext.Current.User = tokenHandler.ValidateToken(token, validationParams, out securityToken);
                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception )
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });

        }

        /// <summary>
        /// Valida el tiempo de vida de un token
        /// </summary>
        /// <param name="notBefore">Fecha de inicio de validez</param>
        /// <param name="expiration">Fecha final de validez</param>
        /// <param name="securityToken">Token a validar</param>
        /// <param name="validationParameters">Parámetros de validación.</param>
        /// <returns>Verdadero si el token  es válido, Falso en caso contrario</returns>
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expiration, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if(expiration != null)
                return expiration > DateTime.UtcNow;

            return false;
        }
    }
}