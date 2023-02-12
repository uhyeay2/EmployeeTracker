using EmployeeTracker.Domain.Exceptions;
using EmployeeTracker.Domain.Interfaces;
using MediatR;

namespace EmployeeTracker.Mediator.Behaviors
{
    internal sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(request is IValidatable validatable && !validatable.IsValid(out var validationFailures))
            {
                throw new ValidationFailedException(validationFailures);
            }

            return await next();
        }
    }
}
