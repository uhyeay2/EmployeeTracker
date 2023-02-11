using EmployeeTracker.Data.Implementation;
using EmployeeTracker.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeTracker.Data.DependencyInjection
{
    public static class DataServices
    {
        public static IServiceCollection InjectDataServices(this IServiceCollection services, IConfig config)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IDbConnectionFactory>(new DbConnectionFactory(config));

            services.AddScoped<IDataAccess, DataAccess>();

            return services;
        }
    }
}
