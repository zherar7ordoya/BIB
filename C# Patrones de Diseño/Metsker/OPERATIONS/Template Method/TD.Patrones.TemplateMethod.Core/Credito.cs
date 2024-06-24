
namespace TD.PatronesTemplateMethod.Core
{
    public abstract class Credito : Verificaciones
    {
        public Credito(Cliente cliente)
        {
            _cliente = cliente;
        }

        protected abstract  override string VerificarAcciones();
        protected abstract  override string VerificarBalance();
        protected abstract  override string VerificarIngresos();
        protected abstract  override string VerificarCreditos();
    }
}