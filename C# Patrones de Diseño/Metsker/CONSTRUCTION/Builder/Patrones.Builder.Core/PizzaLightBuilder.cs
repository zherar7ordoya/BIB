﻿namespace Patrones.Builder.Core
{
    public class PizzaLightBuilder : PizzaBuilder
    {
        public PizzaLightBuilder()
        {
            _descripcion = "Pizza Light";
        }
        public override Agregado BuildAgregado()
        {
            return new Berenjenas();
        }

        public override Masa BuildMasa()
        {
            return new Integral();
        }

        public override Salsa BuildSalsa()
        {
            return new Light();
        }
    }
}
