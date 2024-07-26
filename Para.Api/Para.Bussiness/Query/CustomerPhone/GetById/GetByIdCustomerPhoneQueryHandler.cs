using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.Query.CustomerPhone.GetById
{
    public class GetCustomerPhoneByIdQueryHandler : IRequestHandler<GetCustomerPhoneByIdQuery, ApiResponse<CustomerPhoneResponse>>
    {

        private readonly IUnitOfWork<Para.Data.Domain.CustomerPhone> unitOfWork;
        private readonly IMapper mapper;

        public GetCustomerPhoneByIdQueryHandler(IUnitOfWork<Para.Data.Domain.CustomerPhone> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CustomerPhoneResponse>> Handle(GetCustomerPhoneByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.CustomerPhoneId <= 0)
            {
                return new ApiResponse<CustomerPhoneResponse>()
                {
                    IsSuccess = false,
                    Message = "Invalid CustomerPhone Id"
                };
            }
            var entity = await unitOfWork.Repository.GetById(request.CustomerPhoneId);
            if (entity == null)
            {
                return new ApiResponse<CustomerPhoneResponse>()
                {
                    IsSuccess = false,
                    Message = "CustomerPhone not found"
                };
            }
            var mapped = mapper.Map<CustomerPhoneResponse>(entity);
            return new ApiResponse<CustomerPhoneResponse>(mapped);
        }
    }
}
