using Dapper;
using EmployeeTracker.Data.Interfaces;

namespace EmployeeTracker.Data.Implementation
{
    internal class DataAccess : IDataAccess
    {
        private IDbConnectionFactory _dbconnectionFactory;

        public DataAccess(IDbConnectionFactory connectionFactory)
        {
            _dbconnectionFactory = connectionFactory;
        }

        public async Task<int> ExecuteAsync(IDataRequest request)
        {
            using var connection = _dbconnectionFactory.NewConnection();

            connection.Open();

            return await connection.ExecuteAsync(request.GenerateSql(), request.GenerateParameters());
        }

        public async Task<TOutput> FetchAsync<TOutput>(IDataRequest request)
        {
            using var connection = _dbconnectionFactory.NewConnection();

            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<TOutput>(request.GenerateSql(), request.GenerateParameters());
        }

        public async Task<IEnumerable<TOutput>> FetchListAsync<TOutput>(IDataRequest request)
        {
            using var connection = _dbconnectionFactory.NewConnection();

            connection.Open();

            return await connection.QueryAsync<TOutput>(request.GenerateSql(), request.GenerateParameters());
        }
    }
}
