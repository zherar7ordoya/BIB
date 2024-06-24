using System;

namespace State
{
    public class Switch
    {
        public Switch()
        {
            _estado = new Encendido();
        }

        Estado _estado;

        public void DefinirEstado(Estado estado)
        {
            _estado = estado;
        }
       
        public void PulsarBoton()
        {
            _estado.CambiarEstado(this);
           Console.WriteLine(_estado.InformarEstado());
        }
    }
}
