using System.Collections.Generic;

namespace CompositePersistente.BE
{
    /***************************************************************************
    NOMBRES QUE RECIBE:
        *) Patente
        *) Hijo
        *) Permiso
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

        // No agrega porque las patentes son estáticas
        public override void AgregarHijo(BEComponente c) { }

        // No se borran porque las patentes son estáticas
        public override void VaciarHijos() { }
    }
}
