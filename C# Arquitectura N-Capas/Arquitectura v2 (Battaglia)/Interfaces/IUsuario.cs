using System.Collections.Generic;

namespace TCTD2020.ArquitecturaCapasV2.Interfaces
{
    public interface IUsuario
    {
        string Email { get; set; }
        string Password { get; set; }


        IList<IPermiso> Permisos { get;  }
    }
}
