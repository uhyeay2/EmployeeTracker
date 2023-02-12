using EmployeeTracker.Data.Implementation;
using EmployeeTracker.Data.Interfaces;
using Moq;

namespace EmployeeTracker.Data.Tests.TestHelpers
{
    public abstract class DataRequestTest
    {
        protected readonly InMemoryDatabase InMemoryDatabase;

        protected readonly IDataAccess DataAccess;

        public DataRequestTest()
        {
            InMemoryDatabase = new InMemoryDatabase();

            var mockConnectionFactory = new Mock<IDbConnectionFactory>();

            mockConnectionFactory.Setup(_ => _.NewConnection()).Returns(InMemoryDatabase.NewConnection());

            DataAccess = new DataAccess(mockConnectionFactory.Object);
        }
    }
}
