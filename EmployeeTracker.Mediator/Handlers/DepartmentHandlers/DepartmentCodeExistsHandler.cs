using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Mediator.Handlers.DepartmentHandlers
{
    public class DepartmentCodeExistsRequest : RequiredCodeRequest<BaseResponse<bool>>
    {
        public DepartmentCodeExistsRequest(string code) : base(code) { }
    }

    internal class DepartmentCodeExistsHandler : DataHandler<DepartmentCodeExistsRequest, BaseResponse<bool>>
    {
        public DepartmentCodeExistsHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<BaseResponse<bool>> Handle(DepartmentCodeExistsRequest request, CancellationToken cancellationToken)
        {
            return Response.Success(await DataAccess.FetchAsync<bool>(new DepartmentCodeExists(request.Code)));
        }
    }
}
