namespace EmployeeTracker.Mediator.Abstractions.BaseRequests
{
    public abstract class RequiredCodeRequest<TResponse> : BaseValidatableRequest<TResponse> where TResponse : BaseResponse
    {
        public RequiredCodeRequest(string code) => Code = code;

        public string Code { get; set; } = null!;

        public override bool IsValid(out List<ValidationFailure> validationFailures)
        {
            validationFailures = new List<ValidationFailure>();

            validationFailures.RequiredStrings((nameof(Code), Code));

            return validationFailures.Count == 0;
        }
    }
}
