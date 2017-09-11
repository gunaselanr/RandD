using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;
using MVCSampleGrid.Data.DomainRepository;
using MVCSampleGrid.Data.GenericRepository;

namespace MVCSampleGrid.Business
{
    public class BL_Customer:IBL_Customer
    {
        private ICustomerRepository _customerRepository;
        //private IGenericRepository<Customer> _customer;
        public BL_Customer()
        {
            _customerRepository = new CustomerRepository();            
        }

        public BL_Customer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IList<Customer> GetAll()
        {
            try
            {
                var lstCustomer = _customerRepository.GetAll(d=> d.Orders);
                return lstCustomer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                // Include Orders also with customer
                var customer = _customerRepository.GetSingle(c => c.Id == id, c => c.Orders);
                return customer;                                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveCustomer(Customer customer)
        {
            try
            {
                var isSaved = false;

                if (customer.Id == 0)
                {
                    isSaved = _customerRepository.Save(customer);
                }
                else
                {
                    isSaved = _customerRepository.Update(customer);
                }

                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                var customer = GetCustomer(id);
                var isDeleted = _customerRepository.Delete(customer);

                return isDeleted;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
