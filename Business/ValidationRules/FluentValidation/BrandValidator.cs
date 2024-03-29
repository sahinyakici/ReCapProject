﻿using Entities.Concretes;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class BrandValidator : AbstractValidator<Brand>
{
    public BrandValidator()
    {
        RuleFor(b => b.Name).NotEmpty();
        RuleFor(b => b.Name).MinimumLength(3);
    }
}