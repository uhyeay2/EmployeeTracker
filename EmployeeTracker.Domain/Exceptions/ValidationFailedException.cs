using EmployeeTracker.Domain.Models;

namespace EmployeeTracker.Domain.Exceptions
{
    public class ValidationFailedException : Exception
    {
        public ValidationFailedException(IEnumerable<ValidationFailure> validationFailures)
        {
            ValidationFailures = validationFailures;
        }

        public IEnumerable<ValidationFailure> ValidationFailures { get; set; }
    }
}
