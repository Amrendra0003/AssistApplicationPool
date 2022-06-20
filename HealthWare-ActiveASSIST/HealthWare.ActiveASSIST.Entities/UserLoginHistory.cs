using Healthware.Core.Entities;
using Healthware.Core.MultiTenancy.Entities;
using System;

namespace HealthWare.ActiveASSIST.Entities
{
    public class UserLoginHistory : BaseEntity
    {
        public int NoOfAttempts { get; set; }
        public DateTime ExpireTime { get; set; }
        public User User { get; set; }
    }
}
