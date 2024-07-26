using AutoMapper;
using FluentValidation;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Validation.Customer;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.Command.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ApiResponse<CustomerResponse>>
    {
        private readonly IUnitOfWork<Para.Data.Domain.Customer> unitOfWork;
        private readonly IMapper mapper;

        public CreateCustomerCommandHandler(IUnitOfWork<Para.Data.Domain.Customer> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            CustomerRequestValidator validator = new CustomerRequestValidator();
            await validator.ValidateAndThrowAsync(request.Request);

            var mapped = mapper.Map<CustomerRequest, Data.Domain.Customer>(request.Request);
            mapped.CustomerNumber = new Random().Next(1000000, 9999999);
            await unitOfWork.Repository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CustomerResponse>(mapped);
            return new ApiResponse<CustomerResponse>(response);
        }
    }
}
