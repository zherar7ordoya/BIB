
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositePersistente.BE;
using CompositePersistente.MPP;

namespace CompositePersistente
{
      
    public class BLLUsuario 
    {
     

        MPPUsuario oMPPUsuario;
        public BLLUsuario()
        {
    
            // instancio el objeto mapper en el constructor de la clase Alumno
            oMPPUsuario= new MPPUsuario();
        }

        public List<BEUsuario>ListarTodo()
        {
            return oMPPUsuario.GetAll();
        }

        public bool GuardarPermisos(BEUsuario oBEUsu)
        {
              return oMPPUsuario.GuardarPermisos(oBEUsu);
        }
    }
}
