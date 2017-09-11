using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSampleGrid.HelperClasses;

namespace MVCSampleGrid.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        private HelperOrder objHelperOrder = new HelperOrder();
        public HelperCustomer objHelperCustomer = new HelperCustomer();

        public ActionResult Index()
        {
            var lstOrders = objHelperOrder.GetAllOrder();
            return View(lstOrders);
        }

        public ActionResult Edit(int? id)
        {
            Models.Order modOrder = new Models.Order();
            ViewBag.Title = "Add";

            if (id.GetValueOrDefault() > 0)
            {
                ViewBag.Title = "Edit";
                modOrder = objHelperOrder.GetOrderById(id.GetValueOrDefault());
            }

            SetViewData();

            return View(modOrder);
        }

        [HttpPost]
        public JsonResult Edit(Models.Order salesOrder)
        {
            bool isSaved = false;

            if (ModelState.IsValid)
            {
                isSaved = objHelperOrder.SaveOrder(salesOrder);
                
                if (isSaved)
                {
                    TempData["message"] = "<script>alert('Order Saved Successfully')</script>";
                    return Json(new { Success = "success", salesOrderId = salesOrder.Id, ex = "" });
                }
                else
                {
                    TempData["message"] = "<script>alert('Order Not Saved')</script>";
                }
            }

            return Json(new { Success = "falied", salesOrderId = 0, ex = "Error" });
        }

        public ActionResult Delete(int? id)
        {
            bool isDeleted = objHelperOrder.DeleteOrder(id.GetValueOrDefault());

            if (isDeleted)
            {
                TempData["message"] = "<script>alert('Order Deleted Successfully')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "<script>alert('Order Not Deleted')</script>";
            }

            return RedirectToAction("Index");

        }

        public ActionResult EditNew(int? id)
        {
            Models.Order modOrders = new Models.Order();

            if (id.GetValueOrDefault() > 0)
            {
                modOrders = objHelperOrder.GetOrderById(id.GetValueOrDefault());
            }
            SetViewData();
            return View(modOrders);
        }

        [HttpPost]
        public JsonResult GetProductUnitPrice(int? productId)
        {
            var productUnitPrice = objHelperOrder.GetProductUnitPrice(productId.GetValueOrDefault());
            return Json(new { success = "success", UnitPrice = productUnitPrice });

        }
        public void SetViewData()
        {
            ViewData["Products"] = objHelperOrder.Products();
            ViewData["Customers"] = objHelperCustomer.Customers();
        }
    }
}
