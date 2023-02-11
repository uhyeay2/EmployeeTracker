using EmployeeTracker.Domain.Interfaces;
using EmployeeTracker.Domain.Models;

namespace EmployeeTracker.Mediator.Abstractions.BaseRequests
{
    public abstract class BaseValidatableRequest<TResponse> : BaseRequest<TResponse>, IValidatable
    {
        abstract public bool IsValid(out List<ValidationFailure> validationFailures);
    }
}
