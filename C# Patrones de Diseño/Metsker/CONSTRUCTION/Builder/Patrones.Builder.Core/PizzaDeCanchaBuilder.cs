﻿namespace Patrones.Builder.Core
{
    public class PizzaDeCanchaBuilder : PizzaBuilder
    {

        public PizzaDeCanchaBuilder()
        {
            _descripcion = "Pizza de cancha";
        }
        public override Agregado BuildAgregado()
        {
           return new Anchoas();
        }

        public override Masa BuildMasa()
        {
            return new Integral();
        }

        public override Salsa BuildSalsa()
        {
            return new AjoAlOleo();
        }
    }
}
