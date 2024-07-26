using FluentValidation;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Validation.Customer
{
    public class CustomerRequestValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required!")
                .NotNull().WithMessage("First name cannot be null!")
                .MinimumLength(2).WithMessage("First name must be at least 2 characters long!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required!")
                .NotNull().WithMessage("Last name cannot be null!")
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters long!");

            RuleFor(x => x.IdentityNumber)
                .NotEmpty().WithMessage("Identity number is required!")
                .NotNull().WithMessage("Identity number cannot be null!")
                .MinimumLength(11).WithMessage("Identity number must be at least 11 characters long!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required!")
                .NotNull().WithMessage("Email cannot be null!")
                .EmailAddress().WithMessage("Please provide a valid email address!");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required!")
                .NotNull().WithMessage("Date of birth cannot be null!")
                .LessThan(DateTime.Now).WithMessage("Date of birth must be a past date!");
        }
    }
}
