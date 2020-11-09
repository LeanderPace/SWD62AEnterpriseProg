using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.application.Interfaces;
using ShoppingCart.application.Services;
using ShoppingCart.data.Repositories;
using ShoppingCart.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // when are these instances triggered?
            // answer: https://www.tutorialsteacher.com/core/dependency-injection-in-aspnet-core

            services.AddScoped<iProductsRepository, ProductsRepository>();
            services.AddScoped<iProductsService, ProductsService>();
        }
    }
}
