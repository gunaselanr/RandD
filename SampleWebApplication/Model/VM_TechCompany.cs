using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApplication.Model
{
    public class VM_TechCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Year_2011 { get; set; }
        public double Year_2012 { get; set; }
        public double Year_2013 { get; set; }
        public double Year_2014 { get; set; }
        public List<VM_TechCompany> lstCompany { get; set; }
        public double Total_Year_2011 { get; set; }
        public double Total_Year_2012 { get; set; }
        public double Total_Year_2013 { get; set; }
        public double Total_Year_2014 { get; set; }
        public double RowTotal { get; set; }
        public double ColumnTotal { get; set; }
        public double FinalTotal { get; set; }
    }
}