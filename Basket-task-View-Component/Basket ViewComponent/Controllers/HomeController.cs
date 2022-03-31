using Basket_ViewComponent.Data;
using Basket_ViewComponent.Models;
using Basket_ViewComponent.Services;
using Basket_ViewComponent.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_ViewComponent.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        public HomeController(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }
       public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            List<Product> products = await _context.Products.ToListAsync();
            List<Category> categories = await _context.Categories.ToListAsync();
            HomeVM homeVM = new HomeVM 
            { 
                Sliders=sliders,
                Products=products,
                Categories=categories
                
            };
            return View(homeVM);
        }
    }
}
