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

    public class BEFamilia : BEComponente

    {   //método para traer todas las flia o roles o grupos
        //la relacion 1 a M del componente con Flia
        private IList<BEComponente> _hijos;

        //instancio la IList<BEComponente en el constructor
        public BEFamilia()
        {
            _hijos = new List<BEComponente>();
        }

        //Traigo al listta de componentes.
        public override IList<BEComponente> Hijos
        {
            get
            {
                return _hijos.ToArray();
            }

        }

        //método agregar hijo, le agrego el componente a la lista
        //puede ser una flia o un permiso
        public override void AgregarHijo(BEComponente c)
        {
            _hijos.Add(c);
        }

        //vaciar instancio la 
        public override void VaciarHijos()
        {
            _hijos = new List<BEComponente>();
        }

      
    }
}
