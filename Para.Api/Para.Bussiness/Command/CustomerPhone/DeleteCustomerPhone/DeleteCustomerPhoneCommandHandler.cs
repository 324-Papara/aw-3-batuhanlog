using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Command.CustomerPhone.DeleteCustomerPhone;
using Para.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerPhone.DeleteCustomerPhone
{
    public class DeleteCustomerPhoneCommandHandler : IRequestHandler<DeleteCustomerPhoneCommand, ApiResponse>
    {
        private readonly IUnitOfWork<Para.Data.Domain.CustomerPhone> unitOfWork;
        private readonly IMapper mapper;

        public DeleteCustomerPhoneCommandHandler(IMapper mapper, IUnitOfWork<Para.Data.Domain.CustomerPhone> unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(DeleteCustomerPhoneCommand request, CancellationToken cancellationToken)
        {
            if (request.CustomerPhoneId <= 0)
            {
                return new ApiResponse("Invalid CustomerPhone Id");
            }

            var customerPhone = await unitOfWork.Repository.GetById(request.CustomerPhoneId);

            if (customerPhone == null)
            {
                return new ApiResponse("CustomerPhone not found");
            }

            await unitOfWork.Repository.Delete(request.CustomerPhoneId);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
