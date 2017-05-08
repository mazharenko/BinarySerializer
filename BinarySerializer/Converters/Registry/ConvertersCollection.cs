using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Converters.Base;

namespace BinarySerializer.Converters.Registry
{
    public class ConvertersCollection<T> : ICollection<T> where T : class, IConverterBase
    {
        private readonly IDictionary<Type, T> _collectionImplementation;

        public ConvertersCollection() : this(Enumerable.Empty<T>())
        {
        }

        public ConvertersCollection(IEnumerable<T> source)
        {
            _collectionImplementation = source.ToDictionary(c => c.Type);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collectionImplementation.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _collectionImplementation).GetEnumerator();
        }

        public T FindExact(Type @for) => _collectionImplementation[@for];

        public T Find(Type @for)
        {
            var currentType = @for;
            while (currentType != null && currentType != typeof(object))
            {
                T converter;
                if (_collectionImplementation.TryGetValue(currentType, out converter))
                    return converter;
                currentType = currentType.BaseType;
            }
            return null;
        }

        public void Add(T item)
        {
            _collectionImplementation[item.Type] = item;
        }

        public void Clear()
        {
            _collectionImplementation.Clear();
        }

        public bool Contains(T item)
        {
            return _collectionImplementation.Values.Contains(item);
        }

        public bool Contains(Type type)
        {
            return _collectionImplementation.ContainsKey(type);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collectionImplementation.Values.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _collectionImplementation.Remove(item.Type);
        }

        public int Count => _collectionImplementation.Count;

        public bool IsReadOnly => false;
    }
}