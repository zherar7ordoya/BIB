using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experimental
{






    public static class TreeViewHelper
    {
        public static void LoadList<T>(List<T> items, TreeView treeView)
        {
            treeView.BeginUpdate(); // Inicia la actualización del control TreeView

            // Borra todos los nodos previos en el TreeView
            treeView.Nodes.Clear();

            foreach (T item in items)
            {
                // Crea un nodo TreeNode para el elemento actual y agrégalo al árbol
                TreeNode node = treeView.Nodes.Add(item.GetType().Name);

                // Agrega los detalles del objeto al nodo
                AgregarDetallesAlNodo(item, node);
            }

            treeView.EndUpdate(); // Finaliza la actualización del control TreeView
        }

        private static void AgregarDetallesAlNodo(object obj, TreeNode node)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                string propertyName = property.Name;

                // Si el valor es una colección, agrega sus elementos como nodos hijos recursivamente
                if (value is IEnumerable<object> collection)
                {
                    TreeNode collectionNode = node.Nodes.Add(propertyName);

                    foreach (object item in collection)
                    {
                        TreeNode itemNode = collectionNode.Nodes.Add(item.GetType().Name);
                        AgregarDetallesAlNodo(item, itemNode);
                    }
                }
                else
                {
                    // Si no es una colección, agrega el valor como un nodo hijo
                    string propertyValue = value != null ? value.ToString() : "null";
                    node.Nodes.Add($"{propertyName}: {propertyValue}");
                }
            }
        }
    }












}
