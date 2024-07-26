using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Data.UnitOfWork;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.Customer.GetById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ApiResponse<CustomerResponse>>
    {

        private readonly IUnitOfWork<Para.Data.Domain.Customer> unitOfWork;
        private readonly IMapper mapper;

        public GetCustomerByIdQueryHandler(IUnitOfWork<Para.Data.Domain.Customer> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CustomerResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.CustomerId <= 0)
            {
                return new ApiResponse<CustomerResponse>()
                {
                    IsSuccess = false,
                    Message = "Invalid Customer Id"
                };
            }
            var entity = await unitOfWork.Repository.GetById(request.CustomerId);
            if (entity == null)
            {
                return new ApiResponse<CustomerResponse>()
                {
                    IsSuccess = false,
                    Message = "Customer not found"
                };
            }
            var mapped = mapper.Map<CustomerResponse>(entity);
            return new ApiResponse<CustomerResponse>(mapped);
        }
    }
}
