using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Meami.Models;

namespace Meami.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (ShopModel db = new ShopModel())
            {
                List<OrderDetails_Result> orderList = db.OrderDetails().ToList<OrderDetails_Result>();
                return Json(new { data = orderList }, JsonRequestBehavior.AllowGet);
            }

        }
        


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                using (ShopModel db = new ShopModel())
                {
                    var cusList = db.Customers.ToList();
                    ViewBag.CustomerList = new SelectList(cusList, "Id", "Name");
                    var proList = db.Products.ToList();
                    ViewBag.ProductList = new SelectList(proList, "Id", "Name");
                    return View(new Order());
                }
            else
            {
                using (ShopModel db = new ShopModel())
                {
                    var cusList = db.Customers.ToList();
                    ViewBag.CustomerList = new SelectList(cusList, "Id", "Name");
                    var proList = db.Products.ToList();
                    ViewBag.ProductList = new SelectList(proList, "Id", "Name");
                    return View(db.Orders.Where(x => x.Id == id).FirstOrDefault<Order>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Order ord)
        {
            using (ShopModel db = new ShopModel())
            {
                if (ord.Id == 0)
                {
                    db.Orders.Add(ord);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Order Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(ord).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Order Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ShopModel db = new ShopModel())
            {
                Order ord = db.Orders.Where(x => x.Id == id).FirstOrDefault<Order>();
                db.Orders.Remove(ord);
                db.SaveChanges();
                return Json(new { success = true, message = "Order Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}