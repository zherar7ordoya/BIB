using System.Collections.Generic;

namespace CompositePersistente.BE
{
    //clase abstracta con métodos abstractos con operaciones abstractas

    public abstract class Componente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Forma de obtener todos los hijos (IList: interface predefinida de .NET)
        // Video: "puedo tener una lista de hijos, es decir, puedo tener permisos apartes"
        public abstract IList<Componente> Hijos { get; }
        
        // Método para agregar hijos
        public abstract void AgregarHijo(Componente c);

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
