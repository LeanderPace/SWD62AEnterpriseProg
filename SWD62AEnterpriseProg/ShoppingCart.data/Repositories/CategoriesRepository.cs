using ShoppingCart.data.Models;
using ShoppingCart.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.data.Repositories
{
    class CategoriesRepository : iCategoriesRespository
    {
        public IQueryable<Category> GetCategory()
        {
            throw new NotImplementedException();
        }
    }
}
