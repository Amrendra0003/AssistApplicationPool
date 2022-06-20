using System;
using System.Globalization;

namespace Healthware.Core.Extensions
{
    public static class DateExtensions
    {
        private const string DateFormat = "MM/dd/yyyy";
        public static string ToInvariantDateString(this DateTime dateTime)
        {
            return dateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
        }
    }
}
