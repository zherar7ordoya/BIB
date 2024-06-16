using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OhYeahForms
{
    public partial class MainForm : Form
    {
        private readonly List<Form> activos = new List<Form>();

        public MainForm()
        {
            InitializeComponent();
            InicializarMenu();
        }

        private void InicializarMenu()
        {
            // Crear los ítems de lo que será el menú principal
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem menuVentas = new ToolStripMenuItem("Acceso a Ventas");
            ToolStripMenuItem menuOrdenes = new ToolStripMenuItem("Acceso a Órdenes");
            ToolStripMenuItem menuFacturacion = new ToolStripMenuItem("Acceso a Facturación");

            // Añadir submenús a Ventas
            menuVentas.DropDownItems.Add(menuOrdenes);
            menuVentas.DropDownItems.Add(menuFacturacion);

            // Añadir Ventas al menú principal
            menuStrip.Items.Add(menuVentas);

            // Asignar el menú principal al formulario
            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);

            // Crear permisos y roles
            Permiso venta = new Permiso("Acceso a Ventas");
            Permiso orden = new Permiso("Acceso a Órdenes");
            Permiso facturacion = new Permiso("Acceso a Facturación");

            Rol vendedor = new Rol("Vendedor");
            vendedor.AgregarPermiso(venta);
            vendedor.AgregarPermiso(orden);

            Rol cajero = new Rol("Cajero");
            cajero.AgregarPermiso(venta);
            cajero.AgregarPermiso(facturacion);

            Rol gerente = new Rol("Gerente");
            gerente.AgregarPermiso(vendedor);
            gerente.AgregarPermiso(cajero);

            // Diccionario para mapear permisos a formularios
            var formularios = new Dictionary<string, Type>
            {
                { "Acceso a Órdenes", typeof(FormOrdenes) },
                { "Acceso a Facturación", typeof(FormFacturacion) }
            };

            // Suponiendo que el usuario es...
            cajero.HabilitarPermiso(menuStrip, formularios, activos);
        }
    }
}
