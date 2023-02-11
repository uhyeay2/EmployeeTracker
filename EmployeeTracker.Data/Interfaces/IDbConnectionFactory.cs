using System.Data;

namespace EmployeeTracker.Data.Interfaces
{
    internal interface IDbConnectionFactory
    {
        public IDbConnection NewConnection();
    }
}
