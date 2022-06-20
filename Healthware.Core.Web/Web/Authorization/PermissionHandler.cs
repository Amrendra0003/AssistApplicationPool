using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Healthware.Core.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Healthware.Core.Web.Web.Authorization
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {

        public PermissionHandler()
        {
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                return Task.CompletedTask;
            }

            var permissionsClaim = context.User.Claims
                .SingleOrDefault(c =>
                    c.Type == Application.PackedPermissionClaimType);
            // If user does not have the scope claim, get out of here
            if (permissionsClaim == null)
                return Task.CompletedTask;

            if (permissionsClaim.Value.ThisPermissionIsAllowed(requirement.PermissionName))
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}