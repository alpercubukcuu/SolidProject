using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("You cannot leave the product name blank.");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("product name should be 3 characters");
            RuleFor(p => p.Stock).NotEmpty().WithMessage("You cannot leave the stock  blank.");
        }
    }
}
