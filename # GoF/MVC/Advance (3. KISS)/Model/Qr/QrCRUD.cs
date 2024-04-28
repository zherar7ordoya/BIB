using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class QrCRUD : ConexionMySql
    {
        public List<Qr> Leer()
        {
            List<Qr> qrs = new List<Qr>();
            using (var conexion = connectionString)
            {
                using (var comando = QrSQL.ReadAll(conexion))
                {
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            qrs.Add(QrMapper.MapearHaciaQr(reader));
                        }
                    }
                }
            }
            return qrs;
        }
    }
}
