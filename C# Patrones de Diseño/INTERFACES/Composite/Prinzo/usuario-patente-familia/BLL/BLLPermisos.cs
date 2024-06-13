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

        public bool Existe(Componente c, int id)
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
        public Componente GuardarComponente(Componente p, bool esfamilia)
        {
            return oMPPPermiso.GuardarComponente(p, esfamilia);
        }

        //método para guardar  Familias
        public void GuardarFamilia(Familia c)
        {
            oMPPPermiso.GuardarFamilia(c);
        }

        //método para taer todas las patentes
        public IList<Patente> GetAllPatentes()
        {
            return oMPPPermiso.GetAllPatentes();
        }

        //método para taer todas las familias
        public IList<Familia> GetAllFamilias()
        {
            return oMPPPermiso.GetAllFamilias();
        }

        // Método para taer todas las patentes (hijos, permisos)
        public IList<Componente> GetAll(string familia)
        {
            return oMPPPermiso.GetAll(familia);

        }


        // Método para taer los permisos del Usuario
        public void FillUserComponents(Usuario usuario)
        {
            oMPPPermiso.FillUserComponents(usuario);
        }

        //método para taer todos las familias con sus permisos
        public void FillFamilyComponents(Familia familia)
        {
            oMPPPermiso.FillFamilyComponents(familia);
        }


    }
}
