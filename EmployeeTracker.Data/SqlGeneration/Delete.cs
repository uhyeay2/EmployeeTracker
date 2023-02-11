namespace EmployeeTracker.Data.SqlGeneration
{
    internal static class Delete
    {
        internal static string FromTable(string table, string where) => $"DELETE FROM {table} WHERE {where}";

        internal static string AllFromTable(string table) => FromTable(table, "1 = 1");
    }
}
