namespace Patrones.Strategy.Core
{
    public abstract class Arma
    {
        public abstract string Disparar();

        // Ahhh... de aquí sale el nombre del arma...
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
