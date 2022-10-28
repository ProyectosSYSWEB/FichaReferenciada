using CapaDatos;
using CapaEntidad;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_PayPal
    {

        public string secretkey = "ECC4E54DBA738857B84A7EBC6B5DC7187B8DA68750E88AB53AAA41F548D6F2SYSW3B";

        public string GenerarTokenPayPal(InfPayPal objDatosRef)
        {
            string jwtToken = string.Empty;
            try
            {
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                jwtToken = encoder.Encode(objDatosRef, secretkey);
                return jwtToken;
            }
            catch
            {
                return "";
            }
        }
        public void ObtenerDatosReferencia(ref InfPayPal objPayPal, ref string Verificador)
        {
            try
            {
                CD_PayPal CDPayPal = new CD_PayPal();
                CDPayPal.ObtenerDatosReferencia(ref objPayPal, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
