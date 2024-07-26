using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.Query.CustomerAddress.GetAll
{
    public class GetAllCustomerAddressQueryHandler : IRequestHandler<GetAllCustomerAddressQuery, ApiResponse<List<CustomerAddressResponse>>>
    {
        private readonly IUnitOfWork<Para.Data.Domain.CustomerAddress> unitOfWork;
        private readonly IMapper mapper;

        public GetAllCustomerAddressQueryHandler(IUnitOfWork<Para.Data.Domain.CustomerAddress> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<CustomerAddressResponse>>> Handle(GetAllCustomerAddressQuery request, CancellationToken cancellationToken)
        {
            List<Para.Data.Domain.CustomerAddress> entityList = await unitOfWork.Repository.GetAll();
            var mappedList = mapper.Map<List<CustomerAddressResponse>>(entityList);
            return new ApiResponse<List<CustomerAddressResponse>>(mappedList);
        }
    }
}
