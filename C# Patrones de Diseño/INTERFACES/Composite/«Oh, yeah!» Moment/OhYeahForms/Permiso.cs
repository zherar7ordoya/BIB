using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public override void AsignarEventoClick
            (
            ToolStripMenuItem menuItem,
            Dictionary<string, Type> formMappings,
            List<Form> openForms
            )
        {
            if (menuItem.DropDownItems.Count == 0)
            {
                menuItem.Click += (sender, args) =>
                {
                    if (formMappings.ContainsKey(Nombre))
                    {
                        Type formType = formMappings[Nombre];
                        Form openForm = openForms.FirstOrDefault(f => f.GetType() == formType);

                        // Antes de crear una nueva instancia de un formulario, se
                        // verifica si ya existe una instancia abierta de ese tipo.
                        // Si ya existe, se lleva ese formulario al frente(BringToFront).
                        // Si no existe, se crea una nueva instancia, se añade a
                        // la lista openForms, y se configura para que se elimine
                        // de la lista al cerrarse.
                        if (openForm == null)
                        {
                            Form form = (Form)Activator.CreateInstance(formType);
                            form.FormClosed += (s, e) => openForms.Remove(form);
                            openForms.Add(form);
                            form.Show();
                        }
                        else
                        {
                            openForm.BringToFront();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formulario no asignado para: " + Nombre);
                    }
                };
            }
        }

        public void Habilitar
            (
            MenuStrip menuStrip,
            Dictionary<string, Type> formMappings,
            List<Form> openForms
            )
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                HabilitarItem(item, formMappings, openForms);
            }
        }

        // Se asegura de habilitar y asignar eventos de clic solo a los ítems de menú que son hojas
        private void HabilitarItem
            (
            ToolStripMenuItem menuItem,
            Dictionary<string, Type> formMappings,
            List<Form> openForms
            )
        {
            if (menuItem.Text == Nombre)
            {
                menuItem.Enabled = true;
                AsignarEventoClick(menuItem, formMappings, openForms);
            }

            foreach (ToolStripMenuItem subItem in menuItem.DropDownItems)
            {
                HabilitarItem(subItem, formMappings, openForms);
            }
        }
    }

}
