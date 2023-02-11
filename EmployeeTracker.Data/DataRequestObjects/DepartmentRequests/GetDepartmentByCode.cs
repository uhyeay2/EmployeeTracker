namespace EmployeeTracker.Data.DataRequestObjects.DepartmentRequests
{
    public class GetDepartmentByCode : IDataRequest
    {
        public GetDepartmentByCode(string code) => Code = code;

        public string Code { get; set; }

        public object? GenerateParameters() => new { Code };

        public string GenerateSql() => Select.AllFromTable(Tables.Department, "Code = @Code");
    }
}
