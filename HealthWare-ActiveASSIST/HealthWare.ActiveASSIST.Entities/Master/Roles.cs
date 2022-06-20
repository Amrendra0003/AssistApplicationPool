using System.Collections.Generic;
using System.Linq;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities.Master
{
    public static class Roles
    {
        public static readonly Role Patient = new Role { Id = 1, RoleName = patient };
        public static readonly Role Advocate = new Role { Id = 2, RoleName = advocate };
        public static readonly Role Admin = new Role { Id = 3, RoleName = admin };

        public static IEnumerable<Role> All()
        {
            yield return Patient;
            yield return Advocate;
            yield return Admin;
        }

        public static Role FindBy(long? id)
        {
            return All().Single(x => x.Id == id);
        }

        private const string patient = "Patient";
        private const string advocate = "Advocate";
        private const string admin = "Admin";
    }
}
