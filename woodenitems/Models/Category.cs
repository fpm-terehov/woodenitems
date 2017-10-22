using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace woodenitems.Models
{
    public class Category
    {
        // ID
        public int Id { get; set; }
        // название продукта
        public string Name { get; set; }
        // описание продукта
        public string Description { get; set; }
        // картинки
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}