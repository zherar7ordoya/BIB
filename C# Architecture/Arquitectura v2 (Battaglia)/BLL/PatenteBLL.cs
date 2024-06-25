using TCTD2020.ArquitecturaCapasV2.BE;
using TCTD2020.ArquitecturaCapasV2.BLL;
using TCTD2020.ArquitecturaCapasV2.DAL;
using TCTD2020.ArquitecturaCapasV2.Interfaces;
using TCTD2020.ArquitecturaCapasV2.Servicios.Composite;

namespace TCTD2020.ArquitecturaCapasV1.BLL
{
    public class PatenteBLL : AbstractBLL<IPatente>
    {

        public PatenteBLL()
        {
            _crud = new PatenteDAL();
        }


        public void SimularDatos()
        {
            var p = new Patente
            {
                Nombre = "Puede gestionar usuarios",
                Tipo = TipoPermiso.GestorUsuario
            };
            _crud.Save(p);

            p = new Patente
            {
                Nombre = "Puede gestionar permisos",
                Tipo = TipoPermiso.GestorPermiso
            };
            _crud.Save(p);
        }

       
    }
}
