using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.CustomerPhone.GetAll
{
    public class GetAllCustomerPhoneQuery : IRequest<ApiResponse<List<CustomerPhoneResponse>>>
    {
        public GetAllCustomerPhoneQuery() { }
    }
}
