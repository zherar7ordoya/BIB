using System;
using System.Collections.Generic;

namespace MasterClass
{
    public class EstadisticasJugador
    {
        public string Nombre { get; set; }
        public int Asesinatos { get; set; }
        public int Muertes { get; set; }
        public int BanderasCapturadas { get; set; }
    }

    internal class Program
    {
        delegate int CalcularPuntaje(EstadisticasJugador estadisticas);

        static void Main()
        {
            MostrarGanadores();
            Console.ReadKey();
        }

        private static void MostrarGanadores()
        {
            var jugadores = new List<EstadisticasJugador>
            {
                new EstadisticasJugador { Nombre = "Jugador 1", Asesinatos = 10, Muertes = 5, BanderasCapturadas = 3 },
                new EstadisticasJugador { Nombre = "Jugador 2", Asesinatos = 5, Muertes = 10, BanderasCapturadas = 1 },
                new EstadisticasJugador { Nombre = "Jugador 3", Asesinatos = 7, Muertes = 7, BanderasCapturadas = 2 },
                new EstadisticasJugador { Nombre = "Jugador 4", Asesinatos = 8, Muertes = 8, BanderasCapturadas = 4 }
            };

            Program prog = new Program();

            string JugadorMasAsesinatos = prog.ObtenerGanador(jugadores.ToArray(), x => x.Asesinatos);
            string JugadorMasMuertes = prog.ObtenerGanador(jugadores.ToArray(), x => x.Muertes);
            string JugadorMasBanderas = prog.ObtenerGanador(jugadores.ToArray(), x => x.BanderasCapturadas);

            Console.WriteLine($"Jugador con más asesinatos: {JugadorMasAsesinatos}");
            Console.WriteLine($"Jugador con más muertes: {JugadorMasMuertes}");
            Console.WriteLine($"Jugador con más banderas capturadas: {JugadorMasBanderas}");
        }

        string ObtenerGanador(IEnumerable<EstadisticasJugador> estadisticas, CalcularPuntaje calculadora)
        {
            string nombre = string.Empty;
            int mejorPuntaje = 0;

            foreach (EstadisticasJugador estadistica in estadisticas)
            {
                int puntaje = calculadora(estadistica);
                if (puntaje > mejorPuntaje)
                {
                    mejorPuntaje = puntaje;
                    nombre = estadistica.Nombre;
                }
            }
            return nombre;
        }

    }
}
