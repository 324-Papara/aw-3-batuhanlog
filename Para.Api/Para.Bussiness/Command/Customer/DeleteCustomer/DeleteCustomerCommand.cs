using MediatR;
using Para.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.Customer.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<ApiResponse>
    {
        public long CustomerId { get; private set; }

        public DeleteCustomerCommand(long customerId)
        {
            CustomerId = customerId;
        }
    }
}
