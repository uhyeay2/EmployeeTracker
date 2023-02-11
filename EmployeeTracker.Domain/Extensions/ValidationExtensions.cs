using EmployeeTracker.Domain.Models;

namespace EmployeeTracker.Domain.Extensions
{
    public static class ValidationExtensions
    {
        public static List<ValidationFailure> RequiredStrings(this List<ValidationFailure> validationFailures, params (string Name, string Value)[] requiredFields)
        {
            var missingFields = requiredFields.Where(x => string.IsNullOrWhiteSpace(x.Value));

            foreach (var (name, value) in missingFields)
            {
                validationFailures.Add(new(name, $"Validation Failed - {nameof(name)} cannot be null/empty/whitespace - Value: {value}"));
            }

            return validationFailures;
        }
    }
}
