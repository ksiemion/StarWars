using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace StarWars.Infrastructure
{
    public static class ServiceExtensions
	{
        public static IServiceCollection AddMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceExtensions));
            return services;
        }
    }
}
