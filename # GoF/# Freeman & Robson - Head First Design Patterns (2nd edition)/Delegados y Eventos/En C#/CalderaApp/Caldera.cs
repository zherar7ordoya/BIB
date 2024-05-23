using System;

namespace CalderaApp
{
    // Definición de los delegados
    public delegate void CambiarTemperaturaHandler(int cantidad);

    // Definición de la clase Caldera
    public class Caldera
    {
        // Propiedades
        public int Temperatura { get; private set; }

        // Eventos
        public event Action CalderaMuyCaliente;
        public event Action CalderaMuyFria;

        // Constructor
        public Caldera(int temperaturaInicial)
        {
            Temperatura = temperaturaInicial;
        }

        // Métodos para incrementar y decrementar la temperatura
        private void IncrementarTemperatura(int cantidad)
        {
            Temperatura += cantidad;
            VerificarTemperatura();
        }

        private void DecrementarTemperatura(int cantidad)
        {
            Temperatura -= cantidad;
            VerificarTemperatura();
        }

        // Delegados para cambiar la temperatura
        public CambiarTemperaturaHandler Incrementar { get; private set; }
        public CambiarTemperaturaHandler Decrementar { get; private set; }

        // Inicializar delegados en el constructor
        public Caldera()
        {
            Incrementar = new CambiarTemperaturaHandler(IncrementarTemperatura);
            Decrementar = new CambiarTemperaturaHandler(DecrementarTemperatura);
        }

        // Método para verificar la temperatura
        private void VerificarTemperatura()
        {
            if (Temperatura >= 100)
            {
                CalderaMuyCaliente?.Invoke();
            }
            else if (Temperatura <= 0)
            {
                CalderaMuyFria?.Invoke();
            }
        }
    }
}
