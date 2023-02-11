using EmployeeTracker.Data.Interfaces;
using MediatR;

namespace EmployeeTracker.Mediator.Abstractions.BaseHandlers
{
    internal abstract class DataHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IDataAccess DataAccess;

        public DataHandler(IDataAccess dataAccess) => DataAccess = dataAccess;

        abstract public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
