using MediatR;
using Microsoft.AspNetCore.Mvc;
using Para.Base.Response;
using Para.Bussiness.Command.CustomerAddress.CreateCustomerAddress;
using Para.Bussiness.Command.CustomerAddress.UpdateCustomerAddress;
using Para.Bussiness.Command.CustomerAddressAddress.CustomerAddress;
using Para.Bussiness.Query.CustomerAddress.GetAll;
using Para.Bussiness.Query.CustomerAddress.GetById;
using Para.Schema;
using System.Collections.Generic;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddresssController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerAddresssController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<ApiResponse<List<CustomerAddressResponse>>> Get()
        {
            var operation = new GetAllCustomerAddressQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{customerAddressId}")]
        public async Task<ApiResponse<CustomerAddressResponse>> Get([FromRoute] long customerAddressId)
        {
            var operation = new GetCustomerAddressByIdQuery(customerAddressId);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<CustomerAddressResponse>> Post([FromBody] CustomerAddressRequest value)
        {
            CreateCustomerAddressCommand command = new CreateCustomerAddressCommand(value);
            var result = await mediator.Send(command);
            return result;
        }

        [HttpPut("{customerAddressId}")]
        public async Task<ApiResponse> Put(long customerAddressId, [FromBody] CustomerAddressRequest value)
        {
            var operation = new UpdateCustomerAddressCommand(customerAddressId, value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{customerAddressId}")]
        public async Task<ApiResponse> Delete(long customerAddressId)
        {
            var operation = new DeleteCustomerAddressCommand(customerAddressId);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}
