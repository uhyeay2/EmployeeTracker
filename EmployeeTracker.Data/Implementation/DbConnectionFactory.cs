using EmployeeTracker.Domain.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeTracker.Data.Implementation
{
    internal class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfig _config;

        public DbConnectionFactory(IConfig config) => _config = config;

        public IDbConnection NewConnection() => new SqlConnection(_config.GetConfig());

    }
}
