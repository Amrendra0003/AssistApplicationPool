using System;
using Healthware.Core.Entities;

namespace Healthware.Core.Common.Session.Mapper
{
    public interface ISessionMapper
    {
        SessionActivity MapFrom(MainUser user);
    }
    public class SessionMapper : ISessionMapper
    {
        public SessionActivity MapFrom(MainUser user)
        {
            var sessionActivity = new SessionActivity()
            {

                User = new MainUser() { Id = user.Id },
                SessionStartDateTime = DateTime.UtcNow,
                LastLoggedInDateTime = DateTime.UtcNow,
                Active = true,
                CreatedDate = DateTime.UtcNow
            };
            return sessionActivity;
        }
    }
}
