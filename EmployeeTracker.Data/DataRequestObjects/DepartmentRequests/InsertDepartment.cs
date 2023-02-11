namespace EmployeeTracker.Data.DataRequestObjects.DepartmentRequests
{
    public class InsertDepartment : IDataRequest
    {
        public InsertDepartment(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public object? GenerateParameters() => new { Code, Name };

        public string GenerateSql() => Insert.IntoTable(Tables.Department, "Code", "Name");
    }
}
