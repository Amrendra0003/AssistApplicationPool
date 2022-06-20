using System.Collections;

namespace Healthware.Core.Utility
{
    public interface IKey<T>
    {
        bool IsFoundIn(IDictionary items);
        T ParseFrom(IDictionary items);
        void RemoveFrom(IDictionary items);
        void AddValueTo(IDictionary items, T value);
    }
}