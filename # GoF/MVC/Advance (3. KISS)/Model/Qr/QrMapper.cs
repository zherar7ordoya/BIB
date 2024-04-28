using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class QrMapper
    {
        public static Qr MapearHaciaQr(MySqlDataReader reader)
        {
            return new Qr
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Binario1 = reader.GetString(reader.GetOrdinal("Binario1")),
                Binario2 = reader.GetString(reader.GetOrdinal("Binario2")),
                Binario3 = reader.GetString(reader.GetOrdinal("Binario3")),
                Binario4 = reader.GetString(reader.GetOrdinal("Binario4"))
            };
        }
    }
}
