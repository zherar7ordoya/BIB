using System;

namespace DemoLibrary
{
    public class SobregiroEventArgs : EventArgs
    {
        public decimal MontoSobregirado { get; private set; }
        public string MasInformacion { get; private set; }
        public bool CancelarTransaccion { get; set; } = false;

        public SobregiroEventArgs(decimal montoSobregirado, string masInformacion)
        {
            MontoSobregirado = montoSobregirado;
            MasInformacion = masInformacion;
        }
    }
}
