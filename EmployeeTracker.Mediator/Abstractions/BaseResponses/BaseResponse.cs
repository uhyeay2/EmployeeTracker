namespace EmployeeTracker.Mediator.Abstractions.BaseResponses
{
    public class BaseResponse
    {
        public BaseResponse() { }

        public BaseResponse(int statusCode) => StatusCode = statusCode;

        public int StatusCode { get; set; }
    }
}
