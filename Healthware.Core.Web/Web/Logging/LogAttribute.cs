using System;
using Healthware.Core.Logging;
using Healthware.Core.Utility;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Healthware.Core.Web.Web.Logging
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class LogAttribute : ActionFilterAttribute
    {
        public LogAttribute()
        {

        }
        public override void OnActionExecuted(ActionExecutedContext actionContext)
        {
            this.Log().Informational(Constants.ActionMethod + actionContext.HttpContext.Request.Method + Constants.Colon +
                                     actionContext.ActionDescriptor.DisplayName + Environment.NewLine + Constants.DateTimeText +
                                     Clock.Now().ToShortDateString() + Environment.NewLine + Constants.RequestUrlText +
                                     actionContext.HttpContext.Request.Path);
        }
        public override void OnActionExecuting(ActionExecutingContext actionExecutedContext)
        {
            this.Log().Informational(Constants.ActionMethod +
                          actionExecutedContext.HttpContext.Request.Method +
                          Constants.Colon + actionExecutedContext.ActionDescriptor.DisplayName +
                          Environment.NewLine + Constants.DateTimeText + Clock.Now().ToShortDateString() +
                          Environment.NewLine + Constants.RequestUrlText + actionExecutedContext.HttpContext.Request.Path);
        }
    }
}