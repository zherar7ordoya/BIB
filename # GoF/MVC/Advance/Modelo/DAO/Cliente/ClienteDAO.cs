using System.Collections.Generic;

namespace Modelo
{
    // Patrón de diseño Facade (Fachada)
    internal class ClienteDAO
    {
        //private readonly ClienteAgregar clienteAgregar;
        //private readonly ClienteBorrar clienteBorrar;
        //private readonly ClienteModificar clienteModificar;
        private readonly ClienteConsultar clienteConsultar;

        public ClienteDAO()
        {
            //clienteAgregar = new ClienteAgregar();
            //clienteBorrar = new ClienteBorrar();
            //clienteModificar = new ClienteModificar();
            clienteConsultar = new ClienteConsultar();
        }

        public void Agregar(ClienteDTO cliente)
        {
            //clienteAgregar.Agregar(cliente);
        }

        public void Borrar(int id)
        {
            //clienteBorrar.Borrar(id);
        }

        public void Modificar(ClienteDTO cliente)
        {
            //clienteModificar.Modificar(cliente);
        }

        public List<ClienteDTO> Consultar(string condicion)
        {
            return clienteConsultar.Consultar(condicion);
        }
    }
}