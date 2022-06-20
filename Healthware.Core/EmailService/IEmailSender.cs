using System.Threading.Tasks;
using MimeKit;

namespace Healthware.Core.EmailService
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Message message, BodyBuilder bodyBuilder);        
    }
}
