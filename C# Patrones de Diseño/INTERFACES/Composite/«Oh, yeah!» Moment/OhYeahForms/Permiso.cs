using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Linq;

namespace OhYeahForms
{
    class Permiso : Autorizacion
    {
        public Permiso(string nombre)
        {
            Nombre = nombre;
        }

        public override void HabilitarPermiso(MenuStrip menuStrip,
                                              Dictionary<string, Type> formulariosMapeables,
                                              List<Form> formulariosActivos)
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                HabilitarItem(item, formulariosMapeables, formulariosActivos);
            }
        }

        private void HabilitarItem(ToolStripMenuItem menuItem,
                                   Dictionary<string, Type> formulariosMapeables,
                                   List<Form> formulariosActivos)
        {
            if (menuItem.Text == Nombre)
            {
                menuItem.Visible = true;
                AsignarFormulario(menuItem, formulariosMapeables, formulariosActivos);
            }
            else
            {
                foreach (ToolStripMenuItem subItem in menuItem.DropDownItems)
                {
                    HabilitarItem(subItem, formulariosMapeables, formulariosActivos);
                }
            }
        }

        public override void AsignarFormulario(ToolStripMenuItem menuItem,
                                               Dictionary<string, Type> formulariosMapeables,
                                               List<Form> formulariosActivos)
        {
            if (menuItem.DropDownItems.Count == 0)
            {
                menuItem.Click += (sender, args) =>
                {
                    if (formulariosMapeables.TryGetValue(Nombre, out var formularioMapeable))
                    {
                        var formularioActivo = formulariosActivos
                        .FirstOrDefault(x => x.GetType() == formularioMapeable);

                        if (formularioActivo == null)
                        {
                            var formulario = (Form)Activator.CreateInstance(formularioMapeable);
                            formulario.MdiParent = Form.ActiveForm;
                            formulario.FormClosed += (s, e) => formulariosActivos.Remove(formulario);
                            formulariosActivos.Add(formulario);
                            formulario.Show();
                        }
                        else
                        {
                            formularioActivo.BringToFront();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Formulario no asignado para: {Nombre}");
                    }
                };
            }
        }
    }
}
