using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Experimental
{
    public class Mudanza
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Camion Camion { get; set; }
        public Empleado Chofer { get; set; }
        public List<Empleado> Estibadores { get; set; }
        public List<Insumo> Insumos { get; set; }

        // *** FK (Clave Foránea) ***
        public int OrdenID { get; set; }
    }

    public class Camion
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
    }

    public class Empleado
    {
        public int Id { get; set; }
        public int DNI { get; set; }
        public string NombreApellido { get; set; }
        public DateTime FechaAlta { get; set; }
        /// <summary>
        /// Cajero, Chofer, Estibador, Logístico, Vendedor
        /// </summary>
        public string Puesto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


        // Login
        public string Username { get; set; }
        public string Password { get; set; }
        public int Intento { get; set; }


        
    }

    public class Insumo
    {
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
    }


    [XmlRoot(ElementName = "Mudanzas")]
    public class MudanzaCollection
    {
        [XmlElement(ElementName = "Mudanza")]
        public Mudanza[] MudanzaAsArray { get; set; } = Array.Empty<Mudanza>();

        [XmlIgnore]
        public List<Mudanza> Mudanzas
        {
            get { return MudanzaAsArray.ToList(); }
            set { MudanzaAsArray = value.ToArray(); }
        }
    }


}
