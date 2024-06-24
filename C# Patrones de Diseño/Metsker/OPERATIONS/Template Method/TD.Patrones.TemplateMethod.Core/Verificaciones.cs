using System.Collections.Generic;

namespace TD.PatronesTemplateMethod.Core
{
    public abstract class Verificaciones
    {
        protected Cliente _cliente;

        public string[] Verificar()
        {
            var mensajes = new List<string>
            {
                $"Verificando crédito para {_cliente.Nombre}",
                VerificarAcciones(),
                VerificarBalance(),
                VerificarCreditos(),
                VerificarIngresos()
            };
            return mensajes.ToArray();
        }

        protected abstract string  VerificarAcciones();
        protected abstract string VerificarBalance();
        protected abstract string VerificarCreditos();
        protected abstract string VerificarIngresos();
    }
}