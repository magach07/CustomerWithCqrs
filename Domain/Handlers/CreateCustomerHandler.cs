using System.Net;
using System.Net.Mail;
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

                MailMessage email = new MailMessage();
                email.From = new MailAddress("jonathanmagacho@gmail.com");
                email.To.Add(request.Email);
                email.Subject = "Customer C#";
                email.IsBodyHtml = true;
                email.Body = "<p>Olá " + request.Name + ", você foi adicionado a lista de Clientes da aplicação C# desenvolvida por Jonathan Magacho. <p>";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;

                //A senha é gerada unicamente para o processo dentro das configurações da conta google
                smtp.Credentials = new NetworkCredential("jonathanmagacho@gmail.com", "bbczgipyemwjecuk");
                smtp.EnableSsl = true;

                smtp.Send(email);

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