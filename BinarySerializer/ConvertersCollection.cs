using System;
using System.Collections;
using System.Collections.Generic;
using BinarySerializer.Writers;
using BinarySerializer.Writers.Converters;

namespace BinarySerializer
{
    public class ConvertersCollection : ICollection<IConverter>
    {
        private readonly IDictionary<Type, IConverter> _collectionImplementation;

        public ConvertersCollection()
        {
            _collectionImplementation = new Dictionary<Type, IConverter>();
        }
        
        public IEnumerator<IConverter> GetEnumerator()
        {
            return _collectionImplementation.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _collectionImplementation).GetEnumerator();
        }

        public void Add(IConverter item)
        {
            _collectionImplementation[item.Type] = item;
        }

        public void Clear()
        {
            _collectionImplementation.Clear();
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
            if (_collectionImplementation.ContainsKey(item.Type) && _collectionImplementation[item.Type] == item)
                return Remove(item.Type);
            return false;
        }

        public bool Remove(Type type)
        {
            return _collectionImplementation.Remove(type);
        }

        public int Count => _collectionImplementation.Count;

        public bool IsReadOnly => _collectionImplementation.IsReadOnly;
    }
}