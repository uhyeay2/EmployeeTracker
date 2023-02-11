using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Data.Tests.DataRequestTests.DepartmentTests
{
    public class GetAllDepartmentsTests : DataRequestTest
    {
        private static readonly IEnumerable<DepartmentDTO> _departments = new List<DepartmentDTO>()
        {
            new DepartmentDTO() { Id = 1, Code = "Code1", Name = "Name1"},
            new DepartmentDTO() { Id = 2, Code = "Code2", Name = "Name2"},
            new DepartmentDTO() { Id = 3, Code = "Code3", Name = "Name3"},
            new DepartmentDTO() { Id = 4, Code = "Code4", Name = "Name4"},
            new DepartmentDTO() { Id = 5, Code = "Code5", Name = "Name5"},
            new DepartmentDTO() { Id = 6, Code = "Code6", Name = "Name6"},
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
