using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Data.DataTransferObjects;

namespace EmployeeTracker.Mediator.Handlers.DepartmentHandlers
{
    public class GetDepartmentByCodeRequest : BaseValidatableRequest<BaseResponse<Department>>
    {
        public GetDepartmentByCodeRequest(string code) => Code = code;

        public string Code { get; internal set; } 

        public override bool IsValid(out List<ValidationFailure> validationFailures)
        {
            validationFailures = new List<ValidationFailure>();

            validationFailures.RequiredStrings((nameof(Code), Code));

            return validationFailures.Any();
        }
    }

    internal class GetDepartmentByCodeHandler : DataHandler<GetDepartmentByCodeRequest, BaseResponse<Department>>
    {
        public GetDepartmentByCodeHandler(IDataAccess dataAccess) : base(dataAccess) { }

        public override async Task<BaseResponse<Department>> Handle(GetDepartmentByCodeRequest request, CancellationToken cancellationToken)
        {
            var department = await DataAccess.FetchAsync<DepartmentDTO>(new GetDepartmentByCode(request.Code));

            if (department == null)
            {
                return Response.NotFound<Department>();
            }

            return Response.Success(new Department(department.Code, department.Name));
        }
    }
}
