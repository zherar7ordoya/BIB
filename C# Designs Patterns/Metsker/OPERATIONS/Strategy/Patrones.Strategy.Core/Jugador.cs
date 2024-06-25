using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Strategy.Core
{
    public class Jugador
    {
        Arma _estrategia;
        public void CambiarEstrategia(Arma estrategia)
        {
            if (estrategia == null) throw new Exception("La estrategia de disparo no puede ser null");
            _estrategia = estrategia;
        }

        public string Nombre { get; set; }

        public string Disparar()
        {
            if (_estrategia == null) return "Arma no disponible";
            return _estrategia.Disparar();
        }
    }
}
