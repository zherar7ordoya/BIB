using System.Collections.Generic;

namespace Model
{
    internal class ClienteConsulta : ConexionMySql
    {
        public List<Cliente> ReadAll(string condicion)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (var conexion = connectionString)
            {
                using (var comando = ClienteSQL.ReadAll(condicion, conexion))
                {
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(ClienteMapeador.MapearHaciaCliente(reader));
                        }
                    }
                }
            }
            return clientes;
        }

        public Cliente ReadById(int id)
        {
            Cliente cliente = new Cliente();
            using (var conexion = connectionString)
            {
                using (var comando = ClienteSQL.ReadById(id, conexion))
                {
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = ClienteMapeador.MapearHaciaCliente(reader);
                        }
                    }
                }
            }
            return cliente;
        }
    }
}
