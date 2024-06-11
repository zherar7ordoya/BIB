using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfiles
{
    public partial class Form1 : Form
    {
        private Usuario usuario;
        private Perfil perfil01, perfil02;

        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            usuario.Perfil = perfil02;
            MostrarPermisos();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            usuario.Perfil = perfil01;
            MostrarPermisos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecutó la función 1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecutó la función 2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecutó la función 3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecutó la función 4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecutó la función 5");
        }

        private void MostrarPermisos()
        {
            int yOffset = 20;
            List<Button> visibleButtons = new List<Button>();

            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.Visible = false;

                    // Validar si el perfil actual del usuario tiene permiso para el botón
                    if (usuario.Perfil.ValidarPermiso(button.Tag.ToString().Split(',')[0]))
                    {
                        visibleButtons.Add(button);
                    }
                }
            }

            // Ordenar y mostrar los botones visibles
            visibleButtons.Sort(new ButtonComparer());
            foreach (Button button in visibleButtons)
            {
                button.Visible = true;
                button.Top = yOffset;
                yOffset += 55;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usuario = new Usuario() { Nombre = "Juan", Apellido = "Perez" };

            // Crear permisos simples
            PermisoSimple ps1 = new PermisoSimple("001");
            PermisoSimple ps2 = new PermisoSimple("002");
            PermisoSimple ps3 = new PermisoSimple("003");
            PermisoSimple ps4 = new PermisoSimple("004");
            PermisoSimple ps5 = new PermisoSimple("005");

            // Crear permisos compuestos y agregar permisos
            PermisoCompuesto pc1 = new PermisoCompuesto("C01");
            pc1.AgregarPermiso(ps1);
            pc1.AgregarPermiso(ps2);
            pc1.AgregarPermiso(ps3);
            pc1.AgregarPermiso(ps4);

            PermisoCompuesto pc2 = new PermisoCompuesto("C02");
            pc2.AgregarPermiso(pc1);
            pc2.AgregarPermiso(ps5);

            PermisoCompuesto pc3 = new PermisoCompuesto("C03");
            pc3.AgregarPermiso(ps1);
            pc3.AgregarPermiso(ps5);

            // Crear perfiles con permisos compuestos
            perfil01 = new Perfil(pc2);
            perfil02 = new Perfil(pc3);

            usuario.Perfil = perfil01;
            MostrarPermisos();
        }
    }

    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Perfil Perfil { get; set; }
    }

    public class Perfil
    {
        private PermisoCompuesto _permisoCompuesto;

        public Perfil(PermisoCompuesto permisoCompuesto)
        {
            _permisoCompuesto = permisoCompuesto;
        }

        public bool ValidarPermiso(string codigoPermiso)
        {
            return _permisoCompuesto.RetornaPermisos().Exists(permiso => permiso.Codigo == codigoPermiso);
        }
    }

    public abstract class Permiso
    {
        public string Codigo { get; set; }
        public abstract List<Permiso> RetornaPermisos();

        protected Permiso(string codigo)
        {
            Codigo = codigo;
        }
    }

    public class PermisoSimple : Permiso
    {
        public PermisoSimple(string codigo) : base(codigo) { }

        public override List<Permiso> RetornaPermisos()
        {
            return new List<Permiso> { this };
        }
    }

    public class PermisoCompuesto : Permiso
    {
        private List<Permiso> _permisos;

        public PermisoCompuesto(string codigo) : base(codigo)
        {
            _permisos = new List<Permiso>();
        }

        public void AgregarPermiso(Permiso permiso)
        {
            _permisos.Add(permiso);
        }

        public override List<Permiso> RetornaPermisos()
        {
            List<Permiso> permisosResultantes = new List<Permiso>();
            RecursivaRetornaPermisos(_permisos, permisosResultantes);
            return permisosResultantes;
        }

        private void RecursivaRetornaPermisos(List<Permiso> permisos, List<Permiso> resultantes)
        {
            foreach (Permiso permiso in permisos)
            {
                if (permiso is PermisoSimple)
                {
                    resultantes.Add(permiso);
                }
                else
                {
                    RecursivaRetornaPermisos((permiso as PermisoCompuesto)._permisos, resultantes);
                }
            }
        }
    }

    public class ButtonComparer : IComparer<Button>
    {
        public int Compare(Button x, Button y)
        {
            int xOrder = int.Parse(x.Tag.ToString().Split(',')[1]);
            int yOrder = int.Parse(y.Tag.ToString().Split(',')[1]);

            return xOrder.CompareTo(yOrder);
        }
    }
}
