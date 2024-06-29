using System;

namespace VisitorVideo1
{
    public class VisitanteConcreto : IVisitor
    {
        public void Visitar(string serie)
        {
            Console.WriteLine(string.Format("S/N => {0}", serie));
        }

    }

    public class VisitanteConcreto2 : IVisitor
    {
        public void Visitar(string serie)
        {
            Console.WriteLine(string.Format("El número de serie es: {0}", serie));
        }
    }
}
