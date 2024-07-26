using MediatR;
using Para.Base.Response;

namespace Para.Bussiness.Query.Customer.GetById
{
    public class GetCustomerByIdWithDetailsQuery : IRequest<ApiResponse<Para.Data.Domain.Customer>>
    {
        public long CustomerId { get; private set; }

        public GetCustomerByIdWithDetailsQuery(long customerId)
        {
            CustomerId = customerId;
        }
    }
}
