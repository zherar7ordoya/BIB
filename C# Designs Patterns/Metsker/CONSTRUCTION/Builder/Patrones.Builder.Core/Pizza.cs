namespace Patrones.Builder.Core
{
    public class Pizza
    {
        private readonly Masa _masa;
        private readonly Salsa _salsa;
        private readonly Agregado _agregado;
        private readonly string _tipo;

        public override string ToString()
        {
            return $"{_tipo}, Masa: {_masa.Descripcion}, Salsa: {_salsa.Descripcion}, Agregado: {_agregado.Descripcion}";
        }

        public Pizza(Masa masa, Salsa salsa, Agregado agregado, string tipo)
        {
            _masa = masa;
            _salsa = salsa;
            _agregado = agregado;
            _tipo = tipo;
        }
    }
}
