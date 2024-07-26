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

namespace Para.Bussiness.Query.Customer.GetByParameter
{
    public class GetCustomerByParametersQueryHandler : IRequestHandler<GetCustomerByParametersQuery, ApiResponse<List<CustomerResponse>>>
    {
        private readonly IUnitOfWork<Para.Data.Domain.Customer> unitOfWork;
        private readonly IMapper mapper;

        public GetCustomerByParametersQueryHandler(IUnitOfWork<Para.Data.Domain.Customer> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<CustomerResponse>>> Handle(GetCustomerByParametersQuery request, CancellationToken cancellationToken)
        {
            var customersWithNameReqParameter = await unitOfWork.Repository
                .Where(c => c.FirstName == request.Name);

            var customersWithIdentityNumberReqParameter = await unitOfWork.Repository
                .Where(c => c.IdentityNumber == request.IdentityNumber);

            var customersWithCustomerIdReqParameter = await unitOfWork.Repository
                .Where(c => c.Id == request.CustomerId);

            var customers = customersWithNameReqParameter
                .Union(customersWithIdentityNumberReqParameter)
                .Union(customersWithCustomerIdReqParameter)
                .Distinct()
                .ToList();

            var response = mapper.Map<List<CustomerResponse>>(customers);

            return new ApiResponse<List<CustomerResponse>>(response);
        }
    }
}
