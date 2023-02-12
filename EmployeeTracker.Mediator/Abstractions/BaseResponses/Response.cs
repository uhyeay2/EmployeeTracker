using EmployeeTracker.Mediator.Constants;

namespace EmployeeTracker.Mediator.Abstractions.BaseResponses
{
    internal static class Response
    {
        public static BaseResponse Success() => new(StatusCodes.Success);
        
        public static BaseResponse<TContent> Success<TContent>(TContent content) => new(StatusCodes.Success, content);    
        
        public static BaseResponse<TContent> NotFound<TContent>() => new(StatusCodes.NotFound);
    }
}
