using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OhYeahForms
{
    // Componente base
    abstract class Autorizacion
    {
        public string Nombre { get; set; }
        public abstract void MostrarPermisos();
        public abstract void AsignarEventoClick(ToolStripMenuItem menuItem, Dictionary<string, Type> formMappings);
    }

}
