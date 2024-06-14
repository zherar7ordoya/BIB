using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paso5
{
    public interface IABMC<T>
    {
        void Agregar(T pObject);
        void Eliminar(int pId);
        void Modificar(T pObject);
        List<T> Consultar();
    }
}
