using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;//para usar arraylist

namespace cap_07_Interfaz_callBack
{
    internal class CRefri
    {
        //aqui guardamos todos los sink con los que se comunica refri
        private ArrayList listaSinks = new ArrayList();

        private int kilosAlimentos = 0;
        private int grados = 0;

        //constructor
        public CRefri(int pKilos, int pGrados)
        {
            //asignar los valores iniciales del refri
            kilosAlimentos = pKilos;
            grados = pGrados;
        }

        // adicionar un sink a la lista
        public void AgregarSink(IEventoRefri pSink)
        {
            if (pSink != null)
                listaSinks.Add(pSink);
        }
        //eliminar un sink de la lista
        public void EliminarSink(IEventoRefri pSink)
        {
            if (listaSinks.Contains(pSink))
                listaSinks.Remove(pSink);
        }
        //propiedades necesarias
        public int Kilos { get { return kilosAlimentos; } }
        public int Grados { get { return grados; } }

        public void Trabajar(int pConsumo)
        {
            //actualizar los kilos del refri
            kilosAlimentos -= pConsumo;

            //subir la temperatura
            grados += 1;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0} kilos, {1} grados", kilosAlimentos, grados);

            //verificar si hay que enviar notificacion
            if (kilosAlimentos < 10)
            {
                //recorrer la lista de sinks y notificar la situacion
                foreach (IEventoRefri handler in listaSinks)
                {
                    handler.EReservasBajas(kilosAlimentos);
                }
            }
        }
    }
}
