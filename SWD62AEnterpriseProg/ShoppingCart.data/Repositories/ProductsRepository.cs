using ShoppingCart.data.Context;
using ShoppingCart.data.Models;
using ShoppingCart.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.data.Repositories
{
    public class ProductsRepository : iProductsRepository
    {
        private ShoppingCarDBContext _context;
        public ProductsRepository(ShoppingCarDBContext context)
        {
            _context = context;
        }

        public void AddProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var myProduct = GetProduct(id);
            _context.Remove(myProduct);
            _context.SaveChanges();
        }

        public IQueryable<Product> GetProduct()
        {
            return _context.Products;
        }

        public Product GetProduct(Guid id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
            // if it doesnt find a product with a matching id, it will return null
        }
    }
}
