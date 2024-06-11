using System.Collections.Generic;

namespace CompositePersistente.BE
{
    /***************************************************************************
    NOMBRES QUE RECIBE:
        *) Patente
        *) Permiso
        *) Leaf
    ***************************************************************************/

    public class BEPatente : BEComponente
    {

        //obtiene todos los permisos patentes

        public override IList<BEComponente> Hijos
        {
            get
            {
                return new List<BEComponente>();
            }

        }

        //no agrega porque las patentes son estaticas
        public override void AgregarHijo(BEComponente c)
        {

        }

        //no se borran porque las patentes son estaticas
        public override void VaciarHijos()
        {
           
        }
    }
}
