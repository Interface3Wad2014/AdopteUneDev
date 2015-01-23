using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.WADAL.Helper
{
   public class Tools
    {
        /// <summary>
        /// Hash suivant l'algo SHA1
        /// </summary>
        /// <param name="text">Le texte a asché</param>
        /// <param name="enc">Encodage de requête</param>
        /// <returns>la hash</returns>
        public static string CalculateSha1(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSha1 =
            new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(
                cryptoTransformSha1.ComputeHash(buffer)).Replace("-", "");

            return hash;
        }
    }
}
