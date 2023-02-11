using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Data.Interfaces;
using EmployeeTracker.Domain.Extensions;
using EmployeeTracker.Domain.Models;
using EmployeeTracker.Mediator.Abstractions.BaseHandlers;
using EmployeeTracker.Mediator.Abstractions.BaseRequests;
using EmployeeTracker.Mediator.Abstractions.BaseResponses;

namespace EmployeeTracker.Mediator.Handlers.DepartmentHandlers
{
    public class InsertDepartmentRequest : BaseValidatableRequest<DataExecutionResponse>
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public override bool IsValid(out List<ValidationFailure> validationFailures)
        {
            validationFailures = new();

            validationFailures.RequiredStrings((nameof(Code), Code), (nameof(Name), Name));

            return validationFailures.Any();
        }
    }

    internal class InsertDepartmentHandler : DataHandler<InsertDepartmentRequest, DataExecutionResponse>
    {
        public InsertDepartmentHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<DataExecutionResponse> Handle(InsertDepartmentRequest request, CancellationToken cancellationToken)
        {
            var result = await DataAccess.ExecuteAsync(new InsertDepartment(request.Code, request.Name));

            if (result == 1)
            {
                return DataExecutionResponse.Success(result);
            }

            return DataExecutionResponse.UnExpected(result);
        }
    }
}
