using System;

namespace Patrones.Command.Core
{
    public class ProductoReceiver
    {
        public double Cantidad { get; set; }
        public string Nombre { get; set; }

        public void RestarStock(double cantidad)
        {
            Cantidad -= cantidad;
            Console.WriteLine($"Quitando {cantidad} unidades");
        }

        public void SumarStock(double cantidad)
        {
            Cantidad += cantidad;
            Console.WriteLine($"Agregando {cantidad} unidades");
        }
    }
}