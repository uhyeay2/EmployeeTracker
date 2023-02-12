using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Data.DataTransferObjects;
using EmployeeTracker.Mediator.Handlers.DepartmentHandlers;

namespace EmployeeTracker.Mediator.Tests.HandlerTests.DepartmentHandlerTests
{
    public class GetDepartmentByCodeHandlerTests : DataHandlerTest
    {
        public GetDepartmentByCodeHandlerTests() => _handler = new(MockDataAccess.Object);

        private readonly GetDepartmentByCodeHandler _handler;

        private static readonly GetDepartmentByCodeRequest _request = new(_expectedCode);

        private static readonly DepartmentDTO _testDTO = new(id: 1, _expectedCode, _expectedName);

        private const string _expectedCode = "Code";
        private const string _expectedName = "Name";

        [Fact]
        public async Task GetDepartmentByCode_Given_NoDepartmentExists_Should_ReturnNotFoundResponse()
        {
            SetupMockFetch<GetDepartmentByCode, DepartmentDTO>(null!);

            (await _handler.Handle(_request, default)).StatusCode.ShouldBe(StatusCodes.NotFound);
        }

        [Fact]
        public async Task GetDepartmentByCode_Given_DepartmentExists_Should_ReturnSuccessResponse()
        {
            SetupMockFetch<GetDepartmentByCode, DepartmentDTO>(_testDTO);

            (await _handler.Handle(_request, default)).StatusCode.ShouldBe(StatusCodes.Success);
        }

        [Fact]
        public async Task GetDepartmentByCode_Given_DepartmentExists_Should_ReturnCorrectName()
        {
            SetupMockFetch<GetDepartmentByCode, DepartmentDTO>(_testDTO);

            (await _handler.Handle(_request, default))?.Content?.Name.ShouldBe(_expectedName);
        }

        [Fact]
        public async Task GetDepartmentByCode_Given_DepartmentExists_Should_ReturnCorrectCode()
        {
            SetupMockFetch<GetDepartmentByCode, DepartmentDTO>(_testDTO);

            (await _handler.Handle(_request, default))?.Content?.Code.ShouldBe(_expectedCode);
        }
    }
}
