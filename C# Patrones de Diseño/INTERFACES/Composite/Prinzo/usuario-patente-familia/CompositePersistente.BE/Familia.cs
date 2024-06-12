using System.Collections.Generic;
using System.Linq;

namespace CompositePersistente.BE
{
    /***************************************************************************
    NOMBRES QUE RECIBE:
        *) Familia
        *) Rol
        *) Composite
    ***************************************************************************/

    // Los comentarios son los originales (y agregados, los de la videoconferencia)
    
    public class Familia : Componente

    {   // Método para traer todas las familias (o roles o grupos)
        // (relación 1 a M del componente con familia)
        private IList<Componente> _hijos;

        // Traigo la lista de componentes (los permisos solo se leen)
        public override IList<Componente> Hijos
        {
            get { return _hijos.ToArray(); }
        }

        // Instancio la IList<BEComponente> en el constructor
        public Familia()
        {
            _hijos = new List<Componente>();
        }


        // Método para agregar (ya sea familia o permiso)
        public override void AgregarHijo(Componente componente)
        {
            _hijos.Add(componente);
        }

        // Le quito los permisos a la familia
        public override void VaciarHijos()
        {
            _hijos = new List<Componente>();
        }
    }
}
