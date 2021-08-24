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

        public static string GenerarToken(int id, string referencia)
        {
            // Define const Key this should be private secret key  stored in some safe place
            //string key = "4b7a0812e1081c39b740293f765eae731f5a65ed1";

            // Create Security key  using private key above:
            // not that latest version of JWT using Microsoft namespace instead of System
            var securityKey = new Microsoft
                .IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            //
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256Signature);

            //  Finally create a Token
            var header = new JwtHeader(credentials);

            //Some PayLoad that contain information about the  customer
            var datosReferencia = new JwtPayload
           {
               {"id", id},
               {"referencia", referencia}
           };

            //
            var secToken = new JwtSecurityToken(header, datosReferencia);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            var tokenString = handler.WriteToken(secToken);

            // And finally when  you received token from client
            // you can  either validate it or try to  read
            var token = handler.ReadJwtToken(tokenString);

            //Console.WriteLine(token.Payload.First().Value);
            return tokenString;
        }


        public void ObtenerDatos(ref FichaReferenciadaSIAE objDatos, string cadena, ref string Verificador)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(cadena);
            objDatos.IdReferencia = Convert.ToInt32(token.Payload.First().Value);
            CD_FichaReferenciada_SIAE CDRefSIAE = new CD_FichaReferenciada_SIAE();
            CDRefSIAE.ConsultarFichaReferenciada(ref objDatos, ref Verificador);
        }

        public void ObtenerDatosSYSWEB(ref FichaReferenciada objDatos, string cadena, ref string Verificador)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(cadena);
            objDatos.IdFichaBancaria = Convert.ToInt32(token.Payload.First().Value);
            CD_FichaReferenciada CDRefSIAE = new CD_FichaReferenciada();
            CDRefSIAE.ConsultarFichaReferenciadaSYSWEB(ref objDatos, ref Verificador);
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
