using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_ViewComponent.Models
{
    public class Category:BaseEntity
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Discount { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public string Stock { get; set; }

    }
}
