using System.IO;
using Healthware.Core.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Healthware.Core.Web.Web.Configuration
{
    public static class HostingEnvironmentExtensions
    {
        public static IConfigurationRoot GetAppConfiguration(this IWebHostEnvironment env)
        {
            return ApplicationSetting.Get(Path.Combine(env.ContentRootPath, Constants.Config), env.EnvironmentName, env.IsDevelopment());
        }
    }
}
