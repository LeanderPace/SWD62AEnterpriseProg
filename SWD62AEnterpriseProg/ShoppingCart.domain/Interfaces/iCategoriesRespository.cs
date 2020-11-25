using ShoppingCart.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.domain.Interfaces
{
    public interface iCategoriesRespository
    {
        IQueryable<Category> GetCategory();
    }
}
