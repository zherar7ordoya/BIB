using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Paso5
{
    public class RolORM 
    {
        //readonly string archivo = $"Archivos/Roles.xml";
        readonly string archivo = $"Roles.xml";
        readonly XmlDAL xmlDAL;
        public RolORM()
        {
            xmlDAL = new XmlDAL(archivo);
        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| MÉTODOS

        public XElement Consultar()
        {
            return xmlDAL.LeerArchivoXML();
        }

        public void Modificar(XElement pObject)
        {
            xmlDAL.EscribirArchivoXML(pObject);
        }
    }
}
