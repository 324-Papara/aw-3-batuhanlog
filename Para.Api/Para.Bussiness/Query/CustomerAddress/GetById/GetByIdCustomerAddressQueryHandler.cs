using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.Query.CustomerAddress.GetById
{
    public class GetCustomerAddressByIdQueryHandler : IRequestHandler<GetCustomerAddressByIdQuery, ApiResponse<CustomerAddressResponse>>
    {

        private readonly IUnitOfWork<Para.Data.Domain.CustomerAddress> unitOfWork;
        private readonly IMapper mapper;

        public GetCustomerAddressByIdQueryHandler(IUnitOfWork<Para.Data.Domain.CustomerAddress> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CustomerAddressResponse>> Handle(GetCustomerAddressByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.CustomerAddressId <= 0)
            {
                return new ApiResponse<CustomerAddressResponse>()
                {
                    IsSuccess = false,
                    Message = "Invalid CustomerAddress Id"
                };
            }
            var entity = await unitOfWork.Repository.GetById(request.CustomerAddressId);
            if (entity == null)
            {
                return new ApiResponse<CustomerAddressResponse>()
                {
                    IsSuccess = false,
                    Message = "CustomerAddress not found"
                };
            }
            var mapped = mapper.Map<CustomerAddressResponse>(entity);
            return new ApiResponse<CustomerAddressResponse>(mapped);
        }
    }
}
