using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Mediator.Handlers.DepartmentHandlers
{
    public class UpdateDepartmentRequest : RequiredCodeRequest<DataExecutionResponse>
    {
        public UpdateDepartmentRequest(string code, string name) : base(code) => Name = name;

        public string Name { get; set; }
    }

    internal class UpdateDepartmentHandler : DataHandler<UpdateDepartmentRequest, DataExecutionResponse>
    {
        public UpdateDepartmentHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<DataExecutionResponse> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await DataAccess.ExecuteAsync(new UpdateDepartment(request.Name, request.Code));

            if (rowsAffected == 1)
            {
                return DataExecutionResponse.Success(rowsAffected);
            }

            return DataExecutionResponse.NotFound("Department", $"Code: {request.Code}");

        }
    }
}
