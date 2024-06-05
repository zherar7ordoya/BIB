using System;

namespace Subsistemas
{
    internal class CSubSistemaAlmacen
    {
        private int _cantidad;

        public CSubSistemaAlmacen()
        {
            _cantidad = 3;
        }

        public bool SacarAlmacen()
        {
            if (_cantidad > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Producto listo para envío");
                _cantidad--;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Producto no disponible");
                return false;
            }
        }
    }
}
