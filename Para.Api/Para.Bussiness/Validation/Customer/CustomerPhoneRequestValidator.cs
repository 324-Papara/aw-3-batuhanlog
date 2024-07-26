using FluentValidation;
using Para.Schema;

namespace Para.Bussiness.Validation.Customer
{
    public class CustomerPhoneRequestValidator : AbstractValidator<CustomerPhoneRequest>
    {
        public CustomerPhoneRequestValidator()
        {
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number cannot be empty!")
                .NotNull().WithMessage("Phone number is required!")
                .MinimumLength(10).WithMessage("Phone number must be at least 10 characters long!");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required!")
                .NotNull().WithMessage("Customer ID cannot be null!");

            RuleFor(x => x.CountyCode)
                .NotEmpty().WithMessage("Country code is required!")
                .NotNull().WithMessage("Country code cannot be null!")
                .MinimumLength(2).WithMessage("Country code must be at least 2 characters long!");
        }
    }
}
