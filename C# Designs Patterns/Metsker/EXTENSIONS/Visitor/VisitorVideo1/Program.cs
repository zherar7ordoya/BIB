using System;

namespace VisitorVideo1
{
    class Program
    {
        static void Main(string[] args)
        {

            IVisitor visitante2 = new VisitanteConcreto2();

            IVisitor visitante = new VisitanteConcreto();

            Componente dr = new DiscoRigido("1231DSFFSD3-DR");
            Componente pb = new PlacaBase("dkk3nndj12313-PB");
            Componente p = new Procesador("9393SKKK4K3-P");


            dr.Aceptar(visitante);
            pb.Aceptar(visitante);
            p.Aceptar(visitante);


            dr.Aceptar(visitante2);
            pb.Aceptar(visitante2);
            p.Aceptar(visitante2);

            Console.ReadKey();
        }
    }
}
