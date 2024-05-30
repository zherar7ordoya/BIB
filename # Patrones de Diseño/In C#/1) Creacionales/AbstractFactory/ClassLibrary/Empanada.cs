using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Empanada
    {
        protected string descripcion = "Empanada desconocida";

        public string Descripcion
        {
            get { return descripcion; }
        }
    }
}
