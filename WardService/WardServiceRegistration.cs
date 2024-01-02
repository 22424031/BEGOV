using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ward.Application.Contracts.Ward;

namespace WardService
{
    public static class WardServiceRegistration
    {
        public static IServiceCollection ConfigWardService(this IServiceCollection services, IConfiguration configuration)
        {
            string wardUrl = configuration["client:wardurl"];
            services.AddScoped<IWardAds, WardAds>();
            return services;
        }
    }
}