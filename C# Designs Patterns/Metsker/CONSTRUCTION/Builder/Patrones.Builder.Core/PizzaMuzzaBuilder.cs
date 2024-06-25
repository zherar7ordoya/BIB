﻿namespace Patrones.Builder.Core
{
    public class PizzaMuzzaBuilder : PizzaBuilder
    {
        public PizzaMuzzaBuilder()
        {
            _descripcion = "Pizza de Muzzarela";
        }
        public override Agregado BuildAgregado()
        {
            return new Oregano();
        }

        public override Masa BuildMasa()
        {
            return new AlMolde();
        }

        public override Salsa BuildSalsa()
        {
            return new Tomate();
        }
    }
}
