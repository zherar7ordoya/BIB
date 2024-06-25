using CompositePersistente.BE;

using System;

namespace CompositePersistente
{
    public class BllVentas
    {
        public void Facturar()
        {
            if (!SimuladorSesion.GetInstance.ExistInRole(ETipoPermiso.PuedeHacerE)) throw new Exception("No tiene permisos");
        }
    }
}
