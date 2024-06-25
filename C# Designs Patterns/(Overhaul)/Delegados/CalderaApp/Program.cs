using System;


public delegate void CalderaEventHandler(string mensaje);


public class Caldera
{
    // Definir el delegado
    public CalderaEventHandler OnTemperaturaCritica;

    private int _temperatura;
    private const int MaxTemp = 100;
    private const int MinTemp = 0;

    public int Temperatura
    {
        get { return _temperatura; }
        set
        {
            _temperatura = value;
            if (_temperatura >= MaxTemp)
            {
                // Notificar que la caldera está muy caliente
                OnTemperaturaCritica?.Invoke("¡Alerta! La caldera está demasiado caliente.");
            }
            else if (_temperatura <= MinTemp)
            {
                // Notificar que la caldera está muy fría
                OnTemperaturaCritica?.Invoke("¡Alerta! La caldera está demasiado fría.");
            }
        }
    }

    public void SubirTemperatura(int incremento)
    {
        Temperatura += incremento;
    }

    public void BajarTemperatura(int decremento)
    {
        Temperatura -= decremento;
    }
}


public class Program
{
    public static void Main()
    {
        // Crear instancia de Caldera
        Caldera miCaldera = new Caldera();

        // Suscribir el método manejador de eventos al delegado
        miCaldera.OnTemperaturaCritica += MensajeDeAlerta;

        // Ajustar la temperatura para disparar los eventos
        Console.WriteLine("Subiendo la temperatura...");
        miCaldera.SubirTemperatura(105); // Esto debe disparar la alerta de temperatura alta

        Console.WriteLine("Bajando la temperatura...");
        miCaldera.BajarTemperatura(110); // Esto debe disparar la alerta de temperatura baja

        Console.ReadKey();
    }

    // Método manejador de eventos
    public static void MensajeDeAlerta(string mensaje)
    {
        Console.WriteLine(mensaje);
    }
}
