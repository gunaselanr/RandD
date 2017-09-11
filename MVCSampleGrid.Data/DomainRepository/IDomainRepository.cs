using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data.GenericRepository;

namespace MVCSampleGrid.Data.DomainRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
    public interface IOrderRepository : IGenericRepository<Order>
    { }
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    { }
    public interface ISupplierRepository : IGenericRepository<Supplier>
    { }
    public interface ITech_CompanyRepository : IGenericRepository<Tech_Company>
    { }
    public interface IEmployeeRepository : IGenericRepository<Employee>
    { }
}
