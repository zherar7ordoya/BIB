using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace OhYeahForms
{
    public partial class MainForm : Form
    {
        private readonly List<Form> formulariosActivos = new List<Form>();

        public MainForm()
        {
            InitializeComponent();
            InicializarMenu();
        }

        private void InicializarMenu()
        {
            var menuStrip = CrearMenu();
            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);

            var permisos = CrearPermisos();
            var roles = CrearRoles(permisos);
            var formulariosMapeables = CrearFormulariosMapeables();

            // Asumiendo que el usuario es un...
            roles["Cajero"].HabilitarPermiso(menuStrip,
                                              formulariosMapeables,
                                              formulariosActivos);
        }

        private MenuStrip CrearMenu()
        {
            var menuStrip = new MenuStrip();

            // Siempre visibles (es decir, no dependen de roles) <== Manual
            var menuArchivo = new ToolStripMenuItem("Archivo");
            var menuAcercaDe = new ToolStripMenuItem("Acerca de");

            //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

            // Ventas
            var menuVentas = new ToolStripMenuItem("Acceso a Ventas");
            menuVentas.Visible = false;

            var menuOrdenes = new ToolStripMenuItem("Acceso a Órdenes");
            menuOrdenes.Visible = false;

            var menuFacturacion = new ToolStripMenuItem("Acceso a Facturación");
            menuFacturacion.Visible = false;

            menuVentas.DropDownItems.AddRange(new[]
            {
                menuOrdenes,
                menuFacturacion
            });

            // Logística
            var menuLogistica = new ToolStripMenuItem("Acceso a Logística");
            menuLogistica.Visible = false;

            // Menú general

            menuStrip.Items.AddRange(new[] {
                menuArchivo,
                menuVentas,
                menuLogistica,
                menuAcercaDe
            });

            return menuStrip;
        }

        private Dictionary<string, Permiso> CrearPermisos()
        {
            return new Dictionary<string, Permiso>
            {
                { "Acceso a Ventas", new Permiso("Acceso a Ventas") },
                { "Acceso a Órdenes", new Permiso("Acceso a Órdenes") },
                { "Acceso a Facturación", new Permiso("Acceso a Facturación") },
                { "Acceso a Logística", new Permiso("Acceso a Logística") }
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
            gerente.AgregarPermiso(permisos["Acceso a Logística"]);

            return new Dictionary<string, Rol>
            {
                { "Vendedor", vendedor },
                { "Cajero", cajero },
                { "Gerente", gerente }
            };
        }

        private Dictionary<string, Type> CrearFormulariosMapeables()
        {
            return new Dictionary<string, Type>
            {
                { "Acceso a Órdenes", typeof(FormOrdenes) },
                { "Acceso a Facturación", typeof(FormFacturacion) }
            };
        }
    }
}
