using System;
using System.Collections.Generic;

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
    public string Sender { get; set; }
    public string Recipient { get; set; }
}

public class ChatRoom : Mediator
{
    private readonly List<User> _users = new List<User>();

    public void Register(User user)
    {
        _users.Add(user);
        user.SetMediator(this);
    }

    public void Send(string message, User sender, string recipient)
    {
        Notify(sender, new ComponentEventArgs
        {
            Message = message,
            Sender = sender.Name,
            Recipient = recipient
        });
    }
}

public abstract class User
{
    protected Mediator _mediator;

    public User(Mediator mediator)
    {
        _mediator = mediator;
    }

    public void SetMediator(Mediator mediator)
    {
        _mediator = mediator;
        _mediator.ComponentChanged += OnComponentChanged;
    }

    public void Send(string message, string recipient)
    {
        _mediator.Notify(this, new ComponentEventArgs
        {
            Message = message,
            Sender = Name,
            Recipient = recipient
        });
    }

    protected abstract void OnComponentChanged(object sender, ComponentEventArgs e);

    public abstract string Name { get; }
}

public class ConcreteUser : User
{
    public override string Name { get; }

    public ConcreteUser(string name, Mediator mediator) : base(mediator)
    {
        Name = name;
    }

    /*
    SOBRE EL IF:

    La combinación de estas dos partes (de condiciones) significa que el usuario
    recibirá el mensaje si el mensaje es un mensaje de difusión (sin destinatario
    específico) o si el nombre del destinatario coincide con el nombre del usuario
    actual.

    sender != this: Esta condición verifica si el remitente del evento (el que
    envió el mensaje) no es el mismo objeto que está manejando el evento. En
    otras palabras, un componente no debería recibir su propio mensaje.

    string.IsNullOrEmpty(e.Recipient): Verifica si el campo Recipient está vacío
    o es nulo. Si es así, significa que el mensaje está destinado a todos los
    usuarios (un mensaje de difusión).

    e.Recipient == Name: Verifica si el destinatario del mensaje es este usuario
    específico (Name es la propiedad que almacena el nombre del usuario).
    */
    protected override void OnComponentChanged(object sender, ComponentEventArgs e)
    {
        if (sender != this
            && (string.IsNullOrEmpty(e.Recipient) || e.Recipient == Name))
        {
            Console.WriteLine(
                $"{Name} received message from {e.Sender}: " +
                $"{e.Message}");
        }
    }

    public void SendMessage(string message, string recipient)
    {
        if (string.IsNullOrEmpty(recipient))
        {
            Console.WriteLine($"{Name} sends message to everyone: {message}");
        }
        else
        {
            Console.WriteLine($"{Name} sends message to {recipient}: {message}");
        }
        Send(message, recipient);
    }
}

class Program
{
    static void Main()
    {
        ChatRoom chatRoom = new ChatRoom();

        ConcreteUser user1 = new ConcreteUser("Alice", chatRoom);
        ConcreteUser user2 = new ConcreteUser("Bob", chatRoom);
        ConcreteUser user3 = new ConcreteUser("Charlie", chatRoom);

        chatRoom.Register(user1);
        chatRoom.Register(user2);
        chatRoom.Register(user3);

        user1.SendMessage("Hello, Bob!", "Bob");
        user2.SendMessage("Hi Alice!", "Alice");
        user3.SendMessage("Hey Bob and Alice!", null); // Sending to everyone

        Console.ReadKey();
    }
}
