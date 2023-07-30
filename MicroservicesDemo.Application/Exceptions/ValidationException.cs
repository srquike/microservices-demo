using FluentValidation.Results;

namespace MicroservicesDemo.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> ValidationFailures { get; } 

        public ValidationException(IEnumerable<ValidationFailure> failures)
        {
            ValidationFailures = failures
                .GroupBy(f => f.PropertyName, f => f.ErrorMessage)
                .ToDictionary(g => g.Key, g => g.ToArray());
        }
    }
}
