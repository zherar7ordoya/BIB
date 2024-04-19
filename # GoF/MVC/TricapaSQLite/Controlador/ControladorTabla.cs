using Modelo;

using System.Data;

namespace Controlador
{
    public class ControladorTabla
    {
        private DatosTabla datosTabla;

        public ControladorTabla()
        {
            datosTabla = new DatosTabla();
        }

        public DataTable ObtenerDatosTabla()
        {
            return datosTabla.ObtenerDatosTabla();
        }
    }
}
