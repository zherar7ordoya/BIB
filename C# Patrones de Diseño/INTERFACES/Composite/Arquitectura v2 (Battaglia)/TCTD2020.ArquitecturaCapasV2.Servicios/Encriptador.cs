using System.Security.Cryptography;
using System.Text;

namespace TCTD2020.ArquitecturaCapasV2.Servicios
{
    public static class Encriptador
    {
        public static string Hash(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(value));
            return (new ASCIIEncoding()).GetString(md5data); 
        }
    }
}
