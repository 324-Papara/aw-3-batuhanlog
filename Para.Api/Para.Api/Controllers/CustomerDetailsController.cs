using MediatR;
using Microsoft.AspNetCore.Mvc;
using Para.Base.Response;
using Para.Bussiness.Command.CustomerDetail.CreateCustomerDetail;
using Para.Bussiness.Command.CustomerDetail.DeleteCustomerDetail;
using Para.Bussiness.Command.CustomerDetail.UpdateCustomerDetail;
using Para.Bussiness.Query.CustomerDetail.GetAll;
using Para.Bussiness.Query.CustomerDetail.GetById;
using Para.Schema;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerDetailsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<ApiResponse<List<CustomerDetailResponse>>> Get()
        {
            var operation = new GetAllCustomerDetailQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{customerDetailId}")]
        public async Task<ApiResponse<CustomerDetailResponse>> Get([FromRoute] long customerDetailId)
        {
            var operation = new GetCustomerDetailByIdQuery(customerDetailId);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<CustomerDetailResponse>> Post([FromBody] CustomerDetailRequest value)
        {
            CreateCustomerDetailCommand command = new CreateCustomerDetailCommand(value);
            var result = await mediator.Send(command);
            return result;
        }

        [HttpPut("{customerDetailId}")]
        public async Task<ApiResponse> Put(long customerDetailId, [FromBody] CustomerDetailRequest value)
        {
            var operation = new UpdateCustomerDetailCommand(customerDetailId, value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{customerDetailId}")]
        public async Task<ApiResponse> Delete(long customerDetailId)
        {
            var operation = new DeleteCustomerDetailCommand(customerDetailId);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
