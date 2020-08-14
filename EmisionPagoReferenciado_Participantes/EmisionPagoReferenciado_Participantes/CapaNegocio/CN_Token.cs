using CapaDatos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace CapaEntidad
{
    public class CN_Token
    {
        static string key = "4b7a0812e1081c39b740293f765eae731f5a65ed1";
        public bool ValidateToken(string authToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ObtenerDatos(ref FichaReferenciadaSIAE objDatos, string cadena, ref string Verificador)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(cadena);
            objDatos.IdReferencia = Convert.ToInt32(token.Payload.First().Value);
            CD_FichaReferenciada_SIAE CDRefSIAE = new CD_FichaReferenciada_SIAE();
            CDRefSIAE.ConsultarFichaReferenciada(ref objDatos, ref Verificador);
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = "Sample",
                ValidAudience = "Sample",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // The same key as the one that generate the token
            };
        }
    }
}
