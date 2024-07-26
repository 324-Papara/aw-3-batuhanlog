using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.CustomerPhone.GetById
{
    public class GetCustomerPhoneByIdQuery : IRequest<ApiResponse<CustomerPhoneResponse>>
    {
        public long CustomerPhoneId { get; private set; }

        public GetCustomerPhoneByIdQuery(long customerAddressId)
        {
            CustomerPhoneId = customerAddressId;
        }
    }
}
