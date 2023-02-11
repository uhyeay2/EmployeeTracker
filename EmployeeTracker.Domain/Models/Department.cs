namespace EmployeeTracker.Domain.Models
{
    public class Department
    {
        public Department()
        {
        }

        public Department(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
