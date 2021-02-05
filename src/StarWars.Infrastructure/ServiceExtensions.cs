using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
