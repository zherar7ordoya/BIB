using System;

namespace Patrones.Strategy.Core
{
    public class Jugador
    {
        Arma _arma;

        // Originalmente, este método se llamaba "CambiarEstrategia".
        public void CambiarArma(Arma arma)
        {
            _arma = arma ?? throw new Exception("La estrategia de disparo no puede ser null");
        }

        public string Nombre { get; set; }

        public string Disparar()
        {
            if (_arma == null) return "Arma no seleccionada";
            return _arma.Disparar();
        }
    }
}
