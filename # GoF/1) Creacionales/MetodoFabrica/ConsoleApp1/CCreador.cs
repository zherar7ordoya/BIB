using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class CCreador
    {
        public static IVehiculo MetodoFabrica(int dinero)
        {
            if (dinero < 1000)
            {
                return new CBici();
            }
            else if (dinero < 2000)
            {
                return new CAuto();
            }
            else
            {
                return new CAvion();
            }
        }   
    }
}
