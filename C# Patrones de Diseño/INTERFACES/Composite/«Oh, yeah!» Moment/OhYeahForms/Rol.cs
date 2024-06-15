using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OhYeahForms
{
    // Compuesto
    class Rol : Autorizacion
    {
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

        public override void MostrarPermisos()
        {
            MessageBox.Show("\nRol: " + Nombre);
            foreach (var permiso in _permisos)
            {
                permiso.MostrarPermisos();
            }
        }

        public override void AsignarEventoClick(ToolStripMenuItem menuItem, Dictionary<string, Type> formMappings)
        {
            foreach (var permiso in _permisos)
            {
                permiso.AsignarEventoClick(menuItem, formMappings);
            }
        }

        public void Habilitar(MenuStrip menuStrip, Dictionary<string, Type> formMappings)
        {
            foreach (var permiso in _permisos)
            {
                if (permiso is Permiso)
                {
                    (permiso as Permiso).Habilitar(menuStrip, formMappings);
                }
                else if (permiso is Rol)
                {
                    (permiso as Rol).Habilitar(menuStrip, formMappings);
                }
            }
        }
    }

}
