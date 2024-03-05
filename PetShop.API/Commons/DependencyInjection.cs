using Microsoft.EntityFrameworkCore;
using PetShop.Business.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Implements;
using PetShop.Services.Intefaces;

namespace PetShop.API.Commons
{
    public static class DependencyInjection
    {
        public static void AddDI(this IServiceCollection services)
        {
            services.AddDbContext<PetShopContext>(options =>
            {
                options.UseSqlServer("PetShopDB");
            });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
