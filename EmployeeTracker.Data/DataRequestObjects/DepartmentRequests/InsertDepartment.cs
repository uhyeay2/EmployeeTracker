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

        public string GenerateSql() => "INSERT INTO Department (Code, Name) VALUES (@Code, @Name)";
    }
}
