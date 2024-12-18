using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC.BL.IServices;
using MVC.BL.Services;
using MVC.DAL;
using MVC.DAL.Entities;
using MVC.DAL.Entities.Interfaces;
using MVC.Model;

namespace MVS.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<MarketDbContext>(options =>
                options.UseSqlServer(connectionString));
          
            services.AddScoped<IRepository<Product>, ProductRepository>();
          
            services.AddScoped<IService<ProductDto>, ProductService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}