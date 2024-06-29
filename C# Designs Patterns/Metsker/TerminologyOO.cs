class Persona
{
    // Miembro de datos de instancia (estado)
    // También llamados: atributos de instancia o variables de objeto.
    private string nombre;

    // Miembro de datos de clase (constante)
    // También llamados: atributos de clase o variables de clase.
    public const int NUMERO_PIERNAS = 2;

    // Método de instancia (comportamiento)
    // También llamados: métodos de objeto.
    public void Saludar()
    {
        Console.WriteLine($"Hola, mi nombre es {nombre}");
    }

    // Método de clase (operación general)
    // También llamados: métodos estáticos.
    public static int CalcularPoblacionTotal(Persona[] personas)
    {
        int poblacionTotal = 0;
        foreach (Persona persona in personas)
        {
            poblacionTotal++;
        }
        return poblacionTotal;
    }
}