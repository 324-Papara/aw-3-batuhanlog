using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Query.Customer.GetAll;
using Para.Bussiness.Query.CustomerPhone.GetAll;
using Para.Data.UnitOfWork;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.CustomerPhone.GetAll
{
    public class GetAllCustomerPhoneQueryHandler : IRequestHandler<GetAllCustomerPhoneQuery, ApiResponse<List<CustomerPhoneResponse>>>
    {
        private readonly IUnitOfWork<Para.Data.Domain.CustomerPhone> unitOfWork;
        private readonly IMapper mapper;

        public GetAllCustomerPhoneQueryHandler(IUnitOfWork<Para.Data.Domain.CustomerPhone> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<CustomerPhoneResponse>>> Handle(GetAllCustomerPhoneQuery request, CancellationToken cancellationToken)
        {
            List<Para.Data.Domain.CustomerPhone> entityList = await unitOfWork.Repository.GetAll();
            var mappedList = mapper.Map<List<CustomerPhoneResponse>>(entityList);
            return new ApiResponse<List<CustomerPhoneResponse>>(mappedList);
        }
    }
}
