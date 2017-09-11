using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSampleGrid.Business;
using System.Web.Mvc;

namespace MVCSampleGrid.HelperClasses
{
    public class HelperCustomer
    {
        private BL_Customer objBLCusotmer = new BL_Customer();

        public List<Models.Customer> GetAllCustomer()
        {
            var dataCustomer = objBLCusotmer.GetAll();
            var modCustomer = dataCustomer.Select(s => new Models.Customer()
                                                    {
                                                        Id = s.Id,
                                                        FirstName = s.FirstName,
                                                        LastName = s.LastName,
                                                        City = s.City,
                                                        Country = s.Country,
                                                        Phone = s.Phone,
                                                        Orders = s.Orders.Count() > 0 ? s.Orders.Select(o => new Models.Order()
                                                                {
                                                                    OrderNumber = o.OrderNumber,
                                                                    TotalAmount = o.TotalAmount
                                                                }).ToList() : new List<Models.Order>(),
                                                    }).ToList();

            return modCustomer;
        }

        public Models.Customer GetCusotmerById(int id)
        {
            Models.Customer modCustomer = new Models.Customer();
            var dataCustomer = objBLCusotmer.GetCustomer(id);

            modCustomer.Id = dataCustomer.Id;
            modCustomer.FirstName = dataCustomer.FirstName;
            modCustomer.LastName = dataCustomer.LastName;
            modCustomer.City = dataCustomer.City;
            modCustomer.Country = dataCustomer.Country;
            modCustomer.Phone = dataCustomer.Phone;
            modCustomer.Orders = dataCustomer.Orders.Select(o => new Models.Order() { OrderNumber = o.OrderNumber, TotalAmount = o.TotalAmount }).ToList();

            return modCustomer;
        }

        public bool SaveCustomer(Models.Customer modCustomer)
        {
            bool isSaved = false;
            Data.Customer dataCustomer = new Data.Customer();

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

        public List<SelectListItem> Customers()
        {
            List<SelectListItem> lstCustomers = new List<SelectListItem>();
            lstCustomers = objBLCusotmer.GetAll().Select(s => new SelectListItem() { Value = s.Id.ToString(), Text = s.FirstName + " " + s.LastName }).ToList();
            return lstCustomers;
        }
    }
}