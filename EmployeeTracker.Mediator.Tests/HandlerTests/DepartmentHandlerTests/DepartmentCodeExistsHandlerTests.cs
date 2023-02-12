using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Mediator.Handlers.DepartmentHandlers;

namespace EmployeeTracker.Mediator.Tests.HandlerTests.DepartmentHandlerTests
{
    public class DepartmentCodeExistsHandlerTests : DataHandlerTest
    {
        public DepartmentCodeExistsHandlerTests() => _handler = new(MockDataAccess.Object);

        private readonly DepartmentCodeExistsHandler _handler;

        private static readonly DepartmentCodeExistsRequest _request = new("Code");

        [Fact]
        public async Task DepartmentCodeExists_Given_DepartmentExists_Should_ReturnTrue()
        {
            SetupMockFetch<DepartmentCodeExists, bool>(true);

            (await _handler.Handle(_request, default)).Content.ShouldBe(true);
        }

        [Fact]
        public async Task DepartmentCodeExists_Given_DepartmentDoesNotExist_Should_ReturnFalse()
        {
            SetupMockFetch<DepartmentCodeExists, bool>(false);

            (await _handler.Handle(_request, default)).Content.ShouldBe(false);
        }
    }
}
