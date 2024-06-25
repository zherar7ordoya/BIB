namespace Patrones.Prototype.Core
{
    public class AlfaRomeoPrototype : AutoPrototype
    {
        public override AutoPrototype Clonar()
        {
            return (AlfaRomeoPrototype)MemberwiseClone();
        }

        public override string VerAuto()
        {
            return $"Alfa Romeo {_modelo}\t(color {_color})";
        }
    }
}
