using ShoppingCart.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface iCategoriesRepository
    {
        IQueryable<Category> GetCategories();
    }
}