namespace EmployeeTracker.Data.DataTransferObjects
{
    public class DepartmentDTO
    {
        public DepartmentDTO() { }
        public DepartmentDTO(int id, string code, string name)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
