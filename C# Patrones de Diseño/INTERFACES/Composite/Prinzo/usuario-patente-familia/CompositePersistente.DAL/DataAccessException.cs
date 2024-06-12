using System;

namespace CompositePersistente.DAL
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
