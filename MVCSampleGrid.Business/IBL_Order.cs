using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;
using MVCSampleGrid.Data.DomainRepository;

namespace MVCSampleGrid.Business
{
    public interface IBL_Order
    {
        IList<Order> GetAll();
        Order GetOrder(int id);   
        bool SaveOrder(Order order);
        bool DeleteOrder(int id);
    }
}
