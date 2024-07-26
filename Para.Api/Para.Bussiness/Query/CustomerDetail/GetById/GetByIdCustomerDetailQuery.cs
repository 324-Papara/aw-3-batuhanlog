using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.CustomerDetail.GetById
{
    public class GetCustomerDetailByIdQuery : IRequest<ApiResponse<CustomerDetailResponse>>
    {
        public long CustomerDetailId { get; private set; }

        public GetCustomerDetailByIdQuery(long customerAddressId)
        {
            CustomerDetailId = customerAddressId;
        }
    }
}
