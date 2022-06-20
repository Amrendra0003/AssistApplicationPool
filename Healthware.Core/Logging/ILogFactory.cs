using System;

namespace Healthware.Core.Logging
{
    public interface ILogFactory
    {
        ILogger CreateFor(Type type);
    }
}