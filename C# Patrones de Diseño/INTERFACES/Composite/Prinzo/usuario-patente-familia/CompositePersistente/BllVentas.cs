using CompositePersistente.BE;

using System;

namespace CompositePersistente
{
    public class BllVentas
    {
        public void Facturar()
        {
            if (!SimuladorSesion.GetInstance.IsInRole(ETipoPermiso.PuedeHacerE)) throw new Exception("No tiene permisos");
        }
    }
}
