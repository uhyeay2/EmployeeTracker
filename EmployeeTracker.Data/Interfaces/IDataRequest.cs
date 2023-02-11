namespace EmployeeTracker.Data.Interfaces
{
    public interface IDataRequest
    {
        public string GenerateSql();

        public object? GenerateParameters();
    }
}
