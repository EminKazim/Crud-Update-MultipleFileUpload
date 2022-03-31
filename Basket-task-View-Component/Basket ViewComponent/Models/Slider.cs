using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket_ViewComponent.Models
{
    public class Slider:BaseEntity
    {
        [Required]
        public string Image { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
        public string Discount { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }

    }
}
