using CustomerWithCqrs.Domain.Commands.Handlers;
using CustomerWithCqrs.Domain.Commands.Requests;
using CustomerWithCqrs.Domain.Commands.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWithCqrs.Controllers
{
    [ApiController]
    [Route("v1/customer")]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public CreateCustomerResponse CreateCustomer ([FromServices] ICreateCustomerHandler handler, [FromBody] CreateCustomerRequest customer)
        {
            return handler.Handle(customer);
        }
    }
}