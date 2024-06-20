using System;

namespace ConEvento
{
    // Antes esta clase se llamaba Sujeto (Subject).
    public class Interesante
    {
        public Interesante(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre { get; }
        private int _estado;

        //--------------------------------------------------------------------\\
        /*** /*** /*** EL SUJETO (INTERESANTE) TIENE QUE PROVEER: \*** \*** ***/

        // 1. Un tipo evento al que los observadores se suscriban.**************
        public event EventHandler CambioHandler;

        // 2. Una condición que llame al invocador del evento.******************
        public int Estado
        {
            get { return _estado; }
            set
            {
                if (_estado != value)
                {
                    _estado = value;
                    OnEstadoChanged(EventArgs.Empty);
                }
            }
        }

        // 3. Un método que invoque al evento.**********************************
        protected virtual void OnEstadoChanged(EventArgs e)
        {
            CambioHandler?.Invoke(this, e);
        }
    }
}

/*
La razón por la que el método OnStateChanged es protected virtual se debe a
prácticas comunes y recomendaciones de diseño en el uso de eventos en C#.
 *) protected: El modificador protected permite que el método OnStateChanged sea
    accesible dentro de la propia clase Subject y en cualquier clase que derive
    de Sujeto Interesante. Esto es útil porque permite que las clases derivadas
    puedan desencadenar el evento StateChanged si es necesario.
 *) virtual: El modificador virtual permite que el método OnStateChanged sea
    sobrescrito en una clase derivada. Esto es útil cuando una clase derivada
    quiere cambiar o extender el comportamiento del método OnStateChanged sin
    cambiar la implementación en la clase base.
*/

