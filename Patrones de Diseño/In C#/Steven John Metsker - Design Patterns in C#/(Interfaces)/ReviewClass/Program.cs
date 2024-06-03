using System;
using System.Xml.Serialization;


namespace ReviewClass
{

    // Atributo de serialización (Serialization Attribute)
    [Serializable]
    public abstract class MensajeBase
    {
        // Método abstracto (Abstract method)
        public abstract void MostrarMensaje();
    }

    // Interfaz (Interface)
    public interface ISaludable
    {
        void Saludar();
    }

    // Delegado (Delegate)
    public delegate void CambioEstadoEventHandler(object sender, EventArgs e);

    // Clase derivada (Derived class)
    [Serializable]
    public class MensajeFormal : MensajeBase, ISaludable
    {
        // Constante (Constant)
        public const string TipoMensaje = "Formal";

        // Campo (Field)
        private readonly string _mensaje;

        // Campo (Field)
        private bool _visible;

        // Campo estático (Static Field)
        private static int _contador;

        // Atributo de metadatos (Metadata Attribute)
        [XmlIgnore]

        // Propiedad (Property)
        public bool Visible
        {
            // Accesor de lectura (Get accessor)
            get { return _visible; }

            // Accesor de escritura (Set accessor)
            set
            {
                _visible = value;
                OnCambioEstado(EventArgs.Empty);
            }
        }

        // Evento (Event)
        public event CambioEstadoEventHandler CambioEstado;

        // Constructor de instancia (Instance Constructor)
        public MensajeFormal(string mensaje)
        {
            _mensaje = mensaje;
            _contador++;
        }

        // Constructor estático (Static Constructor)
        static MensajeFormal()
        {
            _contador = 0;
        }

        // Destructor (Destructor)
        ~MensajeFormal()
        {
            // Liberación de recursos si es necesario
        }

        // Método (Method)
        public void Saludar()
        {
            Console.WriteLine("Buenos días, " + _mensaje);
        }

        // Propiedad estática (Static Property)
        public static int Contador
        {
            // Accesor de lectura (Get accessor)
            get { return _contador; }
        }

        // Operador (Operator)
        public static MensajeFormal operator +(MensajeFormal f1, MensajeFormal f2)
        {
            return new MensajeFormal(f1._mensaje + " y " + f2._mensaje);
        }

        // Indexador (Indexer)
        public string this[int index]
        {
            get { return _mensaje[index].ToString(); }
        }

        // Método protegido (Protected Method) para invocar el evento
        protected virtual void OnCambioEstado(EventArgs e)
        {
            CambioEstado?.Invoke(this, e);
        }

        // Método anulado (Overridden method)
        public override void MostrarMensaje()
        {
            Console.WriteLine("Mensaje formal: " + _mensaje);
        }

        // Clase anidada (Nested class)
        [Serializable]
        public class DetalleMensaje
        {
            public string Descripcion { get; set; }
        }
    }

    // Clase derivada adicional para un mensaje informal
    [Serializable]
    public class MensajeInformal : MensajeBase, ISaludable
    {
        private readonly string _mensaje;

        public MensajeInformal(string mensaje)
        {
            _mensaje = mensaje;
        }

        public void Saludar()
        {
            Console.WriteLine("¡Hey! " + _mensaje);
        }

        public override void MostrarMensaje()
        {
            Console.WriteLine("Mensaje informal: " + _mensaje);
        }
    }

    class Program
    {
        static void Main()
        {
            // Crear instancias de MensajeFormal
            MensajeFormal mensaje1 = new MensajeFormal("Estimada Sra. Pérez");
            MensajeFormal mensaje2 = new MensajeFormal("Estimado Sr. López");

            // Usar el operador sobrecargado
            MensajeFormal mensajeCombinado = mensaje1 + mensaje2;

            // Mostrar mensajes
            mensaje1.MostrarMensaje();
            mensaje2.MostrarMensaje();
            mensajeCombinado.MostrarMensaje();

            // Manejar evento
            mensaje1.CambioEstado += (sender, e) =>
            {
                Console.WriteLine("El estado de visibilidad ha cambiado.");
            };

            mensaje1.Visible = true;

            // Crear instancia de MensajeInformal
            MensajeInformal mensaje3 = new MensajeInformal("¿Qué tal, Carlos?");
            mensaje3.MostrarMensaje();

            // Usar indexador
            Console.WriteLine("Primera letra del mensaje combinado: " + mensajeCombinado[0]);

            // Mostrar contador
            Console.WriteLine("Número de mensajes formales creados: " + MensajeFormal.Contador);

            // Parar y esperar a que se pulse una tecla
            Console.ReadKey();
        }
    }
}