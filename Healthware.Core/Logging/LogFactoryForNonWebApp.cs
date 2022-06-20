using System;
using log4net;

namespace Healthware.Core.Logging
{
    public class LogFactoryForNonWebApp : ILogFactory
    {
        public LogFactoryForNonWebApp(ILogSettingsIntializer command)
        {
            command.Execute();
        }

        public ILogger CreateFor(Type type)
        {
            return new Log4NetWithPrefixLogger(LogManager.GetLogger(type));
        }
    }
}
