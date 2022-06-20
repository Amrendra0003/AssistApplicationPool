using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using Healthware.Core.Common.Session;
using Healthware.Core.Constants;
using Healthware.Core.Containers;
using Healthware.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HealthWare.ActiveASSIST.Web.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class HandleAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public HandleAuthorizeAttribute()
        {

        }
        public async System.Threading.Tasks.Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return;
            }

            var sessionService = Resolve.AnImplementationOf<ISessionService<PatientDbContext>>();
            var qsAuthToken = context.HttpContext.Request.Headers["token"].FirstOrDefault();
            var decryptedToken = SimpleStringCipher.Instance.Decrypt(qsAuthToken, Application.DefaultPassPhrase);
            var handler = new JwtSecurityTokenHandler();
            var tokenValues = handler.ReadToken(decryptedToken) as JwtSecurityToken;
            var sessionId = tokenValues.Claims.First(claim => claim.Type == Application.SessionId).Value;
            var isSessionActive = await sessionService.IsSessionActiveBySessionId(Convert.ToInt64(sessionId));

            if (!isSessionActive.WasSuccessful)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}