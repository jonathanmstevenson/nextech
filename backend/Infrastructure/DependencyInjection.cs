using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PrimaryDbConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                ));
                
            // services.AddScoped<IProductService, ProductService>();
            // services.AddTransient<IProductRepository, ProductRepository>();

            services.AddScoped<IHackerNewsService, HackerNewsService>();
            
            return services;
        }
    }
}