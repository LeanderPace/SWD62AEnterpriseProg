using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.application.Interfaces;
using ShoppingCart.application.Services;
using ShoppingCart.application.ViewModels;
using ShoppingCart.Application.Interfaces;

namespace Presentation.Controllers
{
    public class ProductsController : Controller
    {
        private iProductsService _productsService;
        private iCategoriesService _categoriesService;
        public ProductsController(iProductsService productsService, iCategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            // IQueryable
            // IEnumerable
            // List >>>> IEnumerable >>> IQueryable

            var list = _productsService.GetProducts();

            return View(list);
        }

        public IActionResult Details(Guid id)
        {
            var myProduct = _productsService.GetProduct(id);

            return View(myProduct);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var catlist = _categoriesService.GetCategories();

            ViewBag.Categories = catlist;

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel data)
        {
            try
            {
                _productsService.AddProduct(data);

                ViewData["feedback"] = "Product was added successfully";
            }
            catch(Exception ex)
            {
                //log errors
            }

            return View();
        }

        public IActionResult Delete (Guid id)
        {
            _productsService.DeleteProduct(id);
            ViewData["feedback"] = "Product was deleted Successfully"; // TempData
            return RedirectToAction("Index");
        }
    }
}
