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
    public class CategoryController : Controller
    {
        WoodenContext db = new WoodenContext();
        public ActionResult Product(int id)
        {
            ViewBag.Product = db.Products.Where(p => p.Id == id).
                Include(p=>p.Images).First();
            //ViewBag.Product = db.Products.Find(id);
            ViewBag.IsUser = User.Identity.IsAuthenticated;
            return View();
        }

        public ActionResult FileUpload(HttpPostedFileBase file, int id)
        {
            MyImage myim = new MyImage();
            if (file != null)
            {
                var cba = db.Products.Find(id).CategoryId;
                var abc = db.Categories.Where(cat => cat.Id == cba).First().Name;
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/images/"+abc), pic);
                // file is uploaded
                myim.ImagePath = "/Content/images/" + abc + "/" + file.FileName;
                myim.ProductId = id;
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                db.Images.Add(myim);
                db.SaveChanges();

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Product/"+id);
        }
    }
}