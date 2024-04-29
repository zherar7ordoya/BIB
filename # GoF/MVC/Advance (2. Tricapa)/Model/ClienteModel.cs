using System.Collections.Generic;

namespace Model
{
    // Patrón de diseño Facade (Fachada)
    public class ClienteModel : ICRUD<Cliente>
    {
        // Arquitectura base
        private readonly ClienteAlta alta;
        private readonly ClienteBaja baja;
        private readonly ClienteModificacion modificacion;
        private readonly ClienteConsulta consulta;

        // Lógica de negocio
        private readonly ClienteSuma suma;
        private readonly ClienteResta resta;
        private readonly ClienteMultiplicacion multiplicacion;
        private readonly ClienteDivision division;

        public ClienteModel()
        {
            // Arquitectura base
            alta = new ClienteAlta();
            baja = new ClienteBaja();
            modificacion = new ClienteModificacion();
            consulta = new ClienteConsulta();

            // Lógica de negocio
            suma = new ClienteSuma();
            resta = new ClienteResta();
            multiplicacion = new ClienteMultiplicacion();
            division = new ClienteDivision();
        }

        //|||||||||||||||||||||||||||||||||||||||||||||||||||| ARQUITECTURA BASE

        public int Create(Cliente cliente) => alta.Create();
        public int Update(Cliente cliente) => modificacion.Update();
        public List<Cliente> ReadAll(string condicion) => consulta.ReadAll(condicion);
        public Cliente ReadById(int id) => consulta.ReadById(id);
        public int Delete(int id) => baja.Delete(id);

        //|||||||||||||||||||||||||||||||||||||||||||||||||||| LÓGICA DE NEGOCIO

        public int Sumar() => suma.Sumar();
        public int Restar() => resta.Restar();
        public int Multiplicar() => multiplicacion.Multiplicar();
        public int Dividir() => division.Dividir();
    }
}