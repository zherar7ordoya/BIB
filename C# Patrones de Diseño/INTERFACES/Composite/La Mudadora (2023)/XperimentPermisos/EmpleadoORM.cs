using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Paso5
{
    public class EmpleadoORM : IABMC<Empleado>
    {
        readonly string archivo = $"Empleados.xml";
        readonly XmlDAL xmlDAL;
        public EmpleadoORM() => xmlDAL = new XmlDAL(archivo);

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| MAPEO

        private Empleado MapearDesdeXML(XElement pElement)
        {
            return new Empleado
            {
                Id = int.Parse(pElement.Attribute("Id").Value),
                DNI = int.Parse(pElement.Element("DNI").Value),
                NombreApellido = pElement.Element("NombreApellido").Value,
                FechaAlta = DateTime.Parse(pElement.Element("FechaAlta").Value),
                Puesto = pElement.Element("Puesto").Value,
                Direccion = pElement.Element("Direccion").Value,
                Telefono = pElement.Element("Telefono").Value,
                Email = pElement.Element("Email").Value,
                Username = pElement.Element("Username").Value,
                Password = pElement.Element("Password").Value,
                Intento = int.Parse(pElement.Element("Intento").Value)
            };
        }

        private XElement MapearHaciaXML(Empleado pObject)
        {
            return new XElement("Empleado",
                new XAttribute("Id", pObject.Id),
                new XElement("DNI", pObject.DNI),
                new XElement("NombreApellido", pObject.NombreApellido),
                new XElement("FechaAlta", pObject.FechaAlta.ToString("yyyy-MM-dd")),
                new XElement("Puesto", pObject.Puesto),
                new XElement("Direccion", pObject.Direccion),
                new XElement("Telefono", pObject.Telefono),
                new XElement("Email", pObject.Email),
                new XElement("Username", pObject.Username),
                new XElement("Password", pObject.Password),
                new XElement("Intento", pObject.Intento.ToString())
            );
        }

        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| ABMC

        public void Agregar(Empleado pObject)
        {
            try
            {
                XElement xml = xmlDAL.LeerArchivoXML();
                int maxId = xml.Descendants("Empleado").Max(tarifa => (int)tarifa.Attribute("Id"));
                int newId = maxId + 1;
                pObject.Id = newId;
                XElement agregable = MapearHaciaXML(pObject);
                xml.Add(agregable);
                xmlDAL.EscribirArchivoXML(xml);
            }
            catch (IOException)
            {
                throw new IOException("Error al agregar.");
            }
        }

        public void Eliminar(int pId)
        {
            XElement xml = xmlDAL.LeerArchivoXML();
            XElement eliminable = xml.Elements("Empleado")
                .FirstOrDefault(tarifa => (int)tarifa.Attribute("Id") == pId);

            if (eliminable != null)
            {
                eliminable.Remove();
                xmlDAL.EscribirArchivoXML(xml);
            }
            else
            {
                throw new ArgumentException("Error al eliminar");
            }
        }

        public void Modificar(Empleado pObject)
        {
            XElement xml = xmlDAL.LeerArchivoXML();
            XElement modificable = xml.Elements("Empleado")
                .FirstOrDefault(t => (int)t.Attribute("Id") == pObject.Id);

            if (modificable != null)
            {
                // Actualiza datos escalares
                modificable.Element("DNI").Value = pObject.DNI.ToString();
                modificable.Element("NombreApellido").Value = pObject.NombreApellido;
                modificable.Element("FechaAlta").Value = pObject.FechaAlta.ToString("yyy-MM-dd");
                modificable.Element("Puesto").Value = pObject.Puesto;
                modificable.Element("Direccion").Value = pObject.Direccion;
                modificable.Element("Telefono").Value = pObject.Telefono;
                modificable.Element("Email").Value = pObject.Email;
                modificable.Element("Username").Value = pObject.Username;
                modificable.Element("Password").Value = pObject.Password;
                modificable.Element("Intento").Value = pObject.Intento.ToString();

                xmlDAL.EscribirArchivoXML(xml);
            }
            else
            {
                throw new ArgumentException("Error al modificar.");
            }
        }

        public List<Empleado> Consultar()
        {
            XElement xml = xmlDAL.LeerArchivoXML();
            return xml.Elements("Empleado")
              .Select(x => MapearDesdeXML(x))
              .ToList();
        }
    }
}
