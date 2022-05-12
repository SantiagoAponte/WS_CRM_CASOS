
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface MailService
    {
         Task<userManagerResponse> SendEmailAsync(string email, string caso);
    }
     public class SendGridMailService : MailService
    {
        private IConfiguration _configuration;
        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public async Task<userManagerResponse> SendEmailAsync(string email, string caso)
        {
            
//  var apiKey = "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";
//             var client = new SendGridClient(apiKey);
//             var from = new EmailAddress("Noresponder@lavital.co", "Example User");
//             var subject = "Tienes un nuevo registro de caso en servital";
//             var to = new EmailAddress(email, "Example User");
//             var plainTextContent = "";
//             var htmlContent = "Numero de caso registrado: "+ $"{caso}"; 
//             var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
//             var response = await client.SendEmailAsync(msg);
//     Console.WriteLine(response.IsSuccessStatusCode);
var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("ontosoft5@gmail.com", "La Vital"));
            msg.AddTo(new EmailAddress(email,"Activación OntoSoft"));
            msg.SetTemplateId("d-577d5cdaf6cb452cbf687ecbcebe2c8d");
            msg.SetTemplateData(new{
                    caso = $"{caso}"
                    });
            var response = await client.SendEmailAsync(msg);
       if(response.IsSuccessStatusCode) {
            return new userManagerResponse
            {
                IsSuccess = true,
                Message = "Se envio el correo del numero de caso al usuario."
            };

       }
       return new userManagerResponse
            {
                IsSuccess = false,
                Message = "Hubo un error al enviar el correo."
            };
            
        }
    }
}