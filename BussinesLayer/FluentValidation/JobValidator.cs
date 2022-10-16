using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.FluentValidation
{
    public class JobValidator:AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("You cannot leave the job name blank.");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("product name should be 3 characters.");         
        }
    }
}
