namespace Healthware.Core.Utility
{
    public interface IConfiguration<T>
    {
        void Configure(T item);
    }
}