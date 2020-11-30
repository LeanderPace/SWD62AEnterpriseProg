using ShoppingCart.application.ViewModels;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Data.Repositories;
using ShoppingCart.domain.Interfaces;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CategoriesService : iCategoriesService
    {
        private iCategoriesRepository _categoryRepo;
        public CategoriesService(iCategoriesRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IQueryable<CategoryViewModel> GetCategories()
        {
            var list = from c in _categoryRepo.GetCategories()
                       select new CategoryViewModel()
                       {
                           Id = c.Id,
                           Name = c.Name,
                       };

            return list;
        }
    }
}