using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;
using MVCSampleGrid.Data.DomainRepository;

namespace MVCSampleGrid.Business
{
    public interface IBL_Customer
    {
        IList<Customer> GetAll();
        Customer GetCustomer(int id);
        bool SaveCustomer(Customer customer);
        bool DeleteCustomer(int id);
    }
}
