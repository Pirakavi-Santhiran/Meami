using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Meami.Models;

namespace Meami.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (ShopModel db = new ShopModel())
            {
                List<Customer> cusList = db.Customers.ToList<Customer>();
                return Json(new { data = cusList }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Customer());
            else
            {
                using (ShopModel db = new ShopModel())
                {
                    return View(db.Customers.Where(x => x.Id == id).FirstOrDefault<Customer>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Customer cus)
        {
            using (ShopModel db = new ShopModel())
            {
                if (cus.Id == 0)
                {
                    db.Customers.Add(cus);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Customer Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(cus).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Customer Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ShopModel db = new ShopModel())
            {
                Customer cus = db.Customers.Where(x => x.Id == id).FirstOrDefault<Customer>();
                db.Customers.Remove(cus);
                db.SaveChanges();
                return Json(new { success = true, message = "Customer Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}