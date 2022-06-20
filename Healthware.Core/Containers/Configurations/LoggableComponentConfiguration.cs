using Castle.MicroKernel.Registration;
using Healthware.Core.Utility;

namespace Healthware.Core.Containers.Configurations
{
    internal interface ILoggableComponentConfiguration : IComponentRegistrationConfiguration
    {
    }

    internal class LoggableComponentConfiguration : ILoggableComponentConfiguration
    {
        public void Configure(ComponentRegistration item)
        {
            if (typeof(ILoggable).IsAssignableFrom(item.Implementation))
            {
            }
        }
    }
}