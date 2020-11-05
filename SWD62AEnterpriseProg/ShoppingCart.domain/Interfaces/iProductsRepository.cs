using ShoppingCart.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.domain.Interfaces
{
    public interface iProductsRepository
    {
        IQueryable<Product> GetProduct();
        Product GetProduct(Guid id);

        void AddProduct(Product p);

        void DeleteProduct(Guid id);
    }
}
