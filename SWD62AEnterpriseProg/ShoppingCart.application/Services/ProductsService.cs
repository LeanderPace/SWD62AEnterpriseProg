﻿using ShoppingCart.application.Interfaces;
using ShoppingCart.application.ViewModels;
using ShoppingCart.data.Models;
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

        public ProductViewModel GetProduct(Guid id)
        {
            ProductViewModel myViewModel = new ProductViewModel();
            var productFromDb = _productRepo.GetProduct(id);

            myViewModel.Description = productFromDb.Description;
            myViewModel.Id = productFromDb.Id;
            myViewModel.ImageUrl = productFromDb.ImageUrl;
            myViewModel.Name = productFromDb.Name;
            myViewModel.Price = productFromDb.Price;
            myViewModel.Category = new CategoryViewModel();
            myViewModel.Category.Name = productFromDb.Category.Name;

            return myViewModel;
        }

        public void AddProduct(ProductViewModel data)
        {
            Product p = new Product();

            p.Description = data.Description;
            p.ImageUrl = data.ImageUrl;
            p.Name = data.Name;
            p.Price = data.Price;
            p.CategoryId = data.Category.Id;

            _productRepo.AddProduct(p);
        }

        public void DeleteProduct(Guid id)
        {
            if(_productRepo.GetProduct(id) != null)
                _productRepo.DeleteProduct(id);
        }
    }
}
