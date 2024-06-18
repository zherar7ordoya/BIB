using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Paso5
{
    public partial class TreeForm : Form
    {
        //||||||||||||||||||||||||||||||||||||||||||||||||||||||| INICIALIZACIÓN


        private readonly RolORM rolORM = new RolORM();
        private readonly IComposite raiz;

        public TreeForm()
        {
            InitializeComponent();
            raiz = new Rol("Roles");
        }

        private void TreeForm_Load(object sender, EventArgs e)
        {
            CargarPermisos(string.Empty);
            RolesTreeview.AfterSelect += RolesTreeview_AfterSelect;
        }


        // Acepta filtrado por rol (no se usa, pero acepta)
        private void CargarPermisos(string pRol)
        {
            try
            {
                // Limpiar el árbol antes de reconstruirlo
                RolesTreeview.Nodes.Clear();

                // Leer el archivo XML de roles
                XElement rolesArchivo = rolORM.Consultar();

                // Obtener todos los roles o el rol especificado en el archivo XML
                IEnumerable <XElement> rolesElements;

                // Obtener todos los roles si rol == empty
                if (string.IsNullOrWhiteSpace(pRol))
                {
                    rolesElements = rolesArchivo.Descendants("Rol");
                }
                // Obtener un rol específico
                else
                {
                    rolesElements = rolesArchivo.Descendants("Rol")
                        .Where(x => x.Attribute("Nombre")?.Value == pRol);
                }

                // Construir el árbol a partir de los roles obtenidos
                foreach (var rolElement in rolesElements)
                {
                    string rolNombre = rolElement.Attribute("Nombre")?.Value;

                    if (!string.IsNullOrEmpty(rolNombre))
                    {
                        // Crear un nodo para el rol actual
                        Rol rol = new Rol(rolNombre);

                        // Agregar permisos al nodo del rol actual
                        foreach (XElement permisoElement in rolElement.Elements("Permiso"))
                        {
                            string permisoNombre = permisoElement.Value;
                            Permiso permiso = new Permiso(permisoNombre);
                            rol.AgregarNodo(permiso);
                        }
                        raiz.AgregarNodo(rol);
                    }
                }
                ConstruirTreeview(RolesTreeview.Nodes, raiz);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConstruirTreeview(TreeNodeCollection pTNC, IComposite pNodo)
        {
            // Limpiar el árbol antes de reconstruirlo
            pTNC.Clear();

            // Crear un nodo para cada rol y agregarlo al árbol
            foreach (IComposite subNodo in pNodo.ObtenerNodos())
            {
                TreeNode treeNode = new TreeNode(subNodo.ObtenerNombre());

                // Agregar el nuevo nodo al árbol
                pTNC.Add(treeNode);

                // Si el nodo tiene subnodos (permisos), agregarlos también
                foreach (IComposite subNodoPermiso in subNodo.ObtenerNodos())
                {
                    TreeNode permisoNode = new TreeNode(subNodoPermiso.ObtenerNombre());
                    treeNode.Nodes.Add(permisoNode);
                }
            }
        }


        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| MÉTODOS


        private TreeNode BuscarNodo(TreeNodeCollection nodos, string textoBuscado)
        {
            TreeNode nodoCoincidente = null;

            foreach (TreeNode nodo in nodos)
            {
                Console.WriteLine("Nodo actual: " + nodo.Text);

                if (nodo.Text == textoBuscado)
                {
                    Console.WriteLine("¡Nodo encontrado!");
                    nodoCoincidente = nodo;
                }

                TreeNode nodoHijo = BuscarNodo(nodo.Nodes, textoBuscado);

                // Actualizar el nodo coincidente si encontramos un nodo hijo que coincide
                if (nodoHijo != null)
                {
                    nodoCoincidente = nodoHijo;
                }
            }

            return nodoCoincidente;
        }


        private bool ExistePermisoEnRol(TreeNode rolNode, string permiso)
        {
            // Verificar si el permiso ya existe en el rol
            foreach (TreeNode nodo in rolNode.Nodes)
            {
                if (nodo.Text == permiso)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ExisteRolEnTreeview(string nombreRol)
        {
            foreach (TreeNode nodo in RolesTreeview.Nodes)
            {
                if (nodo.Text == nombreRol)
                {
                    return true;
                }
            }
            return false;
        }


        private void RecorrerTreeview(XElement parentElement, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Crear un elemento para cada nodo del TreeView
                XElement nodeElement;

                if (node.Nodes.Count > 0)
                {
                    // Nodo de rol con permisos
                    nodeElement = new XElement("Rol");
                    nodeElement.SetAttributeValue("Nombre", node.Text);

                    // Recursivamente agregar nodos hijos (permisos) si tiene permisos
                    RecorrerTreeview(nodeElement, node.Nodes);

                    // Agregar el elemento al padre solo si tiene hijos (permisos)
                    parentElement.Add(nodeElement);
                }
                else
                {
                    if (node.Parent == null)
                    {
                        // Nodo de rol sin permisos
                        nodeElement = new XElement("Rol");
                        nodeElement.SetAttributeValue("Nombre", node.Text);

                        // Agregar el elemento al padre solo si no es un rol sin permisos
                        parentElement.Add(nodeElement);
                    }
                    else
                    {
                        // Nodo de permiso
                        nodeElement = new XElement("Permiso", node.Text);

                        // Agregar el elemento al padre solo si no es un rol sin permisos
                        parentElement.Add(nodeElement);
                    }
                }
            }
        }


        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| BOTONERA


        private void RolAgregarBTN_Click(object sender, EventArgs e)
        {
            string nuevoRol = RolTXT.Text;

            // Verificar si el rol ya existe en el TreeView
            if (!ExisteRolEnTreeview(nuevoRol))
            {
                // Agregar el nuevo rol como un nodo raíz
                TreeNode nuevoRolNode = new TreeNode(nuevoRol);
                RolesTreeview.Nodes.Add(nuevoRolNode);
            }
            else
            {
                MessageBox.Show($"El rol '{nuevoRol}' ya existe.");
            }
        }


        private void RolQuitarBTN_Click(object sender, EventArgs e)
        {

            // Buscar y quitar el nodo del rol
            TreeNode rolNode = BuscarNodo(RolesTreeview.Nodes, RolTXT.Text);

            if (rolNode != null)
            {
                RolesTreeview.Nodes.Remove(rolNode);
            }
            else
            {
                MessageBox.Show($"Rol no encontrado: {RolTXT.Text}");
            }
        }


        private void PermisoAgregarBTN_Click(object sender, EventArgs e)
        {
            //AgregarPermiso(RolTXT.Text, PermisoTXT.Text);
            // Buscar el nodo del rol
            TreeNode rolNode = BuscarNodo(RolesTreeview.Nodes, RolTXT.Text);

            if (rolNode != null)
            {
                // Verificar si el permiso ya existe antes de agregarlo
                if (!ExistePermisoEnRol(rolNode, PermisoTXT.Text))
                {
                    // Agregar el nuevo permiso como un nodo hijo
                    TreeNode nuevoPermisoNode = new TreeNode(PermisoTXT.Text);
                    rolNode.Nodes.Add(nuevoPermisoNode);
                }
                else
                {
                    MessageBox.Show($"El permiso '{PermisoTXT.Text}' ya existe en el rol '{RolTXT.Text}'.");
                }
            }
            else
            {
                MessageBox.Show($"Rol no encontrado: {RolTXT.Text}");
            }
        }


        private void PermisoQuitarBTN_Click(object sender, EventArgs e)
        {

            // Buscar el nodo del rol
            TreeNode rolNode = BuscarNodo(RolesTreeview.Nodes, RolTXT.Text);

            if (rolNode != null)
            {
                // Buscar y quitar el nodo del permiso
                TreeNode permisoNode = BuscarNodo(rolNode.Nodes, PermisoTXT.Text);

                if (permisoNode != null)
                {
                    rolNode.Nodes.Remove(permisoNode);
                    RolesTreeview.Refresh();
                }
                else
                {
                    MessageBox.Show($"Permiso no encontrado: {PermisoTXT.Text}");
                }
            }
            else
            {
                MessageBox.Show($"Rol no encontrado: {RolTXT.Text}");
            }
        }


        private void GrabarBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un nuevo elemento raíz
                XElement rolesElement = new XElement("Roles");

                // Recorrer los nodos del TreeView y agregarlos al nuevo elemento raíz
                RecorrerTreeview(rolesElement, RolesTreeview.Nodes);

                // Guardar el nuevo documento XML en el archivo
                // doc.Save(rutaArchivo);
                rolORM.Modificar(rolesElement);

                MessageBox.Show("Cambios guardados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| EVENTOS


        private void RolesTreeview_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // Verificar si el nodo seleccionado tiene un padre
                TreeNode padre = e.Node.Parent;

                // Obtener el nombre del rol desde el nodo seleccionado o su nodo padre
                string nombreRol = (padre != null) ? padre.Text : e.Node.Text;

                // Verificar si el nodo seleccionado es permiso
                if (e.Node.Nodes.Count == 0 && e.Node.Parent != null)
                {
                    // El nodo seleccionado es un permiso
                    RolTXT.Text = nombreRol;
                    PermisoTXT.Text = e.Node.Text;
                }
                else
                {
                    // El nodo seleccionado es un rol nuevo (sin permisos)
                    RolTXT.Text = nombreRol;
                    PermisoTXT.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
