using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Data.Tests.DataRequestTests.DepartmentTests
{
    public class UpdateDepartmentTests : DataRequestTest
    {
        private static readonly UpdateDepartment _request = new ("Code", "NewName");

        [Fact]
        public async Task UpdateDepartment_Given_NewName_Should_UpdateName()
        {
            InMemoryDatabase.Insert(Tables.Department, new DepartmentDTO() { Code = _request.Code });

            await DataAccess.ExecuteAsync(_request);

            var department = InMemoryDatabase.FetchSingle<DepartmentDTO>(Tables.Department);

            Assert.True(_request.Name == department.Name);
        }

        [Fact]
        public async Task UpdateDepartment_Given_NameIsNull_Should_LeaveNameAsIs()
        {
            var expectedName = "OriginalName";

            var request = new UpdateDepartment("Code", null!);

            InMemoryDatabase.Insert(Tables.Department, new DepartmentDTO() { Code = request.Code, Name = expectedName });

            await DataAccess.ExecuteAsync(request);

            var department = InMemoryDatabase.FetchSingle<DepartmentDTO>(Tables.Department);

            Assert.Equal(expectedName, department.Name);
        }

        [Fact]
        public async Task UpdateDepartment_Given_DepartmentNotExistsWithCode_Should_ReturnZero()
        {
            InMemoryDatabase.CreateTableIfNotExists<DepartmentDTO>(Tables.Department);

            var result = await DataAccess.ExecuteAsync(_request);

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task UpdateDepartment_Given_DepartmentExistsWithCode_Should_ReturnOne()
        {
            InMemoryDatabase.Insert(Tables.Department, new DepartmentDTO() { Code = _request.Code });

            var result = await DataAccess.ExecuteAsync(_request);

            Assert.Equal(1, result);
        }
    }
}
