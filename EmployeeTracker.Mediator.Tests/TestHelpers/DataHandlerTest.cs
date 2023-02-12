using EmployeeTracker.Data.Interfaces;
using Moq;

namespace EmployeeTracker.Mediator.Tests.TestHelpers
{
    abstract public class DataHandlerTest
    {        
        protected readonly Mock<IDataAccess> MockDataAccess;

        public DataHandlerTest() => MockDataAccess = new();

        protected void SetupMockFetch<TRequest, TMockResponse>(TMockResponse mockResponse) where TRequest : IDataRequest =>
             MockDataAccess.Setup(_ => _
                           .FetchAsync<TMockResponse>(It.IsAny<TRequest>()))
                           .Returns(Task.FromResult(mockResponse));

        protected void SetupMockFetchList<TRequest, TMockResponse>(IEnumerable<TMockResponse> mockResponse) where TRequest : IDataRequest =>
             MockDataAccess.Setup(_ => _
                           .FetchListAsync<TMockResponse>(It.IsAny<TRequest>()))
                           .Returns(Task.FromResult(mockResponse));

        protected void SetupMockExecute<TRequest>(int MockResponse) where TRequest : IDataRequest =>
             MockDataAccess.Setup(_ => _
                           .ExecuteAsync(It.IsAny<TRequest>()))
                           .Returns(Task.FromResult(MockResponse));    }
}
