using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private IWebHostEnvironment _env;
        public ProductsController(iProductsService productsService, iCategoriesService categoriesService, IWebHostEnvironment env)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
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
        public IActionResult Create(ProductViewModel data, IFormFile file)
        {
            try
            {
                if(file != null)
                {
                    if(file.Length > 0)
                    {
                        string newFileName = Guid.NewGuid() + System.IO.Path.GetExtension(file.FileName);
                        string absolutePath = _env.WebRootPath + @"\Images\";

                        using (var stream = System.IO.File.Create(absolutePath + newFileName))
                        {
                            file.CopyTo(stream);
                        }

                        data.ImageUrl = @"\Images\" + newFileName; // relative path
                    }
                }

                _productsService.AddProduct(data);

                ViewData["feedback"] = "Product was added successfully";
                ModelState.Clear();
            }
            catch(Exception ex)
            {
                //log errors
            }

            var catList = _categoriesService.GetCategories();
            ViewBag.Categories = catList;

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
