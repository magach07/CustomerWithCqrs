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
        private readonly ICreateCustomerHandler _ICreateCustomerHandler;

        public CustomerController (ICreateCustomerHandler ICreateCustomerHandler)
        {
            _ICreateCustomerHandler = ICreateCustomerHandler;
        }

        [HttpPost]
        [Route("create")]
        public CreateCustomerResponse CreateCustomer ([FromBody] CreateCustomerRequest customer)
        {
            var result =  _ICreateCustomerHandler.Handle(customer);

            return result;
        }
        [HttpPost]
        [Route("GetAll")]
        public List<CreateCustomerResponse> GetAllCustomers ()
        {
            var result = _ICreateCustomerHandler.GetAllCustomers();

            return result;
        }
    }
}