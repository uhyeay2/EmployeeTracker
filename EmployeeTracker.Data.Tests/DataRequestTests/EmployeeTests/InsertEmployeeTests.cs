using EmployeeTracker.Data.DataRequestObjects.EmployeeRequests;

namespace EmployeeTracker.Data.Tests.DataRequestTests.EmployeeTests
{
    public class InsertEmployeeTests : DataRequestTest
    {
        private static readonly InsertEmployee _request = new (Guid.NewGuid(), "FirstName", "LastName", DateTime.Now, "EncryptedSSN");

        [Fact]
        public async Task InsertEmployee_Given_AllFields_Should_InsertRecord()
        {
            InMemoryDatabase.CreateTableIfNotExists<EmployeeDTO>(Tables.Employee);

            await DataAccess.ExecuteAsync(_request);

            var result = InMemoryDatabase.FetchSingle<EmployeeDTO>(Tables.Employee);

            Assert.NotNull(result);
        }
    }
}
