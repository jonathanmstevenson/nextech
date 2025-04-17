using System.Reflection;
using Application.DTOs.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(options => options.AddProfile<EntityMappingProfile>());
            return services;
        }
    }
}