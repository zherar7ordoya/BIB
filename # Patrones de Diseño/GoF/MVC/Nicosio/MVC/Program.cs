using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    internal class Program
    {
        static void Main()
        {
            Auto auto = new Auto("March", 2019, 250);
            IVistaAuto vista = new VistaAuto();
            ControladorAuto controlador = new ControladorAuto(auto, vista);

            while (controlador.Opcion != 3)
            {
                controlador.DespliegaVista();
                controlador.Solicita();
            }
        }
    }
}
