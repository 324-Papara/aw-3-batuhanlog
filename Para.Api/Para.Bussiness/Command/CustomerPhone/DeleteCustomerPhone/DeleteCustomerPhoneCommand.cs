using MediatR;
using Para.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerPhone.DeleteCustomerPhone
{
    public class DeleteCustomerPhoneCommand : IRequest<ApiResponse>
    {
        public long CustomerPhoneId { get; private set; }

        public DeleteCustomerPhoneCommand(long customerId)
        {
            CustomerPhoneId = customerId;
        }
    }
}
