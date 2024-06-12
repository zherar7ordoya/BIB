using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePersistente.DAL
{
    public static class Tool
    {
        /// <summary>
        /// Agrega los parámetros al comando SQL.
        /// </summary>
        /// <param name="comando">El comando SQLite al cual agregar los parámetros.</param>
        /// <param name="parametros">Lista de parámetros SQL a incluir en el comando.</param>
        public static void AgregarParametros(SQLiteCommand comando, List<SQLiteParameter> parametros)
        {
            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    comando.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
                }
            }
        }
    }
}
