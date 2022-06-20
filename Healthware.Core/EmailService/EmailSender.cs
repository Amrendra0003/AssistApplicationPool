using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Healthware.Core.Logging;
using Microsoft.AspNetCore.Http;
using MimeKit;

namespace Healthware.Core.EmailService
{
    public class EmailSender :IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;        
        private readonly IHttpContextAccessor _context;
        public EmailSender(EmailConfiguration emailConfig, IHttpContextAccessor context)
        {
            _emailConfig = emailConfig;            
            _context = context;
        }
        public async Task<bool> SendEmail(Message message, BodyBuilder bodyBuilder)
        {
            var emailMessage = CreateEmailMessage(message, bodyBuilder);
            var result = await Send(emailMessage);
            return result;
        }

        private MimeMessage CreateEmailMessage(Message message, BodyBuilder bodyBuilder)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }
        private async Task<bool> Send(MimeMessage mailMessage)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(_emailConfig.From);
                msg.To.Add(new MailAddress(mailMessage.To.ToString()));
                msg.Subject = mailMessage.Subject;
                msg.IsBodyHtml = true;
                mailMessage.Body.ContentType.CharsetEncoding = null;
                mailMessage.Body.ContentId = null;
                var mailBody = new StringBuilder();
                mailBody = mailBody.Append(mailMessage.Body.ToString());

                string mailContent = mailBody.ToString();
                mailContent = mailContent.Replace("Content-Type: text/html", string.Empty);
                msg.Body = mailContent;
                SmtpClient smtpClient = new SmtpClient(_emailConfig.SmtpServer, Convert.ToInt32(587));
                NetworkCredential credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
                return true;
            }
            catch(Exception ex)
            {
                this.Log().Informational(ex.Message);
                return false;
            }
        }                                       
    }
}
