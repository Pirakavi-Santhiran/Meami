using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Meami.Models;

namespace Meami.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (ShopModel db = new ShopModel())
            {
                List<Product> proList = db.Products.ToList<Product>();
                return Json(new { data = proList }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Product());
            else
            {
                using (ShopModel db = new ShopModel())
                {
                    return View(db.Products.Where(x => x.Id == id).FirstOrDefault<Product>());
                }
            }
        }


        [HttpPost]
        public ActionResult AddOrEdit(Product pro)
        {
            using (ShopModel db = new ShopModel()) 
            {
                if (pro.Id == 0)
                {
                    db.Products.Add(pro);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Product Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(pro).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Product Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ShopModel db = new ShopModel())
            {
                Product pro = db.Products.Where(x => x.Id == id).FirstOrDefault<Product>();
                db.Products.Remove(pro);
                db.SaveChanges();
                return Json(new { success = true, message = "Product Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}