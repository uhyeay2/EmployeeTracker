namespace EmployeeTracker.Data.SqlGeneration
{
    internal static class Update
    {
        public static string SetTable(string table, string where, params string[] columns) =>
             $"UPDATE {Tables.Department} SET {columns.AggregateToSetValues()} WHERE {where}";

        public static string CoalesceTable(string table, string where, params string[] columns) =>
             $"UPDATE {Tables.Department} SET {columns.AggregateToCoalesceValues()} WHERE {where}";
    }
}
