using Model;

namespace Controller
{
    internal class ClienteMetodo
    {
        public static int Sumar()
        {
            ClienteModel cliente = new ClienteModel();
            return cliente.Sumar();
        }

        public static int Restar()
        {
            ClienteModel cliente = new ClienteModel();
            return cliente.Restar();
        }

        public static int Multiplicar()
        {
            ClienteModel cliente = new ClienteModel();
            return cliente.Multiplicar();
        }

        public static int Dividir()
        {
            ClienteModel cliente = new ClienteModel();
            return cliente.Dividir();
        }
    }
}
