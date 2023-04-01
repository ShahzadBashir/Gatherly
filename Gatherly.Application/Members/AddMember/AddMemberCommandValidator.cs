using FluentValidation;

namespace Gatherly.Application.Members.AddMember;

public class AddMemberCommandValidator : AbstractValidator<AddMemberCommand>
{
    public AddMemberCommandValidator()
    {
        RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("{PropertyName} should be a valid email address.")
            .MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 characters.")
            .NotEmpty().WithMessage("{PropertyName} should not be empty")
            .NotNull();

        RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 characters.")
            .NotEmpty().WithMessage("{PropertyName} should not be empty")
            .NotNull();

        RuleFor(x => x.LastName).MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 characters.")
            .NotEmpty().WithMessage("{PropertyName} should not be empty")
            .NotNull();
    }
}