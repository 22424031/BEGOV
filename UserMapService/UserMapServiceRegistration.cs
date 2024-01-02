using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ward.Application.Contracts.UserMap;

namespace UserMapService
{
    public static class UserMapServiceRegistration
    {
      
            public static IServiceCollection ConfigUserMapService(this IServiceCollection services, IConfiguration configuration)
            {
             
                services.AddScoped<IUserMapAds, UserMapAds>();
                return services;
            }
        
    }
}
