using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;
using MVCSampleGrid.Data.DomainRepository;

namespace MVCSampleGrid.Business
{
    public interface IBL_OrderItem
    {
        IList<OrderItem> GetAll();
        OrderItem GetOrderItem(int id);   
        bool SaveOrderItem(OrderItem orderItem);
        bool DeleteOrderItem(int id);
    }
}
