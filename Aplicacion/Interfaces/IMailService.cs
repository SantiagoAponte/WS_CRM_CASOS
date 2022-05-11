using System.Threading.Tasks;
using Aplicacion;


namespace Aplication.Interfaces
{
     public interface IMailService
    {
     Task<userManagerResponse> SendEmailAppoinmentAsync(string email);
    }
}