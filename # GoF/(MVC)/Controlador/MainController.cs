using Modelo;
using Modelo.EF;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class MainController
    {
        public IEnumerable<ClienteViewModel> GetList()
        {
            using (FinalEntities datos = new FinalEntities())
            {
                IEnumerable<ClienteViewModel> lista = 
                    from x in datos.Clientes
                    select new ClienteViewModel
                    {
                        Codigo = x.Codigo,
                        Nombre = x.Nombre
                    };
                return lista.ToList();
            }
        }
    }
}
