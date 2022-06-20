using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    public class UserAccount: MainUser
    {
        public Patient? Patient { get; set; }
    }
}
