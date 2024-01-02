using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ward.Application.Contracts.Mail;

namespace MailService
{
    public static class MailRegistrationService
    {
        public static IServiceCollection ConfigMailService(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<ISendMail, SendMail>();
            return services;
        }
    }
}
