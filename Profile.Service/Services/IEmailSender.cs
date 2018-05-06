using System.Threading.Tasks;

namespace Profile.Service.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
