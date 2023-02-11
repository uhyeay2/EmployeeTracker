namespace EmployeeTracker.Data.DataRequestObjects.DepartmentRequests
{
    public class DepartmentCodeExists : IDataRequest
    {
        public DepartmentCodeExists(string code) => Code = code;

        public string Code { get; set; }

        public object? GenerateParameters() => new { Code };

        public string GenerateSql() => Exists.InTable(Tables.Department, "Code = @Code");
    }
}
