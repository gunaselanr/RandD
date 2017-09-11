using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;
using MVCSampleGrid.Data.DomainRepository;

namespace MVCSampleGrid.Business
{
    public class BL_OrderItem:IBL_OrderItem
    {
        private IOrderItemRepository _orderItemsRepository;
        public BL_OrderItem()
        {
            _orderItemsRepository = new OrderItemRepository();
        }

        public BL_OrderItem(IOrderItemRepository orderItemRepository)
        {
            _orderItemsRepository = orderItemRepository;
        }

        public IList<OrderItem> GetAll()
        {
            try
            {
                var lstOrderItem = _orderItemsRepository.GetAll(o => o.Product);
                return lstOrderItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public OrderItem GetOrderItem(int id)
        {
            try
            {
                // Include OrderItems also with products
                var orderItem = _orderItemsRepository.GetSingle(c => c.Id == id, c => c.Product);
                return orderItem;                                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveOrderItem(OrderItem orderItem)
        {
            try
            {
                var isSaved = false;

                if (orderItem.Id == 0)
                {
                    isSaved = _orderItemsRepository.Save(orderItem);
                }
                else
                {
                    isSaved = _orderItemsRepository.Update(orderItem);
                }

                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteOrderItem(int id)
        {
            try
            {
                var orderItem = GetOrderItem(id);
                var isDeleted = _orderItemsRepository.Delete(orderItem);

                return isDeleted;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
