using MediatR;
using Para.Base.Response;

namespace Para.Bussiness.Command.CustomerDetail.DeleteCustomerDetail
{
    public class DeleteCustomerDetailCommand : IRequest<ApiResponse>
    {
        public long CustomerDetailId { get; private set; }

        public DeleteCustomerDetailCommand(long customerId)
        {
            CustomerDetailId = customerId;
        }
    }
}
