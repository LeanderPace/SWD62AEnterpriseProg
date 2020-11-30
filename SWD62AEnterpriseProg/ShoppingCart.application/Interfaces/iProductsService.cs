using ShoppingCart.application.ViewModels;
using ShoppingCart.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.application.Interfaces
{
    public interface iProductsService
    {
        // to expose directly your classes as it was created originally to create your database is not good practice 
        // hence we create a replica of that class removing any properties which may disclose some confidential or 
        // unwanted information
        // typical eg. if you have a user class, would you pass on the password? No. So thats why we create these view models

        // IQueryable<Product> GetProducts(); wrong

        IQueryable<ProductViewModel> GetProducts(); // correct

        //void RateProduct(Guid id, string comment, double rating);

        ProductViewModel GetProduct(Guid id);

        void AddProduct(ProductViewModel data);

        void DeleteProduct(Guid id);
    }
}
