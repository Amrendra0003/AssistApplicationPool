using System.Collections.Generic;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Healthware.Core.DTO;
using Healthware.Core.Utility;

namespace Healthware.Core.Containers.Configurations
{
    public interface IComponentRegistrationConfiguration : IConfiguration<ComponentRegistration>
    {
    }

    internal class ComponentRegistrationConfiguration : IComponentRegistrationConfiguration
    {
        readonly IList<IComponentRegistrationConfiguration> configurations;

        public ComponentRegistrationConfiguration()
            : this(
                new ControllerComponentConfiguration())
        {
        }

        ComponentRegistrationConfiguration(params IComponentRegistrationConfiguration[] configurations)
        {
            this.configurations = configurations;
        }

        public void Configure(ComponentRegistration item)
        {
            configurations.Each(x => x.Configure(item));
            if (item.Implementation.GetCustomAttributes(typeof(SingletonAttribute), false).Length > 0)
            {
                item.LifeStyle.Is(LifestyleType.Singleton);
            }
            else if (item.Implementation.GetCustomAttributes(typeof(ScopedAttribute), false).Length > 0)
            {
                item.LifestyleScoped();
            }
            else
            {
                item.LifeStyle.Is(LifestyleType.Transient);
            }
        }
    }
}