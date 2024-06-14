using CompositePersistente.BE;
using CompositePersistente.MPP;

namespace CompositePersistente
{
    public class BLLSesion
    {
        public void Login(Usuario oBEUsu)
        {
            (new MPPPermiso()).FillUserComponents(oBEUsu);
            SimuladorSesion.GetInstance.Login(oBEUsu);
        }

        public void Logout()
        {
            SimuladorSesion.GetInstance.Logout();
        }
    }
}
