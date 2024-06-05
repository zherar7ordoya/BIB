using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class CSistemaCompra
    {

        public bool Comprar()
        {
            string dato = "";
            Console.ForegroundColor=ConsoleColor.White;
            Console.Write("Ingrese numero de tarjeta");

            dato = Console.ReadLine();

            if (dato == "1234")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Pago aceptado");
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Pago rechazado");
                return false;
            }
        }
    }
    class CSubsistemaAlmacen
    {
        private int cantidad;

        public CSubsistemaAlmacen()
        {
            cantidad = 3;
        }

        public bool SacarAlmacen()
        {
            if (cantidad>0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Producto listo para enviarse");
                cantidad--;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Producto no disponible");
                return false;
            }
        }
    }
    class CSubsitemaEnvio
    {
        public void EnviarPedido()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("El envio va en camino");
        }
    }
}
