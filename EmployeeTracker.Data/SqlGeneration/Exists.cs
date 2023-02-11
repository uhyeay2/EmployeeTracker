namespace EmployeeTracker.Data.SqlGeneration
{
    public static class Exists
    {
        /// <summary>
        /// Sql SELECT statement that will return 1 if record exists, else return 0
        /// </summary>
        public static string InTable(string table, string where, string column = "*") =>
              $"SELECT CASE WHEN EXISTS(SELECT {column} FROM {table} WHERE {where}) THEN 1 ELSE 0 END";
    }
}
