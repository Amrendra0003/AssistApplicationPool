using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Healthware.Core.Entities;
using Healthware.Core.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Healthware.Core.Web.Web.Authorization
{
    public class CoreUserClaimsPrincipalFactory<TUser, TRole> : UserClaimsPrincipalFactory<TUser, TRole>
        where TUser : MainUser
        where TRole : Role, new()
    {
        public CoreUserClaimsPrincipalFactory(UserManager<TUser> user, RoleManager<TRole> role,
            IOptions<IdentityOptions> optionsAccessor)
            : base((UserManager<TUser>)user, (RoleManager<TRole>)role, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(TUser user)
        {
            ClaimsPrincipal async = await base.CreateAsync(user);
            async.Identities.First<ClaimsIdentity>().AddClaim(new Claim(UserClaimTypes.UserName, user.EmailAddress.ToString()));
            return async;
        }
    }
}
