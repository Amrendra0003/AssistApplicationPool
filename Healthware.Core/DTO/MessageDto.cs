using System.Collections.Generic;

namespace Healthware.Core.DTO
{
    public class MessageDto :ResponseDto
    {
        public MessageDto()
        {
            Message = new List<string>();
        }
        public List<string> Message { get; set; }
        public MessageDto AddMessage(string message)
        {
            Message.Add(message);
            return this;
        }
    }
}
