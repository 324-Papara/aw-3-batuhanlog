using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.CustomerAddress.GetById
{
    public class GetCustomerAddressByIdQuery : IRequest<ApiResponse<CustomerAddressResponse>>
    {
        public long CustomerAddressId { get; private set; }

        public GetCustomerAddressByIdQuery(long customerAddressId)
        {
            CustomerAddressId = customerAddressId;
        }
    }
}
