using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_ViewComponent.Models
{
    public class Product:BaseEntity
    {
        [Required(ErrorMessage ="Boş buraxmayın"),MaxLength(50,ErrorMessage ="50 simvoldan çox ola bilməz")]
        public string Name { get; set; }
        public string CategoryIcon { get; set; }
        public string AroowIcon { get; set; }
    }
}
