namespace TD.PatronesTemplateMethod.Core
{
    public class CreditoPersonal : Credito
    {
        public CreditoPersonal(Cliente cliente) : base(cliente)
        {
        }

        protected override string VerificarAcciones()
        {
          return "No es requerido verificar acciones para un crédito personal";
        }

        protected override string VerificarBalance()
        {
             return "Verificando balance bancario para un prestamo personal";
        }

        protected override string VerificarCreditos()
        {
            return "Verificando otros creditos para para un prestamo personal";
        }

        protected override string VerificarIngresos()
        {
            return "Verificando ingresos para asignar un prestamo personal";
        }
    }
}