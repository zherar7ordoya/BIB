using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OhYeahForms
{
    // Compuesto
    class Rol : Autorizacion
    {
        [XmlArray("Permisos"), XmlArrayItem(typeof(Autorizacion))]
        readonly List<Autorizacion> _permisos = new List<Autorizacion>();

        public Rol(string nombre)
        {
            Nombre = nombre;
        }

        public void AgregarPermiso(Autorizacion permiso)
        {
            _permisos.Add(permiso);
        }

        public void RemoverPermiso(Autorizacion permiso)
        {
            _permisos.Remove(permiso);
        }

        // En el caso de un Rol, MostrarPermisos llamará recursivamente a
        // MostrarPermisos de cada autorización contenida en él (que puede ser
        // otro Rol o un Permiso).
        public override void MostrarPermisos()
        {
            MessageBox.Show("\nRol: " + Nombre);
            foreach (var permiso in _permisos)
            {
                permiso.MostrarPermisos();
            }
        }

        public override void AsignarEventoClick
            (
            ToolStripMenuItem menuItem,
            Dictionary<string, Type> formMappings,
            List<Form> openForms
            )
        {
            foreach (var permiso in _permisos)
            {
                permiso.AsignarEventoClick(menuItem, formMappings, openForms);
            }
        }

        public void Habilitar
            (
            MenuStrip menuStrip,
            Dictionary<string, Type> formMappings,
            List<Form> openForms
            )
        {
            foreach (var permiso in _permisos)
            {
                if (permiso is Permiso)
                {
                    (permiso as Permiso).Habilitar(menuStrip, formMappings, openForms);
                }
                else if (permiso is Rol)
                {
                    (permiso as Rol).Habilitar(menuStrip, formMappings, openForms);
                }
            }
        }
    }

}
