using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSampleGrid.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
       
        public Models.Order Order { get; set; }
        public Models.Product Product { get; set; }
    }
}