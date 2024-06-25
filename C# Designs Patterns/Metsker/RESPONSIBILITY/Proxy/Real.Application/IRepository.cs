using System.Collections.Generic;

namespace Real.Application
{
    public interface IRepository
    {
        IList<Customer> GetAll();
        void Save(Customer customer);
    }
}
