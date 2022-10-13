using CustomerWithCqrs.Domain.Commands.Requests;
using CustomerWithCqrs.Domain.Commands.Responses;

namespace CustomerWithCqrs.Domain.Commands.Handlers
{
    public class CreateCustomerHandler : ICreateCustomerHandler
    {
        List<CreateCustomerRequest> customers = new List<CreateCustomerRequest>();
        public CreateCustomerResponse Handle (CreateCustomerRequest request)
        {
            bool exists = customers.Exists(c => c.Email == request.Email);

            if (exists == false)
            {
                CreateCustomerResponse addCustomer = new CreateCustomerResponse{
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Email = request.Email,
                    InsertDate = DateTime.Now
                };

                customers.Add(request);

                return addCustomer;
            }
            else 
            {
                return null;
            }
        }
    }
}