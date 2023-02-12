using EmployeeTracker.Domain.Interfaces;

namespace EmployeeTracker.Api.Configurations
{
    public class DbConnectionConfig : IConfig
    {
        private static readonly IConfigurationRoot Root = new ConfigurationBuilder().AddJsonFile(ConfigKeys.Root).Build();

        public string GetConfig() => Root[ConfigKeys.DatabaseConnectionString];
    }
}
