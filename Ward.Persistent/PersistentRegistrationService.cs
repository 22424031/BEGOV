using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Ward.Application.Contracts;
using Ward.Persistent.Repositories;
using Ward.Persistent;
using Ward.Application.Contracts.Ads;
using Ward.Application.Contracts.ReportWarm;

namespace Ward.Persistent
{
    public static  class PersistentRegistrationService
    {

        public static IServiceCollection ConfigurePersistenceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            string conectionString = configuration.GetConnectionString("ward");
            services.AddDbContext<GOVInforContext>(x =>
            {
                MySqlServerVersion version = new(new Version(8, 0, 0));
                x.UseMySql(conectionString, version);
            });
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IAdsRepository,AdsRepository>();
            services.AddScoped<IReportWarmRepository, ReportWarmRepository>();
            return services;
        }

    }
}