using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Data.UnitOfWork;

namespace Para.Bussiness.Command.CustomerDetail.DeleteCustomerDetail
{
    public class DeleteCustomerDetailCommandHandler : IRequestHandler<DeleteCustomerDetailCommand, ApiResponse>
    {
        private readonly IUnitOfWork<Para.Data.Domain.CustomerDetail> unitOfWork;
        private readonly IMapper mapper;

        public DeleteCustomerDetailCommandHandler(IMapper mapper, IUnitOfWork<Para.Data.Domain.CustomerDetail> unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(DeleteCustomerDetailCommand request, CancellationToken cancellationToken)
        {
            if (request.CustomerDetailId <= 0)
            {
                return new ApiResponse("Invalid CustomerDetail Id");
            }

            var customerDetail = await unitOfWork.Repository.GetById(request.CustomerDetailId);

            if (customerDetail == null)
            {
                return new ApiResponse("CustomerDetail not found");
            }


            await unitOfWork.Repository.Delete(request.CustomerDetailId);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
