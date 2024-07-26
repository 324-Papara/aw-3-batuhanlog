using AutoMapper;
using FluentValidation;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Validation.Customer;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.Command.CustomerDetail.CreateCustomerDetail
{
    public class CreateCustomerDetailCommandHandler : IRequestHandler<CreateCustomerDetailCommand, ApiResponse<CustomerDetailResponse>>
    {
        private readonly IUnitOfWork<Para.Data.Domain.CustomerDetail> unitOfWork;
        private readonly IMapper mapper;

        public CreateCustomerDetailCommandHandler(IUnitOfWork<Para.Data.Domain.CustomerDetail> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CustomerDetailResponse>> Handle(CreateCustomerDetailCommand request, CancellationToken cancellationToken)
        {
            CustomerDetailRequestValidator validator = new CustomerDetailRequestValidator();
            await validator.ValidateAndThrowAsync(request.Request);

            var mapped = mapper.Map<Data.Domain.CustomerDetail>(request.Request);
            await unitOfWork.Repository.Insert(mapped);
            await unitOfWork.Complete();

            var response = mapper.Map<CustomerDetailResponse>(mapped);
            return new ApiResponse<CustomerDetailResponse>(response);
        }

    }
}
