using MediatR;
using Para.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerAddressAddress.CustomerAddress
{
    public class DeleteCustomerAddressCommand : IRequest<ApiResponse>
    {
        public long CustomerAddressId { get; private set; }

        public DeleteCustomerAddressCommand(long customerId)
        {
            CustomerAddressId = customerId;
        }
    }
}
