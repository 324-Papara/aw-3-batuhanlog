using AutoMapper;
using FluentValidation;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Validation.Customer;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.Command.CustomerAddress.UpdateCustomerAddress
{
    public class UpdateCustomerAddressCommandHandler : IRequestHandler<UpdateCustomerAddressCommand, ApiResponse>
    {

        private readonly IUnitOfWork<Para.Data.Domain.CustomerAddress> unitOfWork;
        private readonly IMapper mapper;

        public UpdateCustomerAddressCommandHandler(IUnitOfWork<Para.Data.Domain.CustomerAddress> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            CustomerAddressRequestValidator validator = new CustomerAddressRequestValidator();
            await validator.ValidateAndThrowAsync(request.Request);

            var mapped = mapper.Map<CustomerAddressRequest, Data.Domain.CustomerAddress>(request.Request);
            mapped.Id = request.CustomerAddressId;
            mapped.InsertUser = "system";
            mapped.InsertDate = DateTime.Now;
            unitOfWork.Repository.Update(mapped);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
