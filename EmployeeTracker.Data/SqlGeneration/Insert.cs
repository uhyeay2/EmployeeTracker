namespace EmployeeTracker.Data.SqlGeneration
{
    internal static class Insert
    {
        public static string IntoTable(string table, params string[] columns) => 
            $"INSERT INTO {table} ( {columns.AggregateWithCommas()} ) VALUES ( {columns.AggregateWithCommasForParameters()} )";
    }
}
