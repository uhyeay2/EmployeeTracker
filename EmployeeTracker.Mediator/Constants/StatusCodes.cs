using System.Net;

namespace EmployeeTracker.Mediator.Constants
{
    public static class StatusCodes
    {
        public const int Success = (int)HttpStatusCode.OK;
        
        public const int NotFound = (int)HttpStatusCode.NotFound;

        public const int Conflict = (int)HttpStatusCode.Conflict;

        public const int AlreadyExists = (int)HttpStatusCode.Forbidden;

        public const int BadRequest = (int)HttpStatusCode.BadRequest;

        public const int UnExpected = (int)HttpStatusCode.InternalServerError;
    }
}
