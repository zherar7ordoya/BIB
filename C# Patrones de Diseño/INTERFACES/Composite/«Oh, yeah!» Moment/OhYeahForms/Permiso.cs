using System;
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
            Dictionary<string, Type> formAsignaciones,
            List<Form> formAbiertos
            )
        {
            if (menuItem.DropDownItems.Count == 0)
            {
                menuItem.Click += (sender, args) =>
                {
                    if (formAsignaciones.ContainsKey(Nombre))
                    {
                        Type formType = formAsignaciones[Nombre];
                        Form openForm = formAbiertos.FirstOrDefault(f => f.GetType() == formType);

                        // Antes de crear una nueva instancia de un formulario, se
                        // verifica si ya existe una instancia abierta de ese tipo.
                        // Si ya existe, se lleva ese formulario al frente(BringToFront).
                        // Si no existe, se crea una nueva instancia, se añade a
                        // la lista openForms, y se configura para que se elimine
                        // de la lista al cerrarse.
                        if (openForm == null)
                        {
                            Form form = (Form)Activator.CreateInstance(formType);
                            form.MdiParent = Form.ActiveForm;
                            form.FormClosed += (s, e) => formAbiertos.Remove(form);
                            formAbiertos.Add(form);
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
            Dictionary<string, Type> formAsignaciones,
            List<Form> formAbiertos
            )
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                HabilitarItem(item, formAsignaciones, formAbiertos);
            }
        }

        // Se asegura de habilitar y asignar eventos de clic solo a los ítems de menú que son hojas
        private void HabilitarItem
            (
            ToolStripMenuItem menuItem,
            Dictionary<string, Type> formAsignaciones,
            List<Form> formAbiertos
            )
        {
            if (menuItem.Text == Nombre)
            {
                //menuItem.Visible = true;
                AsignarEventoClick(menuItem, formAsignaciones, formAbiertos);
            }

            foreach (ToolStripMenuItem subItem in menuItem.DropDownItems)
            {
                HabilitarItem(subItem, formAsignaciones, formAbiertos);
            }
        }
    }

}
