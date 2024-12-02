using Microsoft.AspNetCore.Mvc;
using MVCCourse2.Models;
using MVCCourse2.ViewModels;

namespace MVCCourse2.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories(),

            };
            return View(salesViewModel);
        }
        public IActionResult SellProductPartiaL(int productId)
        {
            var product=ProductsRepository.GetProductById(productId);
            return PartialView("_SellProduct",product);
        }
    }
}
