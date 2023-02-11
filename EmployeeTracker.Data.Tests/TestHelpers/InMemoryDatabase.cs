using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System.Data;

namespace EmployeeTracker.Data.Tests.TestHelpers
{
    public class InMemoryDatabase
    {
        private readonly OrmLiteConnectionFactory _dbFactory = new(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public IDbConnection NewConnection() => _dbFactory.OpenDbConnection();

        public void Insert<T>(string tableName, IEnumerable<T> items)
        {
            using var db = NewConnection();

            db.CreateTableIfNotExists<T>(tableName);

            foreach (var item in items)
            {
                db.Insert(item, tableName);
            }
        }

        public void Insert<T>(string tableName, T item)
        {
            using var db = NewConnection();

            db.CreateTableIfNotExists<T>(tableName);
            
            db.Insert(item, tableName);
        }

        public void CreateTableIfNotExists<T>(string tableName)
        {
            using var db = NewConnection();

            db.CreateTableIfNotExists<T>(tableName);
        }

        public List<T> FetchAll<T>(string tableName)
        {
            using var db = NewConnection();

            return db.Select<T>(tableName);
        }

        public T FetchSingle<T>(string tableName) => FetchAll<T>(tableName).Single();
    }

    /// <summary>
    /// Extensions to allow for specifying table names
    /// </summary>
    internal static class GenericTableExtensions
    {
        static object ExecWithAlias<T>(string table, Func<object> fn)
        {
            var modelDef = typeof(T).GetModelMetadata();
            lock (modelDef)
            {
                var hold = modelDef.Alias;
                try
                {
                    modelDef.Alias = table;
                    return fn();
                }
                finally
                {
                    modelDef.Alias = hold;
                }
            }
        }

        public static List<T> Select<T>(this IDbConnection db, string table) =>
            (List<T>)ExecWithAlias<T>(table, () => db.Select(db.From<T>()));

        public static void CreateTableIfNotExists<T>(this IDbConnection db, string table) =>
            ExecWithAlias<T>(table, () => { db.CreateTableIfNotExists<T>(); return null!; });

        public static long Insert<T>(this IDbConnection db, T obj, string table, bool selectIdentity = false) =>
            (long)ExecWithAlias<T>(table, () => db.Insert(obj, selectIdentity));
    }
}
