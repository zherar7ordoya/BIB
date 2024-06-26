namespace PatrónAdapter_CSharp
{
    /// <summary>
    /// Anteriormente, ésta era una clase abstracta.
    /// </summary>
    public interface IMotor
    {
        string Acelerar();
        string Arrancar();
        string Detener();
        string CargarCombustible();
    }
}
