using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCSampleGrid.Models;

namespace MVCSampleGrid.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Order Date")]
        [Required(ErrorMessage = "Order date is required")]
        public System.DateTime OrderDate { get; set; }

        [Display(Name = "Order Number")]
        [Required(ErrorMessage = "Order number is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "Order number should not exceed 10 digits")]
        public string OrderNumber { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Please select customer name")]
        public int CustomerId { get; set; }

        [Display(Name = "Total Amount")]
        public decimal? TotalAmount { get; set; }

        public Models.Customer Customer { get; set; }
        public List<Models.OrderItem> OrderItems { get; set; }

        //public int ProductId { get; set; }
        //public decimal UnitPrice { get; set; }
        //public int Quantity { get; set; }
        //public decimal Amount { get; set; }
    }


}