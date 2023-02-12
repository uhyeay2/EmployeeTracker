using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Mediator.Handlers.DepartmentHandlers
{
    public class InsertDepartmentRequest : BaseValidatableRequest<DataExecutionResponse>
    {
        public InsertDepartmentRequest() { }

        public InsertDepartmentRequest(string code, string name)
        {
            Code = code;
            Name = name;
        }

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
            if (await DataAccess.FetchAsync<bool>(new DepartmentCodeExists(request.Code)))
            {
                return DataExecutionResponse.AlreadyExists();
            }

            var result = await DataAccess.ExecuteAsync(new InsertDepartment(request.Code, request.Name));

            if (result == 1)
            {
                return DataExecutionResponse.Success(result);
            }

            return DataExecutionResponse.UnExpected(result);
        }
    }
}
