using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PizzeriaJaponesa : Pizzeria
    {
        public override Empanada CrearEmpanada()
        {
            return new EmpanadaCeviche();
        }
        public override Pizza CrearPizza()
        {
            return new PizzaSushi();
        }
    }
}
