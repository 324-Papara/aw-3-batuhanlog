using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerDetail.CreateCustomerDetail
{
    public class CreateCustomerDetailCommand : IRequest<ApiResponse<CustomerDetailResponse>>
    {
        public CustomerDetailRequest Request { get; private set; }

        public CreateCustomerDetailCommand(CustomerDetailRequest request)
        {
            Request = request;
        }
    }
}
