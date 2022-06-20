using System.Collections.Generic;

namespace Healthware.Core.DTO
{
    public class ResponseDto
    {
        protected ResponseDto()
        {
            Links = new List<Link>();
        }

        public List<Link> Links { get; set; }

        public ResponseDto AddLink(Link link)
        {
            Links.Add(link);
            return this;
        }
    }
}