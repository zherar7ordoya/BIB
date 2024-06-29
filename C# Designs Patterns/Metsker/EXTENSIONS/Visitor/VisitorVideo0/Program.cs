using System;

namespace VisitorVideo0
{
    class Program
    {
        static void Main(string[] args)
        {
            IVisitor visitante = new VisitanteConcreto();

            Componente disco = new DiscoRigido("1231DSFFSD3-DR");
            Componente placa = new PlacaBase("dkk3nndj12313-PB");
            Componente procesador = new Procesador("9393SKKK4K3-P");

            disco.Aceptar(visitante);
            placa.Aceptar(visitante);
            procesador.Aceptar(visitante);

            Console.ReadKey();
        }
    }
}
