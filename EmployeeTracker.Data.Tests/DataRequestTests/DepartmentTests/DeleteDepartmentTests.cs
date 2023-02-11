using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Data.Tests.DataRequestTests.DepartmentTests
{
    public class DeleteDepartmentTests : DataRequestTest
    {
        private static readonly DeleteDepartment _request = new("DeleteDepartmentCode");

        [Fact]
        public async Task DeleteDepartment_Given_DepartmentExistsWithCode_Should_DeleteDepartment()
        {
            InMemoryDatabase.Insert(Tables.Department, new DepartmentDTO() { Code = _request.Code });

            await DataAccess.ExecuteAsync(_request);

            var count = InMemoryDatabase.FetchAll<DepartmentDTO>(Tables.Department).Count;

            Assert.True(count == 0);
        }
    }
}
