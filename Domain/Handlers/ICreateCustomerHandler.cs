using CustomerWithCqrs.Domain.Commands.Requests;
using CustomerWithCqrs.Domain.Commands.Responses;

namespace CustomerWithCqrs.Domain.Commands.Handlers
{
    public interface ICreateCustomerHandler
    {
        public CreateCustomerResponse Handle (CreateCustomerRequest request);
    }
}