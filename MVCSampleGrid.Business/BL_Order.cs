using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSampleGrid.Data;
using MVCSampleGrid.Data.DomainRepository;

namespace MVCSampleGrid.Business
{
    public class BL_Order:IBL_Order
    {
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        public BL_Order()
        {
            _orderRepository = new OrderRepository();
            _orderItemRepository = new OrderItemRepository();
        }

        public BL_Order(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IList<Order> GetAll()
        {
            try
            {
                var lstOrder = _orderRepository.GetAll(o => o.OrderItems, o => o.Customer);
                return lstOrder;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Order GetOrder(int id)
        {
            try
            {
                // Include Orders also with OrderItems
                var Order = _orderRepository.GetSingle(c => c.Id == id, c => c.OrderItems, 
                    c => c.OrderItems.Select(p => p.Product), c => c.Customer);
                return Order;                                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SaveOrder(Order Order)
        {
            try
            {
                var isSaved = false;

                if (Order.Id == 0)
                {
                    isSaved = _orderRepository.Save(Order);
                }
                else
                {
                    var orderItems = _orderItemRepository.GetList(oi => oi.OrderId == Order.Id);
                    foreach (var item in orderItems)
                    {
                        _orderItemRepository.Delete(item);
                    }

                    foreach (var item in Order.OrderItems)
                    {
                        _orderItemRepository.Save(item);
                    }

                    isSaved = _orderRepository.Update(Order);
                }

                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteOrder(int id)
        {
            try
            {
                var Order = GetOrder(id);
                var isDeleted = _orderRepository.Delete(Order);

                return isDeleted;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
