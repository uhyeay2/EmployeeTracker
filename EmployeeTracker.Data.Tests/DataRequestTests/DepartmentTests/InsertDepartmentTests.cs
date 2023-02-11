using EmployeeTracker.Data.DataRequestObjects.DepartmentRequests;

namespace EmployeeTracker.Data.Tests.DataRequestTests.DepartmentTests
{
    public class InsertDepartmentTests : DataRequestTest
    {
        private static readonly InsertDepartment _request = new("DepartmentCode", "DepartmentName");

        [Fact]
        public async void InsertDepartment_Given_ValidRequest_Should_InsertRecord()
        {
            InMemoryDatabase.CreateTableIfNotExists<DepartmentDTO>(Tables.Department);

            await DataAccess.ExecuteAsync(_request);

            var countOfDepartments = InMemoryDatabase.FetchAll<DepartmentDTO>(Tables.Department).Count;

            Assert.True(countOfDepartments == 1);
        }

        [Fact]
        public async void InsertDepartment_Given_DepartmentCode_Should_InsertRecordWithCode()
        {
            InMemoryDatabase.CreateTableIfNotExists<DepartmentDTO>(Tables.Department);

            await DataAccess.ExecuteAsync(_request);

            var department = InMemoryDatabase.FetchSingle<DepartmentDTO>(Tables.Department);

            Assert.True(_request.Code == department.Code);
        }

        [Fact]
        public async void InsertDepartment_Given_DepartmentName_Should_InsertRecordWithName()
        {
            InMemoryDatabase.CreateTableIfNotExists<DepartmentDTO>(Tables.Department);

            await DataAccess.ExecuteAsync(_request);

            var department = InMemoryDatabase.FetchSingle<DepartmentDTO>(Tables.Department);

            Assert.True(_request.Name == department.Name);
        }
    }
}
