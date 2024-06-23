namespace Patrones.Prototype.Core
{
    public class FiatPrototype : AutoPrototype
    {
        public override AutoPrototype Clonar()
        {
            return (FiatPrototype)MemberwiseClone();
        }

        public override string VerAuto()
        {
            return $"Fiat {_modelo}\t(color {_color})";
        }
    }
}
