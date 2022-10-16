using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("You cannot leave the customer name blank.");
            RuleFor(p => p.City).NotEmpty().WithMessage("You cannot leave the city blank.");
        }
    }
}
