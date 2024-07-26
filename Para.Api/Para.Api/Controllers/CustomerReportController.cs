using MediatR;
using Microsoft.AspNetCore.Mvc;
using Para.Base.Response;
using Para.Data.DapperRepository;



namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;

        public ReportController(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            _customerReadOnlyRepository = customerReadOnlyRepository;
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetCustomerReport()
        {
            var customers = await _customerReadOnlyRepository.GetCustomersWithDetails();
            return Ok(customers);
        }
    }
}