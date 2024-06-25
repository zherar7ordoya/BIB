using System;
using System.Collections.Generic;

namespace Model
{
    internal class ClienteCRUD : ConexionMySql
    {
        public int Create()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            using (var conexion = connectionString)
            {
                using (var comando = ClienteSQL.Delete(id, conexion))
                {
                    conexion.Open();
                    return comando.ExecuteNonQuery();
                }
            }
        }

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
                            clientes.Add(ClienteMapper.MapearHaciaCliente(reader));
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
                            cliente = ClienteMapper.MapearHaciaCliente(reader);
                        }
                    }
                }
            }
            return cliente;
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
