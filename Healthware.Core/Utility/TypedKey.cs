using System.Collections;

namespace Healthware.Core.Utility
{
    public class TypedKey<T> : IKey<T>
    {
        private readonly string keyName;

        public TypedKey(string name = null)
        {
            keyName = name;
        }
        
        public bool IsFoundIn(IDictionary items)
        {
            return items.Contains(CreateKey());
        }

        public T ParseFrom(IDictionary items)
        {
            return (T) items[CreateKey()];
        }

        public void RemoveFrom(IDictionary items)
        {
            if (IsFoundIn(items))
            {
                items.Remove(CreateKey());
            }
        }

        public void AddValueTo(IDictionary items, T value)
        {
            items[CreateKey()] = value;
        }

        public bool Equals(TypedKey<T> obj)
        {
            return !ReferenceEquals(null, obj);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TypedKey<T>)) return false;
            return Equals((TypedKey<T>) obj);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        private string CreateKey()
        {
            return keyName ?? GetType().FullName;
        }
    }
}