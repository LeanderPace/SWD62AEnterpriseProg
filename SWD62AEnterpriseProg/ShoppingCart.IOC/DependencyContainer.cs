using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.application.Interfaces;
using ShoppingCart.application.Services;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.data.Context;
using ShoppingCart.data.Repositories;
using ShoppingCart.Data.Repositories;
using ShoppingCart.domain.Interfaces;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            // when are these instances triggered?
            // answer: https://www.tutorialsteacher.com/core/dependency-injection-in-aspnet-core


            services.AddDbContext<ShoppingCarDBContext>(options =>
                options.UseSqlServer(connectionString
                    ));

            services.AddScoped<iProductsRepository, ProductsRepository>();
            services.AddScoped<iProductsService, ProductsService>();

            services.AddScoped<iCategoriesRepository, CategoriesRepository>();
            services.AddScoped<iCategoriesService, CategoriesService>();
        }
    }
}
