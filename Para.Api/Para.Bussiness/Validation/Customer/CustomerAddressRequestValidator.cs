using FluentValidation;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Validation.Customer
{
    public class CustomerAddressRequestValidator : AbstractValidator<CustomerAddressRequest>
    {
        public CustomerAddressRequestValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID cannot be empty!")
                .NotNull().WithMessage("Customer ID is a required field!");

            RuleFor(x => x.AddressLine)
                .NotEmpty().WithMessage("Address cannot be left blank!")
                .NotNull().WithMessage("Address is required!")
                .MinimumLength(10).WithMessage("Address should have a minimum length of 10 characters!");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City name cannot be empty!")
                .NotNull().WithMessage("City is required!")
                .MinimumLength(2).WithMessage("City should have at least 2 characters!");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country cannot be empty!")
                .NotNull().WithMessage("Country is required!")
                .MinimumLength(2).WithMessage("Country name should be at least 2 characters long!");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("Zip Code cannot be empty!")
                .NotNull().WithMessage("Zip Code is required!")
                .MinimumLength(4).WithMessage("Zip Code should have a minimum length of 4 characters!");
        }
    }
}
