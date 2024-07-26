using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.Customer.GetAll
{
    public class GetAllCustomerQuery : IRequest<ApiResponse<List<CustomerResponse>>>
    {
        public GetAllCustomerQuery() { }
    }
}
