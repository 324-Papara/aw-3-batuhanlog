using MediatR;
using Para.Base.Response;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.Customer.GetByParameter
{
    public class GetCustomerByParametersQuery : IRequest<ApiResponse<List<CustomerResponse>>>
    {
        public long? CustomerId { get; private set; }
        public string? Name { get; private set; }
        public string? IdentityNumber { get; private set; }


        public GetCustomerByParametersQuery()
        {
            
        }

        public GetCustomerByParametersQuery(long? customerId, string? name, string? identityNumber)
        {
            CustomerId = customerId;
            Name = name;
            IdentityNumber = identityNumber;
        }
    }
}
