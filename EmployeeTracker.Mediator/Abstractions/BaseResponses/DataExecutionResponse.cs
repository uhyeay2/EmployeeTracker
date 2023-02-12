using EmployeeTracker.Mediator.Constants;

namespace EmployeeTracker.Mediator.Abstractions.BaseResponses
{
    public class DataExecutionResponse : BaseResponse
    {
        public DataExecutionResponse(int statusCode, int rowsAffected, string message) : base(statusCode)
        {
            RowsAffected = rowsAffected;

            Message = message;
        }

        public int RowsAffected { get; set; }
        public string Message { get; private set; }

        public static DataExecutionResponse Success(int rowsAffected) => 
            new(StatusCodes.Success, rowsAffected, $"Success! Rows Affected: {rowsAffected}");

        public static DataExecutionResponse UnExpected(int rowsAffected, string message) => 
            new(StatusCodes.UnExpected, rowsAffected, $"UnExpected Results! Rows Affected: {rowsAffected} - Extra Details: {message}");

        public static DataExecutionResponse AlreadyExists(string message) => 
            new(StatusCodes.AlreadyExists, 0, message);

        public static DataExecutionResponse NotFound(string objectNotFound, string parametersUsed) => 
            new(StatusCodes.NotFound, 0, $"{objectNotFound} not found - Parameters Used: {parametersUsed}");
    }
}
