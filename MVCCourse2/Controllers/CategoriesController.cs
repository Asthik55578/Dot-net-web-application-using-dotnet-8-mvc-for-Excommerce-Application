using Microsoft.AspNetCore.Mvc;
using MVCCourse2.Models;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace MVCCourse2.Controllers
{
    
    public class CategoriesController : Controller
    {
        
        public IActionResult Index()
        {
            var category = CategoriesRepository.GetCategories();
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            return View(category);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";
          return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add";
            return View(category);
        }
        
        public IActionResult Delete(int categoryId)
        {
            CategoriesRepository.DeleteCategory(categoryId);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
