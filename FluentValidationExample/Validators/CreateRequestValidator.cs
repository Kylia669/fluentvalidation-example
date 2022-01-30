using FluentValidation;
using FluentValidationExample.Models;

namespace FluentValidationExample.Validators
{
    public class CreateRequestValidator : AbstractValidator<CreateRequest>
    {
        public CreateRequestValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty();
            RuleFor(r => r.Date.ToUniversalTime()).LessThan(DateTime.UtcNow);
        }
    }
}
