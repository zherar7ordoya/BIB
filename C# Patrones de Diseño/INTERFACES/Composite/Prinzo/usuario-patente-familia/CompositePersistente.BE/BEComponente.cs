using System.Collections.Generic;

namespace CompositePersistente.BE
{
    //clase abstracta con métodos abstractos con operaciones abstractas

    public abstract class BEComponente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Método para obtener todos los hijos (IList: interface predefinida de .NET)
        // Video: "puedo tener una lista de hijos, es decir, puedo tener permisos apartes"
        public abstract IList<BEComponente> Hijos { get; }
        
        // Método para agregar hijos
        public abstract void AgregarHijo(BEComponente c);

        // Método para vaciar hijos
        public abstract void VaciarHijos();

        // Propiedad Permisos (los permisos simples son estáticos).
        public ETipoPermiso Permiso { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
