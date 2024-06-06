using System;

namespace CompositeSistemaDeArchivos
{
    public static class DibujadorDeJerarquia
    {
        public static void Dibujar(Componente componente, string indent = "")
        {
            Console.WriteLine($"{indent}- {componente.Nombre} (Tamaño: {componente.Tamaño})");
            var hijos = componente.ObtenerHijos();
            if (hijos != null)
            {
                foreach (var hijo in hijos)
                {
                    Dibujar(hijo, indent + "\t");
                }
            }
        }
    }
}
