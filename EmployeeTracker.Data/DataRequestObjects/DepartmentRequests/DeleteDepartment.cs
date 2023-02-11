namespace EmployeeTracker.Data.DataRequestObjects.DepartmentRequests
{
    public class DeleteDepartment : IDataRequest
    {
        public DeleteDepartment(string code) => Code = code;

        public string Code { get; set; }

        public object? GenerateParameters() => new { Code };

        public string GenerateSql() => Delete.FromTable(Tables.Department, where: "Code = @Code");
    }
}
