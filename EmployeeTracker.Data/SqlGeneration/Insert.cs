namespace EmployeeTracker.Data.SqlGeneration
{
    internal static class Insert
    {
        public static string IntoTable(string table, params string[] values) => 
            $"INSERT INTO {table} ( {values.AggregateWithCommas()} ) VALUES ( {values.AggregateWithCommasForParameters()} )";
    }
}
