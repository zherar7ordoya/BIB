using Abstract;
using ORM;
using Structure;
using System;
using System.Collections.Generic;


namespace Logic
{
    public class ClienteLogica : ICRUD<ClienteModelo>
    {
        readonly ClienteDatos _clienteDatos = new ClienteDatos();
        readonly TelefonoDatos _telefonoDatos = new TelefonoDatos();


        public int RetornaClienteId() { return _clienteDatos.RetornaId(); }
        public int RetornaTelefonoId() { return _telefonoDatos.RetornaId(); }


        public void Alta(ClienteModelo cliente = null) { _clienteDatos.Alta(cliente); }


        public void Baja(ClienteModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }
        public void Modificacion(ClienteModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }
        public List<ClienteModelo> ConsultaObjeto(ClienteModelo QueObjeto = null)
        {
            throw new NotImplementedException();
        }
        public List<ClienteModelo> ConsultaRango(ClienteModelo QueObjeto1 = null, ClienteModelo QueObjeto2 = null)
        {
            throw new NotImplementedException();
        }
    }
}
