using System.Collections.Generic;

namespace Model
{
    // Facade Design Pattern (Fachada)
    public class ClienteModel : ICRUD<Cliente>
    {
        private readonly ClienteCRUD clienteCRUD;
        private readonly ClienteLogic clienteLogic;

        public ClienteModel()
        {
            clienteCRUD = new ClienteCRUD();
            clienteLogic = new ClienteLogic();
        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||| ARQUITECTURA BASE

        public int Create(Cliente cliente) => clienteCRUD.Create();
        public int Update(Cliente cliente) => clienteCRUD.Update();
        public List<Cliente> ReadAll(string condicion) => clienteCRUD.ReadAll(condicion);
        public Cliente ReadById(int id) => clienteCRUD.ReadById(id);
        public int Delete(int id) => clienteCRUD.Delete(id);

        //|||||||||||||||||||||||||||||||||||||||||||||||||||| LÓGICA DE NEGOCIO

        public int Sumar() => clienteLogic.Sumar();
        public int Restar() => clienteLogic.Restar();
        public int Multiplicar() => clienteLogic.Multiplicar();
        public int Dividir() => clienteLogic.Dividir();
    }
}