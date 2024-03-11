using Abstract;
using System;


namespace Structure
{
    public class TelefonoModelo : IId, ICloneable
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Numero { get; set; }
        public bool Activo { get; set; }


        // Constructores
        public TelefonoModelo() { }

        /// <summary>
        /// Este constructor es el que se usa en las operaciones de baja
        /// </summary>
        /// <param name="id">Id del teléfono</param>
        public TelefonoModelo(int id) { Id = id; }

        /// <summary>
        /// Este constructor es el que se usa en las operaciones de alta y de
        /// modificación.
        /// (Se incluye el Id en las operaciones de alta por lo expuesto en las
        /// notas hechas en el ORM)
        /// </summary>
        /// <param name="id">Id del teléfono</param>
        /// <param name="clienteId">Id del cliente</param>
        /// <param name="numero">Número de teléfono</param>
        /// <param name="activo">Borrado lógico</param>
        public TelefonoModelo(
            int id,
            int clienteId,
            string numero,
            bool activo)
        {
            Id = id;
            ClienteId = clienteId;
            Numero = numero;
            Activo = activo;
        }


        // Implementaciones
        public int RetornaId() { return Id; }
        public object Clone() { return MemberwiseClone(); }
    }
}
