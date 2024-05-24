using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cap_10_DelegadosII
{
    internal class Refrigerador
    {
        //Aqui se declaran los delegados
        public delegate void ReservasDelegate(int pKilos);
        public delegate void DescongeladoDelegate(int pGrados);

        private int kilos = 0;
        private int grados = 0;

        //Variables que usan los delegados
        private ReservasDelegate reservasDelegate;
        private DescongeladoDelegate descongeladoDelegate;

        /// <summary>Gestión del refrigerador</summary>
        /// <param name="kilos">Peso cargado en el refrigerador</param>
        /// <param name="grados">Temperatura de trabajo del refrigerador</param>
        public Refrigerador(int kilos, int grados)
        {
            this.kilos = kilos;
            this.grados = grados;
        }
        public void AsignaMetodoReservas(ReservasDelegate metodo)
        {
            reservasDelegate = metodo;
        }
        public void AsignaMetodoDescongelado(DescongeladoDelegate metodo)
        {
            descongeladoDelegate = metodo;
        }
        //propiedades para controlar los atributos
        public int Kilos { get { return kilos; } }
        public int Grados { get { return grados; } }

        //metodo que simula el trabajo del refri
        public void Trabajar(int consumo)
        {
            kilos -= consumo;
            grados += 1;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0} kilos, {1} grados", kilos, grados);

            //Verificamos si se cumple la condicion de los delegados
            if (kilos < 10)
            {
                //Invocamos el delegado
                reservasDelegate(kilos);
            }
            if (grados > 0)
            {
                //Invocamos el delegado
                descongeladoDelegate(grados);
            }
        }
    }
}
