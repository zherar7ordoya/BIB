using System;

namespace PatrónAdapter_CSharp
{
    public class MotorElectrico
    {
        bool _conectado;
        bool _activo;
        bool _moviendo;

        public string Conectar()
        {
            if (_conectado) return "Imposible conectar un motor electrico ya conectado!";
            else
            {
                _conectado = true;
                return "Motor conectado!";
            }
        }

        public string Activar()
        {

            if (!_conectado) return "Imposible activar un motor no conectado";
            else
            {
                _activo = true;
                return "Motor activado!";
            }
        }

        public string Mover()
        {
            if (_conectado && _activo)
            {
                _moviendo = true;
                return "Moviendo vehiculo con motor eléctrico...";
            }
            else { return "El motor deberá estar conectado y activo!"; }
        }

        public string Parar()
        {

            if (_moviendo)
            {
                _moviendo = false;
                return "Parando vehiculo con motor eléctrico...";
            }
            else { return "Imposible parar un motor que no esté en movimiento!"; }
        }

        public string Desconectar()
        {
            if (_conectado) return "Motor desconectado...";
            else { return "Imposible desconectar un motor que no esté conectado!"; }
        }

        public string Desactivar()
        {
            if (_activo)
            {
                _activo = false;
                return "Motor desactivado...";
            }
            else { return "Imposible desactivar un motor que no esté activo!"; }
        }

        public string Enchufar()
        {
            if (!_activo)
            {
                _activo = false;
                return "Motor cargando las baterias!...";
            }
            else { return "Imposible enchufar un motor activo!"; }
        }
    }
}
