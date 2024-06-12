using System.Collections.Generic;

namespace CompositePersistente.BE
{
    /***************************************************************************
    NOMBRES QUE RECIBE:
        *) Patente
        *) Hijo
        *) Permiso
    ***************************************************************************/

    public class Patente : Componente
    {
        // Todos los permisos (patentes)
        public override IList<Componente> Hijos
        {
            get { return new List<Componente>(); }
        }

        // No agrega porque las patentes son estáticas
        public override void AgregarHijo(Componente componente) { }

        // No borra porque las patentes son estáticas
        public override void VaciarHijos() { }
    }
}
