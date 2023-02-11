namespace EmployeeTracker.Data.Interfaces
{
    public interface IDataAccess
    {
        public Task<int> ExecuteAsync(IDataRequest request);

        public Task<TOutput> FetchAsync<TOutput>(IDataRequest request);

        public Task<IEnumerable<TOutput>> FetchListAsync<TOutput>(IDataRequest request);
    }
}
