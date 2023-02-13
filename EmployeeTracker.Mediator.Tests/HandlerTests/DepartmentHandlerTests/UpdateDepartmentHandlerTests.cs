using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Mediator.Handlers.DepartmentHandlers;

namespace EmployeeTracker.Mediator.Tests.HandlerTests.DepartmentHandlerTests
{
    public class UpdateDepartmentHandlerTests : DataHandlerTest
    {
        public UpdateDepartmentHandlerTests() => _handler = new(MockDataAccess.Object);

        private readonly UpdateDepartmentHandler _handler;

        private static readonly UpdateDepartmentRequest _request = new("Code", "Name");

        [Fact]
        public async Task UpdateDepartment_Given_NoDepartmentUpdated_Should_ReturnNotFoundResponse()
        {
            SetupMockExecute<UpdateDepartment>(0);

            (await _handler.Handle(_request, default)).StatusCode.ShouldBe(StatusCodes.NotFound);
        }

        [Fact]
        public async Task UpdateDepartment_Given_DepartmentUpdated_Should_ReturnSuccessResponse()
        {
            SetupMockExecute<UpdateDepartment>(1);

            (await _handler.Handle(_request, default)).StatusCode.ShouldBe(StatusCodes.Success);
        }
    }
}
