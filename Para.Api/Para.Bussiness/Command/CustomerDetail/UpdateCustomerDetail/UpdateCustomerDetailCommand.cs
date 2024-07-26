using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerDetail.UpdateCustomerDetail
{
    public class UpdateCustomerDetailCommand : IRequest<ApiResponse>
    {
        public long CustomerDetailId { get; private set; }
        public CustomerDetailRequest Request { get; private set; }

        public UpdateCustomerDetailCommand(long customerId, CustomerDetailRequest request)
        {
            CustomerDetailId = customerId;
            Request = request;
        }
    }
}
