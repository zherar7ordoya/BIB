using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Experimental
{
    public interface IEntidad
    {
         int Codigo { get; set; }
    }

    public class Entidad: IEntidad
    {
        [XmlAttribute("Codigo")]
        public int Codigo { get; set; } = new int();
    }

    [XmlInclude(typeof(Empleado))]
    [XmlInclude(typeof(Chofer))]
    [XmlInclude(typeof(Estibador))]
    public abstract class Persona : Entidad
    {
        public DateTime FechaAlta { get; set; } = new DateTime();
        public string Puesto { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class Empleado : Persona
    {
        public int DNI { get; set; } = new int();
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Intento { get; set; } = new int();
    }

    public class Chofer : Empleado
    {

    }

    public class Estibador : Empleado
    {

    }

    public class Insumo
    {
        public int Cantidad { get; set; } = new int();
        public string Descripcion { get; set; } = string.Empty;
    }

    public class Mudanza : Entidad
    {
        public DateTime Fecha { get; set; } = new DateTime();
        public Camion Camion { get; set; } = new Camion();
        public Chofer Chofer { get; set; } = new Chofer();
        public List<Estibador> Estibadores { get; set; } = new List<Estibador>();
        public List<Insumo> Insumos { get; set; } = new List<Insumo>();
        public int OrdenID { get; set; } = new int();
    }

    public class Camion : Entidad
    {
        public string Patente { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
    }
}
