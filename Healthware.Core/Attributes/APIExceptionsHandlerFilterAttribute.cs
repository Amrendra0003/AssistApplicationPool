using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Healthware.Core.EmailService;
using Healthware.Core.Exceptions;
using Healthware.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Healthware.Core.Attributes
{
    public class ApiExceptionsHandlerFilterAttribute : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception ?? new Exception(Constants.Error.UnexpectedExceptionDetails);
            var exceptionResponse = PrepareFriendlyExceptionResponse(exception, context);

            this.Log().Error(context.Exception);

	        context.Result = exceptionResponse;
	        
	        base.OnException(context);
        }

	    private JsonResult PrepareFriendlyExceptionResponse(Exception exception, ExceptionContext context)
	    {
            ApiError apiError = null;

            switch (exception)
            {
                case ApiException _:
                    {
                        // handle explicit 'known' API errors
                        var ex = context.Exception as ApiException;
                        context.Exception = null;
                        if (ex != null)
                        {
                            apiError = new ApiError(ex.Message)
                            {
                                Errors = ex.Errors
                            };

                            context.HttpContext.Response.StatusCode = ex.StatusCode;
                            this.Log().Error(ex, ex.GetBaseException().Message);
                        }

                        break;
                    }
                case UnauthorizedAccessException _:
                    apiError = new ApiError(Constants.Error.UnauthorizedMessage);
                    context.HttpContext.Response.StatusCode = 401;

                    this.Log().Error(context.Exception, context.Exception.GetBaseException().Message);
                    break;
                case TimeoutException _:
                    apiError = new ApiError(Constants.Error.HealthWareServiceCallTimeoutMessage);
                    context.HttpContext.Response.StatusCode = 504;

                    this.Log().Error(context.Exception, context.Exception.GetBaseException().Message);
                    break;
                default:
                    {
                        if (exception is BadRequestObjectResult)
                        {
                            context.HttpContext.Response.StatusCode = 400;
                            apiError = new ApiError(exception.Message)
                            {
                                Detail = Constants.Error.ExceptionDetails
                            };
                            this.Log().Error(context.Exception, context.Exception.GetBaseException().Message);
                        }
                        else
                        {
                            // Unhandled errors
#if !DEBUG
                var msg = "An unexpected server error has occurred.";                
                string stack = null;
            #else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
            #endif
	            apiError = new ApiError(msg)
                {
                    Detail = stack
                };

                context.HttpContext.Response.StatusCode = 500;
	            this.Log().Error(context.Exception,context.Exception.GetBaseException().Message);
                var adminNotification = new AdminNotification(context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value, context.HttpContext.Request.Path.Value.ToString(),
                                context.Exception.GetBaseException().Message, context.Exception.StackTrace);
                        }

                        break;
                    }
            }

	        return new JsonResult(apiError);
	    }

	    private string GetExceptionDetails(Exception exception)
	    {
			//In release mode, we don't want to leak our stack trace, so just give a simple response.
			//This only executes in debug mode and gives a more verbose error by providing a stack trace.
			TryGetDebuggableExceptionDetails(exception); 

            return Constants.Error.ExceptionDetails;
        }

        [Conditional("DEBUG")]
        private void TryGetDebuggableExceptionDetails(Exception exception)
        {
            Constants.Error.ExceptionDetails = exception.ToString();
        }
    }
}