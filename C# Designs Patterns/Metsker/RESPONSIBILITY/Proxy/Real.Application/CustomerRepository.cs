using System.Collections.Generic;

namespace Real.Application
{
    public class CustomerRepository : IRepository
    {
        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

        readonly IList<Customer> _customers;

        public IList<Customer> GetAll()
        {
            return _customers;
        }

        public void Save(Customer customer)
        {
            _customers.Add(customer);
        }
    }
}
