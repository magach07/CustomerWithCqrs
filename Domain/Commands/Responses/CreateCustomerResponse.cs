namespace CustomerWithCqrs.Domain.Commands.Responses
{
    public class CreateCustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
    }
}