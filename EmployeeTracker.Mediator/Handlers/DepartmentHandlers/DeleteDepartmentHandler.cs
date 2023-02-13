using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Mediator.Handlers.DepartmentHandlers
{
    public class DeleteDepartmentRequest : RequiredCodeRequest<DataExecutionResponse>
    {
        public DeleteDepartmentRequest(string code) : base(code) { }
    }

    internal class DeleteDepartmentHandler : DataHandler<DeleteDepartmentRequest, DataExecutionResponse>
    {
        public DeleteDepartmentHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<DataExecutionResponse> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await DataAccess.ExecuteAsync(new DeleteDepartment(request.Code));

            if (rowsAffected == 1)
            {
                return DataExecutionResponse.Success(rowsAffected);
            }

            return DataExecutionResponse.NotFound("Department", $"Code: {request.Code}");
        }
    }
}
