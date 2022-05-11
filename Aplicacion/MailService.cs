
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
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
            //  var user = await _userManger.FindByEmailAsync(email);
            // if (user == null){
            //      throw new ManagerError(HttpStatusCode.NotAcceptable, new {mensaje ="No existe ningun usuario con este Email"});
            // }
                // return new UserManagerResponse
                // {
                //     IsSuccess = false,
                //     Message = "No existe ningun usuario con este Email",
                // };
                //  user.Email = email;
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from_email = new EmailAddress("Noresponder@servital.co", "SerVital");
       var subject = "Tienes un nuevo Caso Creado en SerVital";
       var to_email = new EmailAddress(email, "Querido Usuario");
       var plainTextContent = "Este es tu numero de caso creado:" + caso;
       var htmlContent = "Numero de caso registrado: "+ $"{caso}";
       var msg = MailHelper.CreateSingleEmail(from_email, to_email, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return new userManagerResponse
            {
                IsSuccess = true,
                Message = "Se envio el correo de activación al usuario."
            };

            // var apiKey = "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";
            // var client = new SendGridClient(apiKey);
            // var from = new EmailAddress("ontosoft5@gmail.com", "OntoSoft Recupera tu contraseña!");
            // var to = new EmailAddress(toEmail);
            // var msg = MailHelper.CreateSingleTemplateEmail(from, to,"d-17616c7169ba421f966e318f4e620111", dynamicTemplateData);
            // var response = await client.SendEmailAsync(msg);
            
        }
    }
}