using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Experimental
{
    public static class TreeviewHelper
    {
        public static void CargarTreeview<T>(List<T> items, TreeView treeview)
        {
            treeview.BeginUpdate();
            treeview.Nodes.Clear();

            foreach (T item in items)
            {
                string codigo = ObtenerCodigo(item);
                TreeNode node = treeview.Nodes.Add($"{item.GetType().Name} || Código: {codigo}");
                DetallarNodo(item, node);
            }

            treeview.EndUpdate();
        }


        private static string ObtenerCodigo<T>(T item)
        {
            // Intenta obtener la propiedad "Id" utilizando reflexión
            PropertyInfo codigoPropiedad = typeof(T).GetProperty("Codigo");

            if (codigoPropiedad != null)
            {
                // Si la propiedad "Codigo" existe, obtiene su valor del objeto
                object codigoValor = codigoPropiedad.GetValue(item);
                // Si el valor es nulo, devuelve "(Sin código)"
                return codigoValor?.ToString() ?? "(Sin código)";
            }
            // Si la propiedad "Codigo" no existe, devuelve "(Sin código)"
            else { return "(Sin código)"; }
        }


        private static void DetallarNodo(object objetoOrigen, TreeNode nodo)
        {
            // Obtiene todas las propiedades del objeto
            PropertyInfo[] propiedadesObjeto = objetoOrigen.GetType().GetProperties();

            // Itera sobre cada propiedad del objeto
            foreach (PropertyInfo propiedad in propiedadesObjeto)
            {
                // Obtiene el valor de la propiedad actual
                object valorActual = propiedad.GetValue(objetoOrigen);

                // Obtiene el nombre de la propiedad actual
                string nombrePropiedad = propiedad.Name;

                // Si el valor es una colección, agrega sus elementos como nodos hijos recursivamente
                if (valorActual is IEnumerable<object> elementos)
                {
                    // Crea un nodo para los elementos de la colección
                    TreeNode nodoElementos = nodo.Nodes.Add(nombrePropiedad);

                    // Itera sobre cada elemento de la colección
                    foreach (object elemento in elementos)
                    {
                        // Crea un nodo para el elemento actual
                        TreeNode nodoElemento = nodoElementos.Nodes.Add(elemento.GetType().Name);

                        // Recursivamente agrega detalles al nodo del elemento
                        DetallarNodo(elemento, nodoElemento);
                    }
                }
                // Si el valor es un objeto de clase, agrega los detalles como nodos hijos (recursivamente)
                else if (valorActual != null &&
                         propiedad.PropertyType.IsClass &&
                         propiedad.PropertyType != typeof(string))
                {
                    // Crea un nodo para el objeto de clase
                    TreeNode nodoClase = nodo.Nodes.Add(nombrePropiedad);

                    // Recursivamente agrega detalles al nodo del objeto de clase
                    DetallarNodo(valorActual, nodoClase);
                }
                else
                {
                    // Si no es ni una colección ni un objeto de clase, agrega el valor como un nodo hijo
                    string valorPropiedad = valorActual != null ? valorActual.ToString() : "null";
                    nodo.Nodes.Add($"{nombrePropiedad}: {valorPropiedad}");
                }
            }
        }
        //*==================================================================*\\
    }












}
