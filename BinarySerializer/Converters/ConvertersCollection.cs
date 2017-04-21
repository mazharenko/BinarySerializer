using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinarySerializer.Converters
{
    public class ConvertersCollection : ICollection<IConverter>
    {
        private readonly IDictionary<Type, IConverter> _collectionImplementation;

        public ConvertersCollection(IEnumerable<IConverter> source)
        {
            _collectionImplementation = source.ToDictionary(c => c.Type);
        }
        
        public IEnumerator<IConverter> GetEnumerator()
        {
            return _collectionImplementation.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _collectionImplementation).GetEnumerator();
        }

        public IConverter FindExact(Type @for) => _collectionImplementation[@for];

        public IConverter Find(Type @for)
        {
            var currentType = @for;
            while (currentType != null && currentType != typeof(object))
            {
                IConverter converter;
                if (_collectionImplementation.TryGetValue(currentType, out converter))
                    return converter;
                currentType = currentType.BaseType;
            }
            return null;
        }

        public void Add(IConverter item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Contains(IConverter item)
        {
            return _collectionImplementation.Values.Contains(item);
        }

        public bool Contains(Type type)
        {
            return _collectionImplementation.ContainsKey(type);
        }

        public void CopyTo(IConverter[] array, int arrayIndex)
        {
            _collectionImplementation.Values.CopyTo(array, arrayIndex);
        }

        public bool Remove(IConverter item)
        {
            throw new NotSupportedException();
        }

        public int Count => _collectionImplementation.Count;

        // todo: !readonly
        public bool IsReadOnly => true;
    }
}