using AutoMapper;
using FluentValidation;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Validation.Customer;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.Command.CustomerPhone.UpdateCustomerPhone
{
    public class UpdateCustomerPhoneCommandHandler : IRequestHandler<UpdateCustomerPhoneCommand, ApiResponse>
    {

        private readonly IUnitOfWork<Para.Data.Domain.CustomerPhone> unitOfWork;
        private readonly IMapper mapper;

        public UpdateCustomerPhoneCommandHandler(IUnitOfWork<Para.Data.Domain.CustomerPhone> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateCustomerPhoneCommand request, CancellationToken cancellationToken)
        {
            CustomerPhoneRequestValidator validator = new CustomerPhoneRequestValidator();
            await validator.ValidateAndThrowAsync(request.Request);

            var mapped = mapper.Map<CustomerPhoneRequest, Data.Domain.CustomerPhone>(request.Request);
            mapped.Id = request.CustomerPhoneId;
            mapped.InsertUser = "system";
            mapped.InsertDate = DateTime.Now;
            unitOfWork.Repository.Update(mapped);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
