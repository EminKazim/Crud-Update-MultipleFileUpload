using Basket_ViewComponent.Data;
using Basket_ViewComponent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_ViewComponent.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Products.Where(m => !m.IsDleted).ToListAsync();
            return View(categories);
        }
        public IActionResult Detail(int id)
        {
            var category = _context.Categories.FirstOrDefault(m => m.Id == id);
            return View(category);
        }
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(m => m.Id == id);
            return View(category);
        }
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(m => m.Id == id);
            return View(category);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist =  _context.Products.Any(m => m.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            if (isExist)
            {
                ModelState.AddModelError("Name","Bu category mövcuddur");
                return View();
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
