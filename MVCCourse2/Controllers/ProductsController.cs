using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MVCCourse2.Models;
using MVCCourse2.ViewModels;

namespace MVCCourse2.Controllers
{
    public class ProductsController : Controller
    {

        public IActionResult Index()
        {

            var products = ProductsRepository.GetProducts(loadCategory: true);
            return View(products);
        }
        public IActionResult Add()
        //{
        //    ViewBag.Action = "add";
        //    var productViewModel = new ProductViewModel()
        //    {
        //        Categories = CategoriesRepository.GetCategories()
        //    };
        //    return View(productViewModel);
        { 
            ViewBag.Action = "add";
            var products = ProductsRepository.GetProducts();
            return View(products);
        }

        [HttpPost]
        public IActionResult Add(Product productViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    ProductsRepository.AddProduct(productViewModel.Product);
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewBag.Action = "add";
            //productViewModel.Categories = CategoriesRepository.GetCategories();
            //return View(productViewModel);
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add";
           // productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var productViewModel = new ProductViewModel()
            {
                Product = ProductsRepository.GetProductById(id) ?? new Product(),
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
                RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Delete(int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products=ProductsRepository.GetProductByCategoryId(categoryId.ToString());
            return PartialView("_Products", products);
        }
        public IActionResult GetPurchaseHistory()
        {

            var history = ProductsRepository.GetHistory(loadCategory: true);
            return View(history);
        }
    }
}
