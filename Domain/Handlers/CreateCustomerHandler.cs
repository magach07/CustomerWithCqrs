using CustomerWithCqrs.Domain.Commands.Requests;
using CustomerWithCqrs.Domain.Commands.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWithCqrs.Domain.Commands.Handlers
{
    public class CreateCustomerHandler : ICreateCustomerHandler
    {
        // List<CreateCustomerRequest> customers = new List<CreateCustomerRequest>();
        List<CreateCustomerResponse> responseCustomer = new List<CreateCustomerResponse>();
        public CreateCustomerResponse Handle (CreateCustomerRequest request)
        {
            bool exists = responseCustomer.Exists(c => c.Email == request.Email);

            if (exists == false)
            {
                CreateCustomerResponse addCustomer = new CreateCustomerResponse{
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Email = request.Email,
                    InsertDate = DateTime.Now
                };

                responseCustomer.Add(addCustomer);

                return addCustomer;
            }
            else 
            {
                return null;
            }
        }

        public List<CreateCustomerResponse> GetAllCustomers ()
        {
            var result = responseCustomer.ToList();

            return result;
        }
    }
}