using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Mediator.Handlers.DepartmentHandlers
{
    public class UpdateDepartmentRequest : BaseRequest<DataExecutionResponse>
    {
        public UpdateDepartmentRequest(Department department) => Department = department;

        public Department Department { get; set; }

    }

    internal class UpdateDepartmentHandler : DataHandler<UpdateDepartmentRequest, DataExecutionResponse>
    {
        public UpdateDepartmentHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<DataExecutionResponse> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await DataAccess.ExecuteAsync(new UpdateDepartment(request.Department));

            if (rowsAffected == 1)
            {
                return DataExecutionResponse.Success(rowsAffected);
            }

            return DataExecutionResponse.NotFound();

        }
    }
}
