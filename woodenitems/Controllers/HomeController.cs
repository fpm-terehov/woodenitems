using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using woodenitems.Models;
using System.IO;

namespace woodenitems.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        WoodenContext db = new WoodenContext();

        public ActionResult Index()
        {
            IEnumerable<Product> products = db.Products.Include("Images");
            foreach (var p in products)
                Console.WriteLine(p.Images);
            ViewBag.Products = products;
            ViewBag.IsUser = User.Identity.IsAuthenticated;
            return View();
        }


        public ActionResult DeleteCat(int id)
        {
            var ss = db.Products.Where(product => product.CategoryId == id).Count();
            if (ss == 0)
            {
                string folder = Server.MapPath("~/Content/images/");

                // Combine the base folder with your specific folder....
                string specificFolder = Path.Combine(folder, db.Categories.Find(id).Name);
                Directory.Delete(specificFolder);
                db.Categories.Remove(db.Categories.Find(id));
            }
            db.SaveChanges();
            return RedirectToAction("Categories");
        }

        public ActionResult DeleteProd(int id)
        {
            //db.Images.Remove();
            var v = db.Products.Find(id).CategoryId;
            var imgs = db.Images.Where(img => img.ProductId == id);
            foreach(var i in imgs)
            {
                string folder = Server.MapPath("~/"+ i.ImagePath);

                // Combine the base folder with your specific folder....
                string specificFolder = Path.Combine(folder, i.ImagePath);
                System.IO.File.Delete(folder);
                db.Images.Remove(i);
            }
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
            return RedirectToAction("Category", new { id = v });
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Category(int id)
        {
            ViewBag.Products = db.Products.Where(product=>product.CategoryId == id).
                Include(product=>product.Images).Include(product=>product.Category);
            ViewBag.CatName = db.Categories.Find(id).Name;
            ViewBag.IsUser = User.Identity.IsAuthenticated;
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Category(int id, Product product)
        {
            product.CategoryId = id;
            db.Products.Add(product);
            db.SaveChanges();
            return Category(id);
        }

        [HttpGet]
        public ActionResult Categories()
        {
            ViewBag.Categories = db.Categories.Include(c => c.Products);
            ViewBag.IsUser = User.Identity.IsAuthenticated;
            return View();
        }

        [HttpPost]
        public ActionResult Categories(Category category)
        {
            string folder = Server.MapPath("~/Content/images/");

            // Combine the base folder with your specific folder....
            string specificFolder = Path.Combine(folder, category.Name);
            Directory.CreateDirectory(specificFolder);
            db.Categories.Add(category);
            db.SaveChanges();
            return Categories();
        }
    }
}