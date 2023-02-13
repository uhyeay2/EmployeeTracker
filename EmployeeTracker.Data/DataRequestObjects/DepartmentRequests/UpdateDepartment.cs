namespace EmployeeTracker.Data.DataRequestObjects.DepartmentRequests
{
    public class UpdateDepartment : IDataRequest
    {
        public UpdateDepartment(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public object? GenerateParameters() => new { Code, Name };

        public string GenerateSql() => Update.CoalesceTable(Tables.Department, "Code = @Code", "Name");
    }
}
