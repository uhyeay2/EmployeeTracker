using EmployeeTracker.Api.Middleware;
using EmployeeTracker.Mediator.DependencyInjection;

namespace EmployeeTracker.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            if(services == null)
                throw new ApplicationException(nameof(services));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Inject Mediator Services - EmployeeTracker.Mediator
            services.InjectMediatorServices(new DbConnectionConfig());

            services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }
    }
}
