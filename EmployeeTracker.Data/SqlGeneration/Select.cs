namespace EmployeeTracker.Data.SqlGeneration
{
    internal static class Select
    {
        internal static string AllFromTable(string table) => $"SELECT * FROM {table}";

        internal static string AllFromTable(string table, string where) => $"SELECT * FROM {table} WHERE {where}";
    }
}
