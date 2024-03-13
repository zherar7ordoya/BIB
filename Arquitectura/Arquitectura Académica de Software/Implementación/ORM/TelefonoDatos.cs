using Abstract;
using DataAccess;
using Structure;
using System;
using System.Collections.Generic;
using System.Data;


namespace ORM
{
    public class TelefonoDatos : ICRUD<TelefonoModelo>, IId
    {
        private readonly Comando _comando = new Comando();

        /** AYUDA-MEMORIA (PARA MÍ) *******************************************
         * Esto que ves aquí abajo, es un atributo (campo) y una propiedad que
         * están definidas, no por el nombre de la clase, sino por la interfaz
         * (propia) que implementan. Y en este caso, reciben como objeto a una
         * instancia de ClienteDatos (que implementa IId). Es por eso que se
         * puede acceder al método RetornaId() de la clase ClienteDatos. *** */

        // Pregunta: si estoy enviando los objetos completos, ¿necesito esto?
        //private IId _cliente;

        //public IId Cliente
        //{
        //    get => _cliente;
        //    set => _cliente = value;
        //}

        public int RetornaId()
        {
            return ((int)_comando
                .RetornaTablaCompleta("SELECT MAX(TelefonoId) FROM Telefono")
                .Rows[0]
                .ItemArray[0]) + 1;
        }

        public void Alta(TelefonoModelo telefono = null)
        {
            DataTable tabla = _comando.RetornaTablaEstructura("Telefono");

            /**
             * Las modificaciones que se hicieron aquí se deben a que, para
             * poder relacionar la tabla Cliente y Telefono, necesito que un
             * teléfono dado de alta contenga el id del cliente al que
             * pertenece. Sobre el RetornaId() aquí y en Cliente, véase las
             * notas al principio sobre la interfaz IId.
             */
            DataRow fila = tabla.NewRow();

            // Esto no está bien. Estoy enviando desde ModeloVista el objeto
            // Telefono completo, con su Id y con el Id del Cliente.
            fila.ItemArray = new object[]
            {
                //RetornaId(),            // <-- TelefonoId
                //_cliente.RetornaId(),   // <-- ClienteId
                telefono.Id,
                telefono.ClienteId,
                telefono.Numero,
                true
            };
            tabla.Rows.Add(fila);
            _comando.ActualizaBase("Telefono", tabla);
        }


        public void Baja(TelefonoModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }
        public void Modificacion(TelefonoModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }
        public List<TelefonoModelo> ConsultaObjeto(TelefonoModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }
        public List<TelefonoModelo> ConsultaRango(TelefonoModelo QueObjeto1 = null, TelefonoModelo QueObjeto2 = null)
        {
            throw new NotImplementedException();
        }
    }
}
