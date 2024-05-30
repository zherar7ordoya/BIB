using System.Collections.Generic;

namespace Modelo
{
    // Patrón de diseño Facade (Fachada)
    internal class ClienteDAO
    {
        //private readonly ClienteAgregar clienteAgregar;
        //private readonly ClienteBorrar clienteBorrar;
        //private readonly ClienteModificar clienteModificar;
        private readonly ClienteConsulta clienteConsultar;

        public ClienteDAO()
        {
            //clienteAgregar = new ClienteAgregar();
            //clienteBorrar = new ClienteBorrar();
            //clienteModificar = new ClienteModificar();
            clienteConsultar = new ClienteConsulta();
        }

        public void Agregar(Cliente cliente)
        {
            //clienteAgregar.Agregar(cliente);
        }

        public void Borrar(int id)
        {
            //clienteBorrar.Borrar(id);
        }

        public void Modificar(Cliente cliente)
        {
            //clienteModificar.Modificar(cliente);
        }

        public List<Cliente> Consultar(string condicion)
        {
            return clienteConsultar.Consultar(condicion);
        }
    }
}