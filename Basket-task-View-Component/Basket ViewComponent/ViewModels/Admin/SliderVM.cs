using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket_ViewComponent.ViewModels.Admin
{
    public class SliderVM
    {
        public int Id { get; set; }
        [NotMapped]
        [Required]
        public List<IFormFile> Photos { get; set; }
        public string Discount { get; set; }
        public string Description { get; set; }
    }
}
