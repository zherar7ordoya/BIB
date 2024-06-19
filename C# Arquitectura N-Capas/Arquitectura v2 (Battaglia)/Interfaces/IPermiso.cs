using System.Collections.Generic;

namespace TCTD2020.ArquitecturaCapasV2.Interfaces
{
    public interface IPermiso:IEntity
    {
        string Nombre { get; set; }
        void AgregarPermiso(IPermiso p);
        void QuitarPermiso(IPermiso p);
        IList<IPermiso> ObtenerHijos();
    }
    
}
