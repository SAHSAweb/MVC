using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC.BL.Interfaces;
using MVC.BL.Services;
using MVC.DAL;
using MVC.DAL.Entities;
using MVC.DAL.Entities.Interfaces;
using MVC.Model;

namespace MVC.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection))
            {
                throw new ArgumentNullException(nameof(connection));
            }

            services.AddDbContext<MarketDbContext>(options =>
                options.UseSqlServer(connection));
          
            services.AddScoped<IRepository<Product>, ProductRepository>();
          
            services.AddScoped<IService<ProductDto>, ProductService>();

            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<IUserService<UserDto>, UserService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}