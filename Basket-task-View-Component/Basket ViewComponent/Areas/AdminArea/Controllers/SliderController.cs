using Basket_ViewComponent.Data;
using Basket_ViewComponent.Models;
using Basket_ViewComponent.ViewModels.Admin;
using LessonMigration.Utilities.File;
using LessonMigration.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace Basket_ViewComponent.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.AsNoTracking().ToListAsync();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderVM sliderVM)
        {
            #region MyRegion
            //if (modelstate["photo"].validationstate == modelvalidationstate.invalid) return view();
            //if (!slider.photo.checkfiletype("image/"))
            //{
            //    modelstate.addmodelerror("photo", "image type is wrong");
            //    return view();
            //}
            //if (!slider.photo.checkfilesize(300))
            //{
            //    modelstate.addmodelerror("photo", "image size is wrong");
            //    return view();
            //}
            //string filename = guid.newguid().tostring() + "_" + slider.photo.filename;
            //string path = helper.getfilepath(_env.webrootpath, "assets/img", filename);
            //using (filestream stream = new filestream(path, filemode.create))
            //{
            //    await slider.photo.copytoasync(stream);
            //}
            //slider.image = filename;
            //await _context.sliders.addasync(slider);
            //await _context.savechangesasync();
            //if (!modelstate.isvalid)
            //{
            //    return view();
            //}
            //bool isexist = _context.sliders.any(m => m.description.tolower().trim() == slider.description.tolower().trim());
            //if (isexist)
            //{
            //    modelstate.addmodelerror("description", "bu description mövcuddur");
            //    return view();
            //}
            //if (!modelstate.isvalid)
            //{
            //    return view();
            //}
            //bool isexist = _context.sliders.any(m => m.discount.tolower().trim() == slider.discount.tolower().trim());
            //if (isexist)
            //{
            //    modelstate.addmodelerror("discount", "bu discount mövcuddur");
            //    return view();
            //}
            //await _context.sliders.addasync(slider);
            //await _context.savechangesasync();
            #endregion
            if (ModelState["Photos"].ValidationState == ModelValidationState.Invalid) return View();
            foreach (var photo in sliderVM.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("photo", "image type is wrong");
                    return View();
                }
                if (!photo.CheckFileSize(300))
                {
                    ModelState.AddModelError("photo", "image size is wrong");
                    return View();
                }
            }
            foreach (var item in sliderVM.Photos)
            {
                string filename = Guid.NewGuid().ToString() + "_" + item.FileName;
                string path = Helper.GetFilePath(_env.WebRootPath, "assets/img", filename);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                Slider slider = new Slider
                {
                    Image = filename
                };
                await _context.Sliders.AddAsync(slider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int id)
        {
            var slider = _context.Sliders.FirstOrDefault(m => m.Id == id);
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await GetSliderById(id);
            if (slider == null) return NotFound();
            string path = Helper.GetFilePath(_env.WebRootPath, "img", slider.Image);
            Helper.DeleteFile(path);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit( int id)
        {
            var slider = await GetSliderById(id);
            if (slider is null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Slider slider)
        {
            var dbSlider = await GetSliderById(id);
            if (dbSlider is null) return NotFound();
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Wrong file type");
                return View();
            }
            if (!slider.Photo.CheckFileSize(300))
            {
                ModelState.AddModelError("Photo", "Image size is wrong");
                return View();
            }
           
            string path = Helper.GetFilePath(_env.WebRootPath, "assets/img", dbSlider.Image);
            Helper.DeleteFile(path);
            string fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
            string newPath = Helper.GetFilePath(_env.WebRootPath, "assets/img", fileName);
            using(FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }
            dbSlider.Image = fileName;
            //if (!ModelState.IsValid) return View();
            //if (id != slider.Id) return BadRequest();
            //try
            //{
            //    Slider dbSliderDes = await _context.Sliders.AsNoTracking().Where(m => !m.IsDleted && m.Id == id).FirstOrDefaultAsync();

            //    if (dbSliderDes.Discount.ToLower().Trim() == slider.Discount.ToLower().Trim())
            //    {
            //        return RedirectToAction(nameof(Index));
            //    }
            //    bool isExist = _context.Sliders.Where(m => !m.IsDleted).Any(m => m.Discount.ToLower().Trim() == slider.Discount.ToLower().Trim());
            //    if (isExist)
            //    {
            //        ModelState.AddModelError("Name", " Mövcuddur");
            //        return View();
            //    }
            //    dbSliderDes.Description = slider.Description;
            //    _context.Sliders.Update(slider);
            //}
            //catch (DbUpdateException ex)
            //{
            //    ModelState.AddModelError("", ex.Message);
            //    return View();
            //}
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private async Task<Slider> GetSliderById(int id)
        {
            return await _context.Sliders.FindAsync(id);
        }
    }
}
