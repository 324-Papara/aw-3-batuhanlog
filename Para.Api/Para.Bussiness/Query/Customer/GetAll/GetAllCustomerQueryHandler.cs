using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using Para.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.Customer.GetAll
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, ApiResponse<List<CustomerResponse>>>
    {
        private readonly IUnitOfWork<Para.Data.Domain.Customer> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(IUnitOfWork<Para.Data.Domain.Customer> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<CustomerResponse>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            List<Para.Data.Domain.Customer> entityList = await _unitOfWork.Repository.GetAll();
            var mappedList = _mapper.Map<List<CustomerResponse>>(entityList);
            return new ApiResponse<List<CustomerResponse>>(mappedList);
        }
    }
}
