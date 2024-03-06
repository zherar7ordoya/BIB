using Abstract;
using DataAccess;
using Structure;
using System;
using System.Collections.Generic;
using System.Data;


namespace ORM
{
    public class ClienteDatos : ICRUD<ClienteModelo>, IId
    {
        private readonly Comando _comando = new Comando();
        private readonly TelefonoDatos _telefonoDatos = new TelefonoDatos();


        public int RetornaId()
        {
            return ((int)_comando
                .RetornaTablaCompleta("SELECT MAX(ClienteId) FROM Cliente")
                .Rows[0]
                .ItemArray[0]) + 1;
        }


        public void Alta(ClienteModelo cliente = null)
        {
            /**
             * Para ver una explicación de la redundancia de un "tabla.NewRow"
             * y el posterior "tabla.Rows.Add", ver:
             * https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/dataset-datatable-dataview/adding-data-to-a-datatable
             */
            try
            {
                DataTable tabla = _comando.RetornaTablaEstructura("Cliente");
                DataRow fila = tabla.NewRow();

                /**
                 * ¿Por qué le tengo que pasar el Id del cliente si, por
                 * ejemplo, es autoincremental en la base de datos?: I don't
                 * think that it's possible to trigger the AutoIncrement
                 * functionality when the rows are already in the table.
                 * https://stackoverflow.com/a/16179861/14009797
                 */
                // Esto no está bien. Ya estoy enviando el objeto Cliente, 
                // desde ClienteVista, completo, con su Id.
                //int clienteId = RetornaId();

                fila.ItemArray = new object[]
                {
                    cliente.Id,
                    cliente.Nombre,
                    cliente.FechaAlta,
                    cliente.Activo
                };

                tabla.Rows.Add(fila);
                _comando.ActualizaBase("Cliente", tabla);

                if (cliente.Telefonos.Count > 0)
                {
                    // Al enviar los objetos completos, ¿necesito esto?
                    //_telefonoDatos.Cliente = cliente;

                    foreach (TelefonoModelo telefono in cliente.Telefonos)
                    {
                        _telefonoDatos.Alta(telefono);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }


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
