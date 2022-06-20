namespace Healthware.Core.Extensions
{
    public static class GenericTypeExtensions
    {
        public static bool IsNull<T>(this T item) where T : class
        {
            return item == null;
        }

        public static bool IsNotNull<T>(this T item) where T : class
        {
            return item != null;
        }
        
    }
}