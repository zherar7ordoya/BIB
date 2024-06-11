using CompositePersistente.BE;
using CompositePersistente.MPP;

namespace CompositePersistente
{
    public class BLLSesion
    {

        //instancio el objeto Mapper de permisos
        MPPPermiso oMPPPermiso;
        public BLLSesion()
        {
            oMPPPermiso = new MPPPermiso();
        }


        public void Login(BEUsuario oBEUsu)
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
