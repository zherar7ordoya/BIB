using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paso5
{
    public class EmpleadoBLL : IABMC<Empleado>
    {
        private readonly EmpleadoORM empleadoORM;
        public EmpleadoBLL() => empleadoORM = new EmpleadoORM();

        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| ABMC

        public void Agregar(Empleado pObject) => empleadoORM.Agregar(pObject);
        public void Eliminar(int pId) => empleadoORM.Eliminar(pId);
        public void Modificar(Empleado pObject) => empleadoORM.Modificar(pObject);
        public List<Empleado> Consultar() => empleadoORM.Consultar();
    }
}
