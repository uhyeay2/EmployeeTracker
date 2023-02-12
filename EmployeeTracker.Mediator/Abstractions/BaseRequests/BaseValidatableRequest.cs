using EmployeeTracker.Domain.Interfaces;

namespace EmployeeTracker.Mediator.Abstractions.BaseRequests
{
    public abstract class BaseValidatableRequest<TResponse> : BaseRequest<TResponse>, IValidatable where TResponse : BaseResponse
    {
        abstract public bool IsValid(out List<ValidationFailure> validationFailures);
    }
}
