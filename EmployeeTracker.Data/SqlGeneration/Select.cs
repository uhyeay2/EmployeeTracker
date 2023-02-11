namespace EmployeeTracker.Data.SqlGeneration
{
    internal static class Select
    {
        internal static string FromTable(string table) => $"SELECT * FROM {table}";

        internal static string FromTable(string table, string where) => $"SELECT * FROM {table} WHERE {where}";
    }
}
