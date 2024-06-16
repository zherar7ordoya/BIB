using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using System;

namespace OhYeahForms
{
    class Rol : Autorizacion
    {
        [XmlArray("Permisos"), XmlArrayItem(typeof(Autorizacion))]
        public List<Autorizacion> Permisos { get; } = new List<Autorizacion>();

        public Rol(string nombre)
        {
            Nombre = nombre;
        }

        public void AgregarPermiso(Autorizacion permiso) => Permisos.Add(permiso);

        public void RemoverPermiso(Autorizacion permiso) => Permisos.Remove(permiso);

        public override void HabilitarPermiso(MenuStrip menuStrip, Dictionary<string, Type> formularios, List<Form> activos)
        {
            foreach (var permiso in Permisos)
            {
                permiso.HabilitarPermiso(menuStrip, formularios, activos);
            }
        }

        public override void AsignarFormulario(ToolStripMenuItem menuItem, Dictionary<string, Type> formularios, List<Form> activos)
        {
            foreach (var permiso in Permisos)
            {
                permiso.AsignarFormulario(menuItem, formularios, activos);
            }
        }
    }
}
