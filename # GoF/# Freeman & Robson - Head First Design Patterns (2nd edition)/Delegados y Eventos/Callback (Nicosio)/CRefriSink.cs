using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cap_07_Interfaz_callBack
{
    internal class CRefriSink : IEventoRefri    
    {
        //metodo del sink
        public void EReservasBajas(int pKilos)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"==> Reservas bajas de alimentos (quedan {pKilos} kilos)");
        }
    }
}
