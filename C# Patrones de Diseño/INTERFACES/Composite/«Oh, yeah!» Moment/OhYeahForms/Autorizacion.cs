using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OhYeahForms
{
    // Componente base
    [XmlInclude(typeof(Permiso))]
    [XmlInclude(typeof(Rol))]
    abstract class Autorizacion
    {
        public string Nombre { get; set; }
        public abstract void MostrarPermisos();
        public abstract void AsignarEventoClick
            (
            ToolStripMenuItem menuItem,
            Dictionary<string, Type> formAsignaciones,
            List<Form> formAbiertos
            );
    }

}
