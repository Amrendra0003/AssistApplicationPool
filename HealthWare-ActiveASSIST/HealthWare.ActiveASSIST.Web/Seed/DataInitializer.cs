using Healthware.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace HealthWare.ActiveASSIST.Web.Seed
{
    public static class DataInitializer
    {
        public static void SeedData(RoleManager<Role> roleManager)
        {
            SeedRoles(roleManager);
        }


        public static void SeedRoles(RoleManager<Role> roleManager)
        {

            CreateRole(roleManager, Entities.Master.Roles.Patient.RoleName);
            CreateRole(roleManager, Entities.Master.Roles.Advocate.RoleName);

            static void CreateRole(RoleManager<Role> roleManager, string roleName)
            {
                if (roleManager.RoleExistsAsync
                    (roleName).GetAwaiter().GetResult()) return;
                var role = new Role()
                {
                    RoleName = roleName
                };
                _ = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
