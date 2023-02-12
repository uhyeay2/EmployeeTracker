using EmployeeTracker.Data.DependencyInjection;
using EmployeeTracker.Domain.Interfaces;
using EmployeeTracker.Mediator.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeTracker.Mediator.DependencyInjection
{
    public static class MediatorServices
    {
        public static IServiceCollection InjectMediatorServices(this IServiceCollection services, IConfig databaseConfig)
        {
            services.InjectDataServices(databaseConfig);
            
            services.AddMediatR(typeof(MediatorServices).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
