using Real.Application;

using System;
using System.Collections.Generic;

namespace Proxy.Application
{
    public class CustomerRepositoryProxy : IRepository
    {

        IRepository _real;

        public IList<Customer> GetAll()
        {
            if (_real == null) _real = new CustomerRepository();

            if (Session.CanGetAll) { return _real.GetAll(); }
            else
            {
                throw new UnauthorizedAccessException("El usuario no tiene acceso de lectura");
            }
        }

        public void Save(Customer customer)
        {
            if (_real == null) _real = new CustomerRepository();

            if (Session.CanSave) { _real.Save(customer); }
            else
            {
                throw new UnauthorizedAccessException("El usuario no tiene acceso de escritura");
            }
        }
    }
}
