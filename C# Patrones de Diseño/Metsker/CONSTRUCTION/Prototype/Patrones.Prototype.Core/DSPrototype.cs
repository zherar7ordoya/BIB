namespace Patrones.Prototype.Core
{
    public class DSPrototype : AutoPrototype
    {
        public override AutoPrototype Clonar()
        {
            return (DSPrototype)MemberwiseClone();
        }

        public override string VerAuto()
        {
            return $"DS {_modelo}\t(color {_color})";
        }
    }
}
