using MVCSampleGrid.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSampleGrid.Data;

namespace SampleWebApplication.HelperClass
{
    public class HelperCustomer
    {
        private BL_Customer objBLCusotmer = new BL_Customer();

        public List<Model.VM_Customer> GetAllCustomer()
        {
            var dataCustomer = objBLCusotmer.GetAll();
            var modCustomer = dataCustomer.Select(s => new Model.VM_Customer()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                City = s.City,
                Country = s.Country,
                Phone = s.Phone,
                Orders = s.Orders.Count() > 0 ? s.Orders.Select(o => new Model.VM_Order()
                {
                    OrderNumber = o.OrderNumber,
                    TotalAmount = o.TotalAmount
                }).ToList() : new List<Model.VM_Order>(),
            }).OrderByDescending(o => o.Id).ToList();

            return modCustomer;
        }

        public Model.VM_Customer GetCusotmerById(int id)
        {
            Model.VM_Customer modCustomer = new Model.VM_Customer();
            var dataCustomer = objBLCusotmer.GetCustomer(id);

            modCustomer.Id = dataCustomer.Id;
            modCustomer.FirstName = dataCustomer.FirstName;
            modCustomer.LastName = dataCustomer.LastName;
            modCustomer.City = dataCustomer.City;
            modCustomer.Country = dataCustomer.Country;
            modCustomer.Phone = dataCustomer.Phone;
            modCustomer.Orders = dataCustomer.Orders.Select(o => new Model.VM_Order() { OrderNumber = o.OrderNumber, TotalAmount = o.TotalAmount }).ToList();

            return modCustomer;
        }

        public bool SaveCustomer(Model.VM_Customer modCustomer)
        {
            bool isSaved = false;
            Customer dataCustomer = new Customer();

            dataCustomer.Id = modCustomer.Id;
            dataCustomer.FirstName = modCustomer.FirstName;
            dataCustomer.LastName = modCustomer.LastName;
            dataCustomer.City = modCustomer.City;
            dataCustomer.Country = modCustomer.Country;
            dataCustomer.Phone = modCustomer.Phone;

            isSaved = objBLCusotmer.SaveCustomer(dataCustomer);

            return isSaved;
        }

        public bool DeleteCustomer(int id)
        {
            bool isDeleted = objBLCusotmer.DeleteCustomer(id);
            return isDeleted;
        }

        //public List<SelectListItem> Customers()
        //{
        //    List<SelectListItem> lstCustomers = new List<SelectListItem>();
        //    lstCustomers = objBLCusotmer.GetAll().Select(s => new SelectListItem() { Value = s.Id.ToString(), Text = s.FirstName + " " + s.LastName }).ToList();
        //    return lstCustomers;
        //}
    }
}