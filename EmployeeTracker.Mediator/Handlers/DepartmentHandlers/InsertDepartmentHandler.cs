using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Mediator.Handlers.DepartmentHandlers
{
    public class InsertDepartmentRequest : RequiredCodeRequest<DataExecutionResponse>
    {
        public InsertDepartmentRequest(string code, string name) : base(code)
        {
            Name = name;
        }

        public string Name { get; set; } = null!;

        public override bool IsValid(out List<ValidationFailure> validationFailures)
        {
            base.IsValid(out validationFailures);

            validationFailures.RequiredStrings((nameof(Name), Name));

            return validationFailures.Count == 0;
        }
    }

    internal class InsertDepartmentHandler : DataHandler<InsertDepartmentRequest, DataExecutionResponse>
    {
        public InsertDepartmentHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<DataExecutionResponse> Handle(InsertDepartmentRequest request, CancellationToken cancellationToken)
        {
            if (await DataAccess.FetchAsync<bool>(new DepartmentCodeExists(request.Code)))
            {
                return DataExecutionResponse.AlreadyExists($"Department already exists with Code: {request.Code}");
            }

            var rowsAffected = await DataAccess.ExecuteAsync(new InsertDepartment(request.Code, request.Name));

            if (rowsAffected == 1)
            {
                return DataExecutionResponse.Success(rowsAffected);
            }

            return DataExecutionResponse.UnExpected(rowsAffected, $"Expected 1 Row Inserted - Actual Rows Affected: {rowsAffected}");
        }
    }
}
