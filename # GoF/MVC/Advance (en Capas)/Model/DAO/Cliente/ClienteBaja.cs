namespace Model
{
    internal class ClienteBaja : ConexionMySql
    {
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
    }
}
