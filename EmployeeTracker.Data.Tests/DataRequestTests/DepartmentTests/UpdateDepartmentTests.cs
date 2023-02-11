using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;
using EmployeeTracker.Domain.Models;

namespace EmployeeTracker.Data.Tests.DataRequestTests.DepartmentTests
{
    public class UpdateDepartmentTests : DataRequestTest
    {
        [Fact]
        public async Task UpdateDepartment_Given_NewName_Should_UpdateName()
        {
            var request = new UpdateDepartment(new Department("Code", "NewName"));

            InMemoryDatabase.Insert(Tables.Department, new DepartmentDTO() { Code = request.Department.Code });

            await DataAccess.ExecuteAsync(request);

            var department = InMemoryDatabase.FetchSingle<DepartmentDTO>(Tables.Department);

            Assert.True(request.Department.Name == department.Name);
        }

        [Fact]
        public async Task UpdateDepartment_Given_NameIsNull_Should_LeaveNameAsIs()
        {
            var expectedName = "OriginalName";

            var request = new UpdateDepartment(new Department() { Code = "Code", Name = null! });

            InMemoryDatabase.Insert(Tables.Department, new DepartmentDTO() { Code = request.Department.Code, Name = expectedName });

            await DataAccess.ExecuteAsync(request);

            var department = InMemoryDatabase.FetchSingle<DepartmentDTO>(Tables.Department);

            Assert.Equal(expectedName, department.Name);
        }
    }
}
