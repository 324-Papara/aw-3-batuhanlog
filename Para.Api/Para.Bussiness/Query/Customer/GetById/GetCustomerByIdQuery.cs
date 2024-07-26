using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.Customer.GetById
{
    public class GetCustomerByIdQuery : IRequest<ApiResponse<CustomerResponse>>
    {
        public long CustomerId { get; private set; }

        public GetCustomerByIdQuery(long customerId)
        {
            CustomerId = customerId;
        }
    }
}
