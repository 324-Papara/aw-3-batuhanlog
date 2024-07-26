using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.Customer.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<ApiResponse>
    {
        public long CustomerId { get; private set; }
        public CustomerRequest Request { get; private set; }

        public UpdateCustomerCommand(long customerId, CustomerRequest request)
        {
            CustomerId = customerId;
            Request = request;
        }
    }
}
