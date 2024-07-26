using AutoMapper;
using FluentValidation;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Validation.Customer;
using Para.Data.UnitOfWork;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerPhone.CreateCustomerPhone
{
    public class CreateCustomerPhoneCommandHandler : IRequestHandler<CreateCustomerPhoneCommand, ApiResponse<CustomerPhoneResponse>>
    {
        private readonly IUnitOfWork<Para.Data.Domain.CustomerPhone> unitOfWork;
        private readonly IMapper mapper;

        public CreateCustomerPhoneCommandHandler(IUnitOfWork<Para.Data.Domain.CustomerPhone> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CustomerPhoneResponse>> Handle(CreateCustomerPhoneCommand request, CancellationToken cancellationToken)
        {
            CustomerPhoneRequestValidator validator = new CustomerPhoneRequestValidator();
            await validator.ValidateAndThrowAsync(request.Request);

            var mapped = mapper.Map<Data.Domain.CustomerPhone>(request.Request);
            await unitOfWork.Repository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CustomerPhoneResponse>(mapped);
            return new ApiResponse<CustomerPhoneResponse>(response);
        }

    }
}
