using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Mediator.Handlers.DepartmentHandlers;

namespace EmployeeTracker.Mediator.Tests.HandlerTests.DepartmentHandlerTests
{
    public class DeleteDepartmentHandlerTests : DataHandlerTest
    {
        public DeleteDepartmentHandlerTests() => _handler = new(MockDataAccess.Object);

        private readonly DeleteDepartmentHandler _handler;

        private static readonly DeleteDepartmentRequest _request = new("Code");

        [Fact]
        public async Task DeleteDepartment_Given_DepartmentIsDeleted_Should_ReturnSuccessResponse()
        {
            SetupMockExecute<DeleteDepartment>(1);

            (await _handler.Handle(_request, default)).StatusCode.ShouldBe(StatusCodes.Success);
        }

        [Fact]
        public async Task DeleteDepartment_Given_DepartmentIsNotDelete_Should_ReturnNotFoundResponse()
        {
            SetupMockExecute<DeleteDepartment>(0);

            (await _handler.Handle(_request, default)).StatusCode.ShouldBe(StatusCodes.NotFound);
        }
    }
}
