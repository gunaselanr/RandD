using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApplication.Model
{
    public class VM_Order
    {
        public int Id { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }
        public Model.VM_Customer Customer { get; set; }
        public List<Model.VM_OrderItem> OrderItems { get; set; }

    }
}