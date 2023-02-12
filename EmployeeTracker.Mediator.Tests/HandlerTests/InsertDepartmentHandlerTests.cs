using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Mediator.Handlers.DepartmentHandlers;

namespace EmployeeTracker.Mediator.Tests.HandlerTests
{
    public class InsertDepartmentHandlerTests : DataHandlerTest
    {
        public InsertDepartmentHandlerTests() => _handler = new(MockDataAccess.Object);

        private readonly InsertDepartmentHandler _handler;

        private static readonly InsertDepartmentRequest _request = new("code", "name");

        [Fact]
        public async Task InsertDepartment_Given_DepartmentAlreadyExists_Should_ReturnAlreadyExistsResponse()
        {
            SetupMockFetch<DepartmentCodeExists, bool>(true);

            var response = await _handler.Handle(_request, default);

            response.StatusCode.ShouldBe(StatusCodes.AlreadyExists);
        }

        [Fact]
        public async Task InsertDepartment_Given_DepartmentDoesNotExist_AndExecutionReturnsOne_Should_ReturnSuccessResponse()
        {
            SetupMockFetch<DepartmentCodeExists, bool>(false);

            SetupMockExecute<InsertDepartment>(1);

            var response = await _handler.Handle(_request, default);

            response.StatusCode.ShouldBe(StatusCodes.Success);
        }

        [Fact]
        public async Task InsertDepartment_Given_DepartmentDoesNotExist_AndExecutionDoesNotReturnOne_Should_ReturnUnExpectedResponse()
        {
            SetupMockFetch<DepartmentCodeExists, bool>(false);

            var response = await _handler.Handle(_request, default);

            response.StatusCode.ShouldBe(StatusCodes.UnExpected);
        }
    }
}
