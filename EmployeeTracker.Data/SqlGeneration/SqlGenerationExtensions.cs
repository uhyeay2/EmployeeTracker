namespace EmployeeTracker.Data.SqlGeneration
{
    internal static class SqlGenerationExtensions
    {
        internal static string AggregateWithCommas(this IEnumerable<string> strings) =>
            strings?.Aggregate((a, b) => $"{a}, {b}") ?? string.Empty;

        internal static string AggregateWithCommasForParameters(this IEnumerable<string> strings) =>
            strings?.Select(x => $"@{x}").AggregateWithCommas() ?? string.Empty;
    }
}
