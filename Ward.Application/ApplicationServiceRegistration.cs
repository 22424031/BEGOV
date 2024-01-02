using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Ward.Application.Contracts.Ads;

namespace Ward.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigurateApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}