using EmployeeTracker.Domain.Models;

namespace EmployeeTracker.Domain.Interfaces
{
    public interface IValidatable
    {
        public bool IsValid(out List<ValidationFailure> validationFailures);
    }
}
