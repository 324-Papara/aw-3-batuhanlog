using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Data.UnitOfWork;

namespace Para.Bussiness.Command.Customer.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ApiResponse>
    {
        private readonly IUnitOfWork<Para.Data.Domain.Customer> unitOfWork;
        private readonly IMapper mapper;

        public DeleteCustomerCommandHandler(IMapper mapper, IUnitOfWork<Para.Data.Domain.Customer> unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request.CustomerId <= 0)
            {
                return new ApiResponse("Invalid Customer Id");
            }

            var repo = unitOfWork.Repository;

            var customer = await repo.GetById(request.CustomerId);

            if (customer == null)
            {
                return new ApiResponse("Customer not found");
            }

            await repo.Delete(request.CustomerId);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
