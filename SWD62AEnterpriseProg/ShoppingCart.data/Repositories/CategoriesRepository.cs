using ShoppingCart.data.Context;
using ShoppingCart.data.Models;
using ShoppingCart.domain.Interfaces;
using ShoppingCart.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CategoriesRepository : iCategoriesRepository
    {
        private ShoppingCarDBContext _context;

        public CategoriesRepository(ShoppingCarDBContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories;
        }
    }
}