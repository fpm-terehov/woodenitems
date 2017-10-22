using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace woodenitems.Models
{
    public class WoodenInitializer : DropCreateDatabaseAlways<WoodenContext>
    {
        protected override void Seed(WoodenContext db)
        {
            db.Categories.Add(new Category { Name = "бутылочницы", Description = "просто текст которого сдесь не джолжно быть"});
            db.Categories.Add(new Category { Name = "вешалки", Description = "просто текст которого сдесь не джолжно быть"});
            db.Products.Add(new Product { Name = "bytil", Description = "просто текст которого сдесь не джолжно быть", CategoryId = 1 });
            db.Products.Add(new Product { Name = "veshal", Description = "просто текст которого сдесь не джолжно быть", CategoryId = 2 });
            db.SaveChanges();
            db.Images.Add(new MyImage { Name = "чета", ImagePath = "/Content/images/Бутылочницы/LxFluGEycKI.jpg" , ProductId = 1});
            db.Images.Add(new MyImage { Name = "чета", ImagePath = "/Content/images/Бутылочницы/xAuN0gh_nhM.jpg", ProductId = 1 });
            db.Images.Add(new MyImage { Name = "чета", ImagePath = "/Content/images/Вешалки/7-mmwzpRtwI.jpg", ProductId = 2 });
            db.Images.Add(new MyImage { Name = "чета", ImagePath = "/Content/images/Вешалки/MxVhi_XqAbM.jpg", ProductId = 2 });

            base.Seed(db);
        }
    }
}