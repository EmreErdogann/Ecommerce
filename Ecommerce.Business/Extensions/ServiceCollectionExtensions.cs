using Ecommerce.Business.Implementaions;
using Ecommerce.Business.Interfaces;
using Ecommerce.Data.Context;
using Ecommerce.Data.Implementaions;
using Ecommerce.Data.Interfaces;
using Ecommerce.Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<EcommerceDataContext>();
            serviceCollection.AddIdentity<User, Role>(options =>
            {
                // User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                // User Username and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<EcommerceDataContext>();


            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            //serviceCollection.AddScoped<ICartRepository, EfCartRepository>();
            //serviceCollection.AddScoped<ICategoryRepository, EfCategoryRepository>();
            //serviceCollection.AddScoped<IProductRepository, EfProductRepository>();

            serviceCollection.AddTransient<ICategoryService, CategoryManager>();
            serviceCollection.AddTransient<IProductService, ProductManager>();
            serviceCollection.AddTransient<ICartService, CartManager>();
            return serviceCollection;
        }
    }
}
