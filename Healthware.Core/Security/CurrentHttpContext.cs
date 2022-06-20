using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Healthware.Core.Security
{
    public interface ICurrentHttpContext
    {
        ClaimsPrincipal GetCurrentUser();
        string GetCurrentUserRole();
    }
    public class CurrentHttpContext: ICurrentHttpContext
    {
        private readonly IHttpContextAccessor _iHttpContextAccessor;
        public CurrentHttpContext(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }

        public ClaimsPrincipal GetCurrentUser()
        {
            return _iHttpContextAccessor.HttpContext?.User;
        }

        public string GetCurrentUserRole()
        {
            var user = _iHttpContextAccessor.HttpContext?.User;
            return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        }
    }
}
