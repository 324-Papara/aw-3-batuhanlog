using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerAddress.CreateCustomerAddress
{
    public class CreateCustomerAddressCommand : IRequest<ApiResponse<CustomerAddressResponse>>
    {
        public CustomerAddressRequest Request { get; private set; }

        public CreateCustomerAddressCommand(CustomerAddressRequest request)
        {
            Request = request;
        }
    }
}
