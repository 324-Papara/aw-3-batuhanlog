using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Command.CustomerAddressAddress.CustomerAddress;
using Para.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerAddress.DeleteCustomerAddress
{
    public class DeleteCustomerAddressCommandHandler : IRequestHandler<DeleteCustomerAddressCommand, ApiResponse>
    {
        private readonly IUnitOfWork<Para.Data.Domain.CustomerAddress> unitOfWork;
        private readonly IMapper mapper;

        public DeleteCustomerAddressCommandHandler(IMapper mapper, IUnitOfWork<Para.Data.Domain.CustomerAddress> unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            if (request.CustomerAddressId <= 0)
            {
                return new ApiResponse("Invalid CustomerAddress Id");
            }

            var customerAddress = await unitOfWork.Repository.GetById(request.CustomerAddressId);

            if (customerAddress == null)
            {
                return new ApiResponse("CustomerAddress not found");
            }

            await unitOfWork.Repository.Delete(request.CustomerAddressId);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
