using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerAddress.UpdateCustomerAddress
{
    public class UpdateCustomerAddressCommand : IRequest<ApiResponse>
    {
        public long CustomerAddressId { get; private set; }
        public CustomerAddressRequest Request { get; private set; }

        public UpdateCustomerAddressCommand(long customerId, CustomerAddressRequest request)
        {
            CustomerAddressId = customerId;
            Request = request;
        }
    }
}
