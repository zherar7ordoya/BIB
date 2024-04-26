using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    internal class ClienteConsulta : ConexionMySql
    {
        public List<Cliente> Consultar(string condicion)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (var conexion = connectionString)
            {
                using (var comando = ClienteHelper.CrearComando(condicion, conexion))
                {
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(ClienteHelper.MapearCliente(reader));
                        }
                    }
                }
            }
            return clientes;
        }
    }
}
