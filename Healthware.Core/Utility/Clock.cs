using System;

namespace Healthware.Core.Utility
{
    public static class Clock
    {
        static Clock()
        {
            Reset();
        }

        public static DateTime Now()
        {
            return _currentTimeProvider();
        }

        public static void Reset()
        {
            _currentTimeProvider = DefaultTimeProvider;
        }

        private static Func<DateTime> _currentTimeProvider;
        private static readonly Func<DateTime> DefaultTimeProvider = () => DateTime.UtcNow;
    }
}