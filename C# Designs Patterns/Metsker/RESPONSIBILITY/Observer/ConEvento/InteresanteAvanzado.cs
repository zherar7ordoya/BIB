using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConEvento
{
    public class InteresanteAvanzado : Interesante
    {
        public InteresanteAvanzado(string name) : base(name) { }

        /***EN ESTA "VUELTA DE TUERCA", NO INVOCO NADA, LO MANEJO TODO AQUÍ.***/

        protected override void OnEstadoChanged(EventArgs e)
        {
            // Lógica adicional antes de que el evento sea disparado
            Console.WriteLine($"\n{Nombre} is about to change state.");

            // Llama a la implementación base para disparar el evento
            base.OnEstadoChanged(e);

            // Lógica adicional después de que el evento sea disparado
            Console.WriteLine($"{Nombre} has changed state. Ahora es {Estado}\n");
        }
    }
}
