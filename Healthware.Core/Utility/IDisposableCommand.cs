using System;

namespace Healthware.Core.Utility
{
    public interface IDisposableCommand : ICommand, IDisposable
    {
    }
}