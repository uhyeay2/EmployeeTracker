using EmployeeTracker.Domain.Models;
using EmployeeTracker.Mediator.Abstractions.BaseResponses;
using EmployeeTracker.Mediator.Handlers.DepartmentHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTracker.Api.Controllers
{
    public class DepartmentController
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetDepartmentByCode")]
        public async Task<BaseResponse<Department>> GetDepartmentByCode(string code) => await _mediator.Send(new GetDepartmentByCodeRequest(code));

        [HttpGet("GetAllDepartments")]
        public async Task<BaseResponse<IEnumerable<Department>>> GetAllDepartments() => await _mediator.Send(new GetAllDepartmentsRequest());

        [HttpGet("DepartmentCodeExists")]
        public async Task<BaseResponse<bool>> DepartmentCodeExists(string code) => await _mediator.Send(new DepartmentCodeExistsRequest(code));

        [HttpPost("InsertDepartment")]
        public async Task<DataExecutionResponse> GetDepartmentByCode(InsertDepartmentRequest request) => await _mediator.Send(request);

        [HttpPost("UpdateDepartment")]
        public async Task<DataExecutionResponse> UpdateDepartment(Department department) => await _mediator.Send(new UpdateDepartmentRequest(department?.Code!, department?.Name!));

        [HttpDelete("DeleteDepartment")]
        public async Task<DataExecutionResponse> DeleteDepartmentByCode(string code) => await _mediator.Send(new DeleteDepartmentRequest(code));
    }
}
