using Microsoft.EntityFrameworkCore;
using PetShop.Business.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services;

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
        }
    }
}
