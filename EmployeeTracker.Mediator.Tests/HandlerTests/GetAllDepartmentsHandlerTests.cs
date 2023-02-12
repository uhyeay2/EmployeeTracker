using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Data.DataTransferObjects;
using EmployeeTracker.Mediator.Handlers.DepartmentHandlers;

namespace EmployeeTracker.Mediator.Tests.HandlerTests
{
    public class GetAllDepartmentsHandlerTests : DataHandlerTest
    {
        public GetAllDepartmentsHandlerTests() => _handler = new(MockDataAccess.Object);

        private readonly GetAllDepartmentsHandler _handler;

        private static readonly GetAllDepartmentsRequest _request = new();

        private static readonly IEnumerable<DepartmentDTO> _departments = new List<DepartmentDTO>()
        {
            new DepartmentDTO(1, "Code1", "Name1"),
            new DepartmentDTO(2, "Code2", "Name2"),
            new DepartmentDTO(3, "Code3", "Name3"),
            new DepartmentDTO(4, "Code4", "Name4"),
            new DepartmentDTO(5, "Code5", "Name5"),
            new DepartmentDTO(6, "Code6", "Name6"),
        };

        [Fact]
        public async Task GetAllDepartments_Given_DepartmentsDoNotExist_Should_ReturnNotFoundResponse()
        {
            SetupMockFetchList<GetAllDepartments, DepartmentDTO>(Enumerable.Empty<DepartmentDTO>());

            (await _handler.Handle(_request, default)).StatusCode.ShouldBe(StatusCodes.NotFound);
        }

        [Fact]
        public async Task GetAllDepartments_Given_DepartmentsExist_Should_ReturnSuccessResponse()
        {
            SetupMockFetchList<GetAllDepartments, DepartmentDTO>(_departments);

            (await _handler.Handle(_request, default)).StatusCode.ShouldBe(StatusCodes.Success);
        }

        [Fact]
        public async Task GetAllDepartments_Given_DepartmentsExist_Should_ReturnCorrectCodes()
        {
            SetupMockFetchList<GetAllDepartments, DepartmentDTO>(_departments);

            var response = await _handler.Handle(_request, default);

            Assert.NotNull(response?.Content);

            var codesMatch = response.Content.Select((x, i) => x.Code == _departments.ElementAt(i).Code);

            codesMatch.ShouldAllBe(x => x == true);
        }

        [Fact]
        public async Task GetAllDepartments_Given_DepartmentsExist_Should_ReturnCorrectNames()
        {
            SetupMockFetchList<GetAllDepartments, DepartmentDTO>(_departments);

            var response = await _handler.Handle(_request, default);

            Assert.NotNull(response?.Content);

            var codesMatch = response.Content.Select((x, i) => x.Name == _departments.ElementAt(i).Name);

            codesMatch.ShouldAllBe(x => x == true);
        }
    }
}
