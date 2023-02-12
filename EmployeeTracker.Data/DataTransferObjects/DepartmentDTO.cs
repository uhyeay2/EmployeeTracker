namespace EmployeeTracker.Data.DataTransferObjects
{
    public class DepartmentDTO
    {
        public DepartmentDTO() { }
        public DepartmentDTO(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;
    }
}
