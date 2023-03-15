using Entities.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class RentalValidator : AbstractValidator<Rentals>
{
    public RentalValidator()
    {
        RuleFor(r => r.CarId).NotEmpty();
        RuleFor(r => r.CarId).GreaterThanOrEqualTo(1);
        RuleFor(r => r.CustomerId).GreaterThanOrEqualTo(1);
        RuleFor(r => r.CustomerId).NotEmpty();
        RuleFor(r => r.RentDate).NotEmpty();
    }
}