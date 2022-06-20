using Healthware.Core.Containers;

namespace Healthware.Core.Logging
{
    public static class Log
    {
        public static ILogger For(object instance)
        {
            try
            {
                return Resolve.AnImplementationOf<ILogFactory>().CreateFor(instance.GetType());
            }
            catch
            {
                return new ConsoleLogger();
            }
        }
    }
}