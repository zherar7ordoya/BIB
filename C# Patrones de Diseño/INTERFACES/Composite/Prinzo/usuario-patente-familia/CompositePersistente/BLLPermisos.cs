using CompositePersistente.BE;
using CompositePersistente.MPP;

using System;
using System.Collections.Generic;

namespace CompositePersistente
{
    public class BLLPermisos
    {
        
        //instancio el objeto Mapper de permisos
        MPPPermiso oMPPPermiso;
        public BLLPermisos()
        {
            oMPPPermiso = new MPPPermiso();
        }

        //método para sabner si existe

        public bool Existe(BEComponente c, int id)
        {
            bool existe = false;

            if (c.Id.Equals(id))
                existe = true;
            else

                foreach (var item in c.Hijos)
                {

                    existe = Existe(item, id);
                    if (existe) return true;
                }

            return existe;

        }

        //método para buscar todos los permisos
        public Array GetAllPermission()
        {
            return oMPPPermiso.GetAllPermission();
        }


        //método para guardar  los permisosm en la familia
        public BEComponente GuardarComponente(BEComponente p, bool esfamilia)
        {
            return oMPPPermiso.GuardarComponente(p, esfamilia);
        }

        //método para guardar  Familias
        public void GuardarFamilia(BEFamilia c)
        {
            oMPPPermiso.GuardarFamilia(c);
        }

        //método para taer todas las patentes
        public IList<BEPatente> GetAllPatentes()
        {
            return oMPPPermiso.GetAllPatentes();
        }

        //método para taer todas las familias
        public IList<BEFamilia> GetAllFamilias()
        {
            return oMPPPermiso.GetAllFamilias();
        }

        //método para taer todas las patentes
        public IList<BEComponente> GetAll(string familia)
        {
            return oMPPPermiso.GetAll(familia);

        }


        //método para taer los permisos de los suaurios
        public void FillUserComponents(BEUsuario u)
        {
            oMPPPermiso.FillUserComponents(u);

        }

        //método para taer todos las familias con sus permisos
        public void FillFamilyComponents(BEFamilia familia)
        {
            oMPPPermiso.FillFamilyComponents(familia);
        }


    }
}
