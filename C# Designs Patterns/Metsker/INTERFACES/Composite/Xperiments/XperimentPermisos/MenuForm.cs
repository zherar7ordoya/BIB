using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Paso5
{
    public partial class MenuForm : Form
    {
        private readonly RolORM rolORM = new RolORM();
        private readonly IComposite puesto;
        private readonly List<Rol> roles = new List<Rol>();
        public MenuForm()
        {
            InitializeComponent();
            CargarRolesDesdeXml();
            Rol rol = ObtenerRol("Vendedor"); // PARÁMETRO
            if (rol != null)
            {
                puesto = rol;
                AplicarPermisos();
            }
            else
            {
                // Si el rol no existe, deshabilitar todos los elementos del menú
                foreach (ToolStripMenuItem item in MenuMudadora.Items)
                {
                    item.Enabled = false;
                    item.Visible = false;
                }
            }
        }


        private Rol ObtenerRol(string pRol)
        {
            // Buscar el rol en la lista de roles
            //return roles.FirstOrDefault(x => x.ObtenerNombre() == pRol) as Rol;
            return roles.FirstOrDefault(x => x.ObtenerNombre() == pRol);
        }


        private void CargarRolesDesdeXml()
        {
            try
            {
                XElement root = rolORM.Consultar();

                foreach (XElement rolElement in root.Elements("Rol"))
                {
                    string nombreRol = rolElement.Attribute("Nombre").Value;
                    Rol rol = new Rol(nombreRol);

                    foreach (XElement permisoElement in rolElement.Elements("Permiso"))
                    {
                        string nombrePermiso = permisoElement.Value;
                        Permiso permiso = new Permiso(nombrePermiso);
                        rol.AgregarNodo(permiso);
                    }

                    roles.Add(rol);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AplicarPermisos()
        {
            // Iterar sobre los elementos del menú y habilitar/deshabilitar según los permisos
            foreach (ToolStripMenuItem item in MenuMudadora.Items)
            {
                VerificarPermisos(item);
            }
        }

        private void VerificarPermisos(ToolStripMenuItem pItem)
        {
            // Verificar si el nombre del elemento está en la lista de nodos del rol actual
            bool tienePermiso = puesto.ObtenerNodos().Any(x => x.ObtenerNombre() == pItem.Name);

            // Habilitar/deshabilitar y hacer visible/invisible según los permisos
            pItem.Enabled = tienePermiso;
            pItem.Visible = tienePermiso;

            // Recursión a través de los subítems
            foreach (ToolStripMenuItem sub in pItem.DropDownItems)
            {
                VerificarPermisos(sub);
            }
        }
    }
}
