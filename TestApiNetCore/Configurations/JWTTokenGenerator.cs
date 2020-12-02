using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;

namespace FaxiApiNetCore.Configurations
{
    /// <summary>
    /// Clase encargada de la generación de tokens
    /// </summary>
    internal static class JWTTokenGenerator
    {
        public static IConfiguration Configuration { get; set; }
        /// <summary>
        /// Genera un token de autenticación
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <returns>El token generado</returns>
        public static string GenerateToken(string username)
        {
            string jwtToken;
            try
            {
                var timestamp = DateTime.UtcNow;
                var secretKey = Configuration.GetSection("AUDIENCE_KEY").Value; 
                var audienceToken = Configuration.GetSection("AUDIENCE").Value;
                var issuerToken = Configuration.GetSection("ISSUER").Value; 
                var expiration = Configuration.GetSection("TOKEN_EXPIRATION_TIME").Value; 
                var securityKey = new SymmetricSecurityKey(
                    System.Text.Encoding.UTF8.GetBytes(secretKey));
                var signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                    audience: audienceToken,
                    issuer: issuerToken,
                    subject: claimsIdentity,
                    notBefore: timestamp,
                    expires: timestamp.AddMinutes(Convert.ToInt32(expiration)),
                    signingCredentials: signingCredential);
                jwtToken = tokenHandler.WriteToken(jwtSecurityToken);
            }
            catch
            {
                return null;
            }
            return jwtToken;
        }
    }
}