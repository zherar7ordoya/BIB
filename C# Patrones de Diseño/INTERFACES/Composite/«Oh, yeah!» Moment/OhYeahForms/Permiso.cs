using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OhYeahForms
{
    class Permiso : Autorizacion
    {
        public Permiso(string nombre)
        {
            Nombre = nombre;
        }

        public override void HabilitarPermiso(
            MenuStrip menuStrip,
            Dictionary<string, Type> formularios,
            List<Form> activos)
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                HabilitarItem(item, formularios, activos);
            }
        }

        private void HabilitarItem(
            ToolStripMenuItem menuItem,
            Dictionary<string, Type> formularios,
            List<Form> activos)
        {
            if (menuItem.Text == Nombre)
            {
                AsignarFormulario(menuItem, formularios, activos);
            }
            else
            {
                foreach (ToolStripMenuItem subItem in menuItem.DropDownItems)
                {
                    HabilitarItem(subItem, formularios, activos);
                }
            }
        }

        public override void AsignarFormulario(
            ToolStripMenuItem menuItem,
            Dictionary<string, Type> formularios,
            List<Form> activos)
        {
            if (menuItem.DropDownItems.Count == 0)
            {
                menuItem.Click += (sender, args) =>
                {
                    if (formularios.ContainsKey(Nombre))
                    {
                        Type formulario = formularios[Nombre];
                        Form activo = activos.FirstOrDefault(x => x.GetType() == formulario);

                        if (activo == null)
                        {
                            Form form = (Form)Activator.CreateInstance(formulario);
                            form.MdiParent = Form.ActiveForm;
                            form.FormClosed += (s, e) => activos.Remove(form);
                            activos.Add(form);
                            form.Show();
                        }
                        else
                        {
                            activo.BringToFront();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formulario no asignado para: " + Nombre);
                    }
                };
            }
        }
    }
}
