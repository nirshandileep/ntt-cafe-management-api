using System.ComponentModel.DataAnnotations;

namespace NTT.CafeManagement.Infrastructure.Core.CustomExceptions;

public class CustomValidationException : Exception
{
    public List<ValidationResult> ValidationResults;

    public CustomValidationException(List<ValidationResult> validationResults)
    {
        ValidationResults = validationResults;
    }

    public CustomValidationException(string errorMessage)
    {
        ValidationResults ??= new List<ValidationResult>();
        ValidationResults.Add(new ValidationResult(errorMessage));
    }

    public CustomValidationException(string errorMessage, string memberName)
    {
        ValidationResults ??= new List<ValidationResult>();
        ValidationResults.Add(new ValidationResult(errorMessage, new List<string> { memberName }));
    }
}
