using FluentValidation.Results;

namespace Gatherly.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> ValidationErrors { get; set; }
    public ValidationException(ValidationResult validation)
    {
        ValidationErrors = new List<string>();

        if (validation.Errors.Count > 0)
        {
            foreach(var error in validation.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }
    }
}