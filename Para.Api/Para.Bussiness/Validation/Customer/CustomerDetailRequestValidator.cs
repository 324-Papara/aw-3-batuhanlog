using FluentValidation;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Validation.Customer
{
    public class CustomerDetailRequestValidator : AbstractValidator<CustomerDetailRequest>
    {
        public CustomerDetailRequestValidator()
        {

            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId is required");
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("CustomerId must be greater than 0");

            RuleFor(x => x.FatherName).NotEmpty().WithMessage("FatherName is required");

            RuleFor(x => x.MotherName).NotEmpty().WithMessage("MotherName is required");

            RuleFor(x => x.EducationStatus).NotEmpty().WithMessage("EducationStatus is required");

            RuleFor(x => x.MontlyIncome).NotEmpty().WithMessage("MontlyIncome is required");

            RuleFor(x => x.Occupation).NotEmpty().WithMessage("Occupation is required");


        }
    }
}
