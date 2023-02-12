namespace EmployeeTracker.Mediator.Abstractions.BaseResponses
{
    public class BaseResponse
    {
        public BaseResponse(int statusCode) => StatusCode = statusCode;

        public int StatusCode { get; set; }
    }

    public class BaseResponse<TContent> : BaseResponse
    {
        public BaseResponse(int statusCode) : base(statusCode) { }

        public BaseResponse(int statusCode, TContent? content) : base(statusCode) =>  Content = content;

        public TContent? Content { get; set; }
    }
}
