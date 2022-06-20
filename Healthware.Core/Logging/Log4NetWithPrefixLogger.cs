using System;
using log4net;

namespace Healthware.Core.Logging
{
    public class Log4NetWithPrefixLogger : Log4NetLogger
    {
        public Log4NetWithPrefixLogger(ILog underlying_logger) : base(underlying_logger)
        {
        }

        public override void Error(Exception error)
        {
            base.Error(error);
        }
    }
}
