using System;

namespace VisitorVideo0
{
    public class VisitanteConcreto : IVisitor
    {
        public void Visitar(DiscoRigido componente)
        {
            Console.WriteLine(string.Format($"Disco Rigido Serial:\t{componente.Serial}"));
        }

        public void Visitar(PlacaBase componente)
        {
            Console.WriteLine(string.Format($"Placa Base Serial:\t{componente.Serial}"));
        }

        public void Visitar(Procesador componente)
        {
            Console.WriteLine(string.Format($"Procesador Serial:\t{componente.Serial}"));
        }
    }
}
