using Entities.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class UserValidator : AbstractValidator<Users>
{
    public UserValidator()
    {
        RuleFor(u => u.FirstName).NotEmpty();
        RuleFor(u => u.FirstName).MinimumLength(3);
        RuleFor(u => u.LastName).NotEmpty();
        RuleFor(u => u.LastName).MinimumLength(3);
        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.Email).MinimumLength(7);
        RuleFor(u => u.Password).MinimumLength(8);
        RuleFor(u => u.Password).NotEmpty();
    }
}