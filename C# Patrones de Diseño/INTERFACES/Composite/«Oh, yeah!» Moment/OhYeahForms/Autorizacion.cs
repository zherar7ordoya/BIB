using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using System;

namespace OhYeahForms
{
    [XmlInclude(typeof(Permiso))]
    [XmlInclude(typeof(Rol))]
    abstract class Autorizacion
    {
        public string Nombre { get; set; }

        public abstract void HabilitarPermiso(MenuStrip menuStrip, Dictionary<string, Type> formularios, List<Form> activos);
        public abstract void AsignarFormulario(ToolStripMenuItem menuItem, Dictionary<string, Type> formularios, List<Form> activos);
    }
}
