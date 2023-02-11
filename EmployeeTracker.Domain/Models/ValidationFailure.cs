namespace EmployeeTracker.Domain.Models
{
    public class ValidationFailure
    {
        public ValidationFailure(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
