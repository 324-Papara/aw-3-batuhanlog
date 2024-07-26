using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerPhone.CreateCustomerPhone
{
    public class CreateCustomerPhoneCommand : IRequest<ApiResponse<CustomerPhoneResponse>>
    {
        public CustomerPhoneRequest Request { get; private set; }

        public CreateCustomerPhoneCommand(CustomerPhoneRequest request)
        {
            Request = request;
        }
    }
}
