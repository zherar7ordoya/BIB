# Patrones C# con Delegados

En el libro "Design Patterns: Elements of Reusable Object-Oriented Software" por la "Gang of Four" (GoF), varios patrones de diseño pueden beneficiarse del uso de delegados y eventos en su implementación en C#. Sin embargo, algunos patrones son particularmente adecuados para aprovechar estas características del lenguaje. A continuación se presentan algunos patrones de diseño que pueden utilizar delegados y eventos en C#:

1. **Observer (Observador)**:
   - Este patrón define una relación de uno a muchos entre objetos, de manera que cuando un objeto cambia de estado, todos sus dependientes son notificados y actualizados automáticamente. En C#, esto se implementa frecuentemente utilizando eventos y delegados.
   ```csharp
   public class Subject
   {
       public event EventHandler StateChanged;

       private int _state;
       public int State
       {
           get { return _state; }
           set
           {
               if (_state != value)
               {
                   _state = value;
                   OnStateChanged(EventArgs.Empty);
               }
           }
       }

       protected virtual void OnStateChanged(EventArgs e)
       {
           StateChanged?.Invoke(this, e);
       }
   }

   public class Observer
   {
       public void Subscribe(Subject subject)
       {
           subject.StateChanged += Update;
       }

       private void Update(object sender, EventArgs e)
       {
           // Handle the event (update the observer state)
       }
   }
   ```

2. **Command (Comando)**:
   - Este patrón encapsula una solicitud como un objeto, permitiendo parametrizar a los clientes con diferentes solicitudes, hacer encolamiento o registro de las solicitudes, y soportar operaciones que se pueden deshacer. Los delegados en C# se pueden utilizar para implementar los comandos.
   ```csharp
   public delegate void Command();

   public class CommandInvoker
   {
       private Command _command;

       public CommandInvoker(Command command)
       {
           _command = command;
       }

       public void Execute()
       {
           _command();
       }
   }

   public class Client
   {
       public void Run()
       {
           Command myCommand = new Command(SomeMethod);
           CommandInvoker invoker = new CommandInvoker(myCommand);
           invoker.Execute();
       }

       public void SomeMethod()
       {
           // Perform some action
       }
   }
   ```

3. **Mediator (Mediador)**:
   - Este patrón define un objeto que encapsula cómo un conjunto de objetos interactúa. Los delegados y eventos pueden ser útiles para implementar la comunicación entre componentes sin que se refieran directamente entre sí.
   ```csharp
   public class Mediator
   {
       public event EventHandler<ComponentEventArgs> ComponentChanged;

       public void Notify(object sender, ComponentEventArgs e)
       {
           ComponentChanged?.Invoke(sender, e);
       }
   }

   public class ComponentEventArgs : EventArgs
   {
       public string Message { get; set; }
   }

   public class Component
   {
       private Mediator _mediator;

       public Component(Mediator mediator)
       {
           _mediator = mediator;
           _mediator.ComponentChanged += OnComponentChanged;
       }

       public void Change()
       {
           _mediator.Notify(this, new ComponentEventArgs { Message = "Component Changed" });
       }

       private void OnComponentChanged(object sender, ComponentEventArgs e)
       {
           // Handle the event
       }
   }
   ```

Estos son algunos ejemplos de patrones de diseño de GoF que pueden implementar delegados y eventos en C#. La utilización de estos elementos del lenguaje permite una implementación más limpia y desacoplada, facilitando la comunicación y coordinación entre los diferentes componentes del sistema.