using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HealthWare.ActiveASSIST.WebAPI.AppStart
{
    public class SwaggerCustomHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizationRequired = context.MethodInfo.CustomAttributes.Any(a => a.AttributeType.Name == "AuthorizeAttribute" || a.AttributeType.Name == "HasPermissionAttribute");

            if (authorizationRequired)
            {
                operation.Parameters ??= new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "token",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the token. Example: \"token: {token}\"",
                    Required = false

                });
            }
        }
    }

}
