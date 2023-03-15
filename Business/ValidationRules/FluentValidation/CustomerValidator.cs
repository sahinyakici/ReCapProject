using Entities.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class CustomerValidator : AbstractValidator<Customers>
{
    public CustomerValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.UserId).GreaterThanOrEqualTo(1);
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.CompanyName).MinimumLength(3);
    }
}