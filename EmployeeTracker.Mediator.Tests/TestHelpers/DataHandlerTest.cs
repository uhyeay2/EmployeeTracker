using EmployeeTracker.Data.Interfaces;
using Moq;

namespace EmployeeTracker.Mediator.Tests.TestHelpers
{
    abstract public class DataHandlerTest
    {        
        protected Mock<IDataAccess> MockDataAccess;

        public DataHandlerTest()
        {
            MockDataAccess = new Mock<IDataAccess>();
        }

        protected void SetupFetch<TRequest, TMockResponse>(TMockResponse mockResponse) where TRequest : IDataRequest =>
             MockDataAccess.Setup(_ => _
                           .FetchAsync<TMockResponse>(It.IsAny<TRequest>()))
                           .Returns(Task.FromResult(mockResponse));

        protected void SetupFetchList<TRequest, TMockResponse>(IEnumerable<TMockResponse> mockResponse) where TRequest : IDataRequest =>
             MockDataAccess.Setup(_ => _
                           .FetchListAsync<TMockResponse>(It.IsAny<TRequest>()))
                           .Returns(Task.FromResult(mockResponse));

        protected void SetupExecute<TRequest>(int MockResponse) where TRequest : IDataRequest =>
             MockDataAccess.Setup(_ => _
                           .ExecuteAsync(It.IsAny<TRequest>()))
                           .Returns(Task.FromResult(MockResponse));    }
}
