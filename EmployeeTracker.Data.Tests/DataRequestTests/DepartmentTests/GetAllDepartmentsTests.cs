using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Data.Tests.DataRequestTests.DepartmentTests
{
    public class GetAllDepartmentsTests : DataRequestTest
    {
        private static readonly IEnumerable<DepartmentDTO> _departments = new List<DepartmentDTO>()
        {
            new DepartmentDTO(1, "Code1", "Name1"),
            new DepartmentDTO(2, "Code2", "Name2"),
            new DepartmentDTO(3, "Code3", "Name3"),
            new DepartmentDTO(4, "Code4", "Name4"),
            new DepartmentDTO(5, "Code5", "Name5"),
            new DepartmentDTO(6, "Code6", "Name6"),
        };

        private static readonly GetAllDepartments _request = new();

        [Fact]
        public async Task GetAllDepartments_Given_DepartmentsExist_Should_GetAllDepartments()
        {
            InMemoryDatabase.Insert(Tables.Department, _departments);

            var results = await DataAccess.FetchListAsync<DepartmentDTO>(_request);

            Assert.Equal(_departments.Count(), results.Count());
        }

        [Fact]
        public async Task GetAllDepartments_Given_DepartmentsDoNotExist_Should_ReturnEmptyCollection()
        {
            InMemoryDatabase.CreateTableIfNotExists<DepartmentDTO>(Tables.Department);

            var results = await DataAccess.FetchListAsync<DepartmentDTO>(_request);

            Assert.Empty(results);
        }
    }
}
