using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Service.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private SmtpClient _client;

        public EmailSender()
        {
            _client = new SmtpClient();
            _client.Port = 587;
            _client.Host = "smtp.gmail.com";
            _client.EnableSsl = true;
            _client.Timeout = 10000;
            _client.DeliveryMethod = SmtpDeliveryMethod.Network;
            _client.UseDefaultCredentials = false;
            _client.Credentials = new System.Net.NetworkCredential("it.academy.test010218@gmail.com", "it'sover9thousand");
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage("it.academy.test010218@gmail.com", email, subject, message);
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            _client.SendAsync(mailMessage, "notification message");

            return Task.CompletedTask;
        }
    }
}
