using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Data.DataTransferObjects;
using EmployeeTracker.Mediator.Handlers.DepartmentHandlers;

namespace EmployeeTracker.Mediator.Tests.HandlerTests
{
    public class GetDepartmentByCodeHandlerTests : DataHandlerTest 
    {
        public GetDepartmentByCodeHandlerTests() => _handler = new(MockDataAccess.Object);

        private readonly GetDepartmentByCodeHandler _handler;

        private static readonly GetDepartmentByCodeRequest _request = new("Code");

        [Fact]
        public async Task GetDepartmentByCode_Given_NoDepartmentExists_Should_ReturnNotFoundResponse()
        {
            SetupFetch<GetDepartmentByCode, DepartmentDTO>(null!);

            var response = await _handler.Handle(_request, default);
                
            response.StatusCode.ShouldBe(StatusCodes.NotFound);
        }

        [Fact]
        public async Task GetDepartmentByCode_Given_DepartmentExists_Should_ReturnSuccessResponse()
        {
            SetupFetch<GetDepartmentByCode, DepartmentDTO>(new DepartmentDTO());

            var request = await _handler.Handle(_request, default);

            request.StatusCode.ShouldBe(StatusCodes.Success);
        }
    }
}
