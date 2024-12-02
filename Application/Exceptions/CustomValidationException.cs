using FluentValidation.Results;

namespace NTT.CafeManagement.Application.Exceptions
{
    public class CustomValidationException : ValidationException
    {
        public CustomValidationException(string errorMessage) : base(GetValidationFailureMessage(errorMessage))
        {
        }

        private static List<ValidationFailure> GetValidationFailureMessage(string errorMessage)
        {
            return new List<ValidationFailure>
            {
                new ValidationFailure
                {
                    ErrorMessage = errorMessage
                }
            };
        }
    }
}
