using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSampleGrid.HelperClasses;

namespace MVCSampleGrid.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        private HelperCustomer objHelperCustomer = new HelperCustomer();

        public ActionResult Index()
        {
            var lstCustomer = objHelperCustomer.GetAllCustomer();
            return View(lstCustomer);
        }

        public ActionResult Edit(int? id)
        {
            Models.Customer customer = new Models.Customer();

            if (id.GetValueOrDefault() > 0)
            {
                customer = objHelperCustomer.GetCusotmerById(id.GetValueOrDefault());
            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Models.Customer modCustomer)
        {
            if(ModelState.IsValid)
            {
                bool isSaved = objHelperCustomer.SaveCustomer(modCustomer);

                if (isSaved)
                {
                    TempData["message"] = "<script>alert('Customer Saved Successfully')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "<script>alert('Customer Not Saved')</script>";
                }

            }

            return View(modCustomer);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if(id.GetValueOrDefault() > 0)
            {
                bool isDeleted = objHelperCustomer.DeleteCustomer(id.GetValueOrDefault());
                if (isDeleted)
                {
                    TempData["message"] = "<script>alert('Customer Deleted Successfully')</script>";                   
                }
                else
                {
                    TempData["message"] = "<script>alert('Customer Not Deleted')</script>";
                }
            }

            return RedirectToAction("Index");
        }
    }
}
