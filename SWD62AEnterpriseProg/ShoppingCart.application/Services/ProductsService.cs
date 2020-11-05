using ShoppingCart.application.Interfaces;
using ShoppingCart.application.ViewModels;
using ShoppingCart.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.application.Services
{
    public class ProductsService : iProductsService
    {
        private iProductsRepository _productRepo;
        public ProductsService(iProductsRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            var list = from p in _productRepo.GetProduct()
                       select new ProductViewModel()
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Price = p.Price,
                           Description = p.Description,
                            ImageUrl = p.ImageUrl,
                           Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name }
                       };
            return list;
        }
    }
}
