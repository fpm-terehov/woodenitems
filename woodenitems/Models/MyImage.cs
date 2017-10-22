using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace woodenitems.Models
{
    public class MyImage
    {
        public int Id { get; set; }
        // название продукта
        public string Name { get; set; }
        // картинка
        public string ImagePath { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}