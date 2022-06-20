using System;
using System.Linq;
using Healthware.Core.Constants;
using Healthware.Core.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Healthware.Core.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public ValidationErrorCollection Errors { get; set; }

        public ApiException(string message,
            int statusCode = 500,
            ValidationErrorCollection errors = null) :
            base(message)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        public ApiException(Exception ex, int statusCode = 500) : base(ex.Message)
        {
            StatusCode = statusCode;
        }
    }

    public class ApiError
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public string Detail { get; set; }
        public ValidationErrorCollection Errors { get; set; }

        public ApiError(string message)
        {
            this.Message = message;
            IsError = true;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            IsError = true;
            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
            {
                Message = Error.PleaseCorrectTheErrorsMessage;
            }
        }
    }
}