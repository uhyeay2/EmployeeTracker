using MediatR;

namespace EmployeeTracker.Mediator.Abstractions.BaseRequests
{
    public class BaseRequest<TResponse> : IRequest<TResponse>
    {
    }
}
