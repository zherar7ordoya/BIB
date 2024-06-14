using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OhYeahForms
{
    // Hoja
    class Permiso : Autorizacion
    {
        public Permiso(string nombre)
        {
            Nombre = nombre;
        }

        public override void MostrarPermisos()
        {
            MessageBox.Show(Nombre);
        }

        public override void AsignarEventoClick(ToolStripMenuItem menuItem, Dictionary<string, Type> formMappings)
        {
            // Si el permiso no tiene submenús, asignar evento Click
            if (menuItem.DropDownItems.Count == 0)
            {
                menuItem.Click += (sender, args) =>
                {
                    if (formMappings.ContainsKey(Nombre))
                    {
                        Type formType = formMappings[Nombre];
                        Form form = (Form)Activator.CreateInstance(formType);
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Formulario no asignado para: " + Nombre);
                    }
                };
            }
        }

        public void Habilitar(MenuStrip menuStrip, Dictionary<string, Type> formMappings)
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                HabilitarItem(item, formMappings);
            }
        }

        // Se asegura de habilitar y asignar eventos de clic solo a los ítems de menú que son hojas
        private void HabilitarItem(ToolStripMenuItem menuItem, Dictionary<string, Type> formMappings)
        {
            if (menuItem.Text == Nombre)
            {
                menuItem.Enabled = true;
                AsignarEventoClick(menuItem, formMappings);
            }

            foreach (ToolStripMenuItem subItem in menuItem.DropDownItems)
            {
                HabilitarItem(subItem, formMappings);
            }
        }
    }

}
