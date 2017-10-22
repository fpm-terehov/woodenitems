using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace woodenitems.Models
{
    public class Product
    {
        // ID
        public int Id { get; set; }
        // название продукта
        public string Name { get; set; }
        // описание продукта
        public string Description { get; set; }
        // картинки
        public ICollection<MyImage> Images { get; set; }
        public Product() {
            Images = new List<MyImage>();
        }
      
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}