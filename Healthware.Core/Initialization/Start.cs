using System;
using System.Collections.Generic;
using System.Diagnostics;
using Castle.DynamicProxy;
using Healthware.Core.Containers;
using Healthware.Core.DTO;
using Healthware.Core.Logging;
using Healthware.Core.Utility;

namespace Healthware.Core.Initialization
{
    static public class Start
    {
        static public DependencyRegistry TheApplication(Action<DependencyRegistry> registerAdditionalComponents = null, Func<IEnumerable<Type>> additionalTypesToExclude = null)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var dependencyRegistry = WireupIOC(registerAdditionalComponents, additionalTypesToExclude);
            Resolve.InitializeWith(dependencyRegistry);
            stopwatch.Stop();

            new Object().Log().Informational("Start up time: {0}",stopwatch.Elapsed);
            return dependencyRegistry;
        }

        public static DependencyRegistry WireupIOC(Action<DependencyRegistry> registerAdditionalComponents = null, Func<IEnumerable<Type>> additionalTypesToExclude = null)
        {
            var componentExclusionSpecification = new ComponentExclusionSpecification();
            
            additionalTypesToExclude?.Invoke()?.Each(x => componentExclusionSpecification.Add(x));

            var registry = new DependencyRegistry(new WindsorContainerFactory(componentExclusionSpecification));
            var proxyGenerator = new ProxyGenerator();
            
            registry.Singleton<IContext, DictionaryContext>();

            if (registerAdditionalComponents != null)
            {
                registerAdditionalComponents(registry);
            }

            return registry;
        }
    }

    static public class Stop
    {
        static public void TheApplication()
        {
            Resolve.InitializeWith(null);
        }
    }
}