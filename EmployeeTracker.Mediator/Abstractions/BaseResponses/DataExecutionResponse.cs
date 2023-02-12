using EmployeeTracker.Mediator.Constants;

namespace EmployeeTracker.Mediator.Abstractions.BaseResponses
{
    public class DataExecutionResponse : BaseResponse
    {
        public DataExecutionResponse(int statusCode, int rowsAffected) : base(statusCode) => RowsAffected = rowsAffected;        

        public int RowsAffected { get; set; }

        public static DataExecutionResponse Success(int rowsAffected) => new(StatusCodes.Success, rowsAffected);

        public static DataExecutionResponse UnExpected(int rowsAffected) => new(StatusCodes.UnExpected, rowsAffected);

        public static DataExecutionResponse AlreadyExists() => new(StatusCodes.AlreadyExists, 0);

        public static DataExecutionResponse NotFound() => new(StatusCodes.NotFound, 0);
    }
}
