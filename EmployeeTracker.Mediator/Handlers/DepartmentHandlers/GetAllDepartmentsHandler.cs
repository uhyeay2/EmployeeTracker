using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Data.DataTransferObjects;

namespace EmployeeTracker.Mediator.Handlers.DepartmentHandlers
{
    public class GetAllDepartmentsRequest : BaseRequest<BaseResponse<IEnumerable<Department>>> { }

    internal class GetAllDepartmentsHandler : DataHandler<GetAllDepartmentsRequest, BaseResponse<IEnumerable<Department>>>
    {
        public GetAllDepartmentsHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<BaseResponse<IEnumerable<Department>>> Handle(GetAllDepartmentsRequest request, CancellationToken cancellationToken)
        {
            var results = await DataAccess.FetchListAsync<DepartmentDTO>(new GetAllDepartments());
            
            if(results.Any())
            {
                return Response.Success(results.Select(x => new Department(x.Code, x.Name)));
            }

            return Response.NotFound<IEnumerable<Department>>();
        }
    }
}
