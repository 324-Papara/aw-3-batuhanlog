using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.Customer.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<ApiResponse<CustomerResponse>>
    {
        public CustomerRequest Request { get; private set; }

        public CreateCustomerCommand(CustomerRequest request)
        {
            Request = request;
        }
    }
}
