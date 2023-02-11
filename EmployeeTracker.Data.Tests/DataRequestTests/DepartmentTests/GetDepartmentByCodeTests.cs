using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Data.Tests.DataRequestTests.DepartmentTests
{
    public class GetDepartmentByCodeTests : DataRequestTest
    {
        [Fact]
        public async Task GetDepartmentByCode_Given_DepartmentExistsWithCode_Should_ReturnDepartment()
        {
            var code = "FetchDepartmentCode";

            InMemoryDatabase.Insert(Tables.Department, new DepartmentDTO() { Code = code });

            var result = await DataAccess.FetchAsync<DepartmentDTO>(new GetDepartmentByCode(code));

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDepartmentByCode_Given_DepartmentDoesNotExistWithCode_Should_ReturnNull()
        {
            InMemoryDatabase.Insert(Tables.Department, new DepartmentDTO() { Code = "RandomCode" });

            var result = await DataAccess.FetchAsync<DepartmentDTO>(new GetDepartmentByCode("ReturnNull"));

            Assert.Null(result);
        }
    }
}
