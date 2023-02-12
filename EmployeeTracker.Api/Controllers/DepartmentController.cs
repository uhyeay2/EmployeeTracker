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

        [HttpGet("GetAllDepartments")]
        public async Task<BaseResponse<IEnumerable<Department>>> GetAllDepartments() => await _mediator.Send(new GetAllDepartmentsRequest());

        [HttpGet("GetDepartmentByCode")]
        public async Task<BaseResponse<Department>> GetDepartmentByCode(string code) => await _mediator.Send(new GetDepartmentByCodeRequest(code));

        [HttpPost("InsertDepartment")]
        public async Task<DataExecutionResponse> GetDepartmentByCode(InsertDepartmentRequest request) => await _mediator.Send(request);
    }
}
