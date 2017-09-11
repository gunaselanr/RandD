using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSampleGrid.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public List<Models.OrderItem> OrderItems { get; set; }
        public Models.Supplier Supplier { get; set; }
    }
}