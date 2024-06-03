using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    internal class ControladorAuto
    {
        private readonly IVistaAuto vista;
        private readonly Auto modelo;
        private int opcion;

        public ControladorAuto(Auto modelo, IVistaAuto vista)
        {
            this.modelo = modelo;
            this.vista = vista;
        }

        public int Opcion { get => opcion; set => opcion = value; }

        public void DespliegaVista()
        {
            vista.DespliegaAuto(modelo);
        }

        public void Solicita()
        {
            opcion = vista.SolicitaEntrada();

            if (opcion == 1)
            {
                ActualizaCosto(modelo.Costo * 1.15);
            }
            if (opcion == 2)
            {
                ActualizaModelo();
            }
        }

        public void ActualizaCosto(double costo)
        {
            modelo.Costo = costo;
        }

        public void ActualizaModelo()
        {
            Console.WriteLine("Ingrese el nuevo modelo del auto: ");
            modelo.Modelo = Convert.ToInt32(Console.ReadLine());
        }
    }
}
