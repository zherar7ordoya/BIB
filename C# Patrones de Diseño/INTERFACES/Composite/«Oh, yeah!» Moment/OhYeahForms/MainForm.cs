using System.Collections.Generic;
using System.Windows.Forms;
using System;

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
            var menuStrip = new MenuStrip();
            var menuVentas = new ToolStripMenuItem("Acceso a Ventas");
            var menuOrdenes = new ToolStripMenuItem("Acceso a Órdenes");
            var menuFacturacion = new ToolStripMenuItem("Acceso a Facturación");

            menuVentas.DropDownItems.AddRange(new[] { menuOrdenes, menuFacturacion });
            menuStrip.Items.Add(menuVentas);

            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);

            var permisos = CrearPermisos();
            var roles = CrearRoles(permisos);
            var formularios = CrearDiccionarioFormularios();

            // Assuming the user is a gerente
            roles["Gerente"].HabilitarPermiso(menuStrip, formularios, activos);
        }

        private Dictionary<string, Permiso> CrearPermisos()
        {
            return new Dictionary<string, Permiso>
            {
                { "Acceso a Ventas", new Permiso("Acceso a Ventas") },
                { "Acceso a Órdenes", new Permiso("Acceso a Órdenes") },
                { "Acceso a Facturación", new Permiso("Acceso a Facturación") }
            };
        }

        private Dictionary<string, Rol> CrearRoles(Dictionary<string, Permiso> permisos)
        {
            var vendedor = new Rol("Vendedor");
            vendedor.AgregarPermiso(permisos["Acceso a Ventas"]);
            vendedor.AgregarPermiso(permisos["Acceso a Órdenes"]);

            var cajero = new Rol("Cajero");
            cajero.AgregarPermiso(permisos["Acceso a Ventas"]);
            cajero.AgregarPermiso(permisos["Acceso a Facturación"]);

            var gerente = new Rol("Gerente");
            gerente.AgregarPermiso(vendedor);
            gerente.AgregarPermiso(cajero);

            return new Dictionary<string, Rol>
            {
                { "Vendedor", vendedor },
                { "Cajero", cajero },
                { "Gerente", gerente }
            };
        }

        private Dictionary<string, Type> CrearDiccionarioFormularios()
        {
            return new Dictionary<string, Type>
            {
                { "Acceso a Órdenes", typeof(FormOrdenes) },
                { "Acceso a Facturación", typeof(FormFacturacion) }
            };
        }
    }
}
