using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Data.Tests.DataRequestTests.DepartmentTests
{
    public class DepartmentCodeExistsTests: DataRequestTest
    {
        private static readonly DepartmentCodeExists _request = new("Code");

        [Fact]
        public async Task DepartmentCodeExists_Given_CodeDoesNotExist_Should_ReturnFalse()
        {
            InMemoryDatabase.CreateTableIfNotExists<DepartmentDTO>(Tables.Department);

            var exists = await DataAccess.FetchAsync<bool>(_request);

            Assert.False(exists);
        }

        [Fact]
        public async Task DepartmentCodeExists_Given_CodeDoesExist_Should_ReturnTrue()
        {
            InMemoryDatabase.Insert(Tables.Department, new DepartmentDTO() { Code = _request.Code });

            var exists = await DataAccess.FetchAsync<bool>(_request);

            Assert.True(exists);
        }
    }
}
