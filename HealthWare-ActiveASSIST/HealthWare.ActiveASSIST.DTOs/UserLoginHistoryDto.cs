using Healthware.Core.MultiTenancy.Entities;
using System;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class UserLoginHistoryDto
    {
        public int NoOfAttempts { get; set; }
        public DateTime ExpireTime { get; set; }
        public User User { get; set; }
    }
}
