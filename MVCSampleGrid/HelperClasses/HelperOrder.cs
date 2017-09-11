using MVCSampleGrid.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSampleGrid.HelperClasses
{
    public class HelperOrder
    {
        private BL_Order objBLOrder = new BL_Order();
        private BL_Product objBLProduct = new BL_Product();

        public List<Models.Order> GetAllOrder()
        {
            var dataOrder = objBLOrder.GetAll();
            var modOrder = dataOrder.Select(s => new Models.Order()
            {
                Id = s.Id,
                CustomerId = s.CustomerId,
                OrderDate = s.OrderDate,
                OrderNumber = s.OrderNumber,
                TotalAmount = s.TotalAmount,
                Customer = new Models.Customer() { Id = s.Customer.Id, FirstName = s.Customer.FirstName, LastName = s.Customer.LastName },
                OrderItems = s.OrderItems.Select(o => new Models.OrderItem()
                {
                    OrderId = o.OrderId,
                    ProductId = o.ProductId,
                    Quantity = o.Quantity,
                    UnitPrice = o.UnitPrice
                }).ToList()
            }).OrderByDescending(o=>o.Id).ToList();

            return modOrder;
        }

        public Models.Order GetOrderById(int id)
        {
            Models.Order modOrder = new Models.Order();
            var dataOrder = objBLOrder.GetOrder(id);

            modOrder.Id = dataOrder.Id;
            modOrder.CustomerId = dataOrder.CustomerId;
            modOrder.OrderDate = dataOrder.OrderDate;
            modOrder.OrderNumber = dataOrder.OrderNumber;
            modOrder.TotalAmount = dataOrder.TotalAmount;
            modOrder.Customer = new Models.Customer() { Id = dataOrder.Customer.Id, FirstName = dataOrder.Customer.FirstName, LastName = dataOrder.Customer.LastName };
            modOrder.OrderItems = dataOrder.OrderItems.Select(o => new Models.OrderItem()
            {
                Id = o.Id,
                OrderId = o.OrderId,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                UnitPrice = o.UnitPrice,
                Amount = Convert.ToDecimal(o.Quantity * o.UnitPrice),
                Product = new Models.Product()
                {
                    ProductName = o.Product != null ? o.Product.ProductName : string.Empty,
                    Id = o.Product != null ? o.Product.Id : 0
                }
            }).ToList();


            return modOrder;
        }

        public bool SaveOrder(Models.Order modOrder)
        {
            bool isSaved = false;
            Data.Order dataOrder = new Data.Order();

            if (modOrder.OrderItems != null)
            {
                dataOrder.Id = modOrder.Id;
                dataOrder.CustomerId = modOrder.CustomerId;
                dataOrder.OrderDate = modOrder.OrderDate;
                dataOrder.OrderNumber = modOrder.OrderNumber;
                dataOrder.TotalAmount = modOrder.TotalAmount;
                
                dataOrder.OrderItems = modOrder.OrderItems.Select(o => new Data.OrderItem()
                {
                    Id = o.Id,
                    OrderId = o.OrderId,
                    ProductId = o.ProductId,
                    Quantity = o.Quantity,
                    UnitPrice = o.UnitPrice
                }).ToList();

                isSaved = objBLOrder.SaveOrder(dataOrder);
                modOrder.Id = dataOrder.Id;
            }

            return isSaved;
        }

        public bool DeleteOrder(int id)
        {
            bool isDeleted = objBLOrder.DeleteOrder(id);
            return isDeleted;
        }

        public List<SelectListItem> Products()
        {
            List<SelectListItem> products = new List<SelectListItem>();

            products = objBLProduct.GetAll().Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.ProductName
            }).ToList();

            return products;
        }

        public decimal GetProductUnitPrice(int productId)
        {
            var product = objBLProduct.GetProduct(productId);
            
            if(product != null)
            {
                return product.UnitPrice.GetValueOrDefault();
            }

            return 0;
        }

    }
}