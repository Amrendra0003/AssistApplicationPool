using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace Healthware.Core.EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public Message(IEnumerable<string> to, string subject)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
        }
    }
}
