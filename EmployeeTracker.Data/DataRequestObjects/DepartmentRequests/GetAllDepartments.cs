namespace EmployeeTracker.Data.DataRequestObjects.DepartmentRequests
{
    public class GetAllDepartments : IDataRequest
    {
        public object? GenerateParameters() => null;

        public string GenerateSql() => Select.AllFromTable(Tables.Department);
    }
}
