using MediatR;
using Para.Base.Response;
using Para.Schema;

namespace Para.Bussiness.Command.CustomerPhone.UpdateCustomerPhone
{
    public class UpdateCustomerPhoneCommand : IRequest<ApiResponse>
    {
        public long CustomerPhoneId { get; private set; }
        public CustomerPhoneRequest Request { get; private set; }

        public UpdateCustomerPhoneCommand(long customerId, CustomerPhoneRequest request)
        {
            CustomerPhoneId = customerId;
            Request = request;
        }
    }
}
