using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Query.CustomerDetail.GetById;
using Para.Data.UnitOfWork;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.CustomerDetail.GetById
{
    public class GetCustomerDetailByIdQueryHandler : IRequestHandler<GetCustomerDetailByIdQuery, ApiResponse<CustomerDetailResponse>>
    {

        private readonly IUnitOfWork<Para.Data.Domain.CustomerDetail> unitOfWork;
        private readonly IMapper mapper;

        public GetCustomerDetailByIdQueryHandler(IUnitOfWork<Para.Data.Domain.CustomerDetail> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CustomerDetailResponse>> Handle(GetCustomerDetailByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.CustomerDetailId <= 0)
            {
                return new ApiResponse<CustomerDetailResponse>()
                {
                    IsSuccess = false,
                    Message = "Invalid CustomerDetail Id"
                };
            }
            var entity = await unitOfWork.Repository.GetById(request.CustomerDetailId);
            if (entity == null)
            {
                return new ApiResponse<CustomerDetailResponse>()
                {
                    IsSuccess = false,
                    Message = "CustomerDetail not found"
                };
            }
            var mapped = mapper.Map<CustomerDetailResponse>(entity);
            return new ApiResponse<CustomerDetailResponse>(mapped);
        }
    }
}
