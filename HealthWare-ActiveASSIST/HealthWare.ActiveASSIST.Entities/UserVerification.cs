using Healthware.Core.Entities;
using Healthware.Core.MultiTenancy.Entities;
using System;

namespace HealthWare.ActiveASSIST.Entities
{
    public class UserVerification : BaseEntity
    {
        public string Token { get; set; }
        public DateTime TokenCreationTime { get; set; }
        public DateTime TokenExpirationTime { get; set; }
        public int NoOfClicks { get; set; }
        public User User { get; set; }
    }
}
