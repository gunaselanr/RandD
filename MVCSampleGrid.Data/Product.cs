//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCSampleGrid.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }
    
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
    
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
