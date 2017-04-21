using System;

namespace BinarySerializer.Adapters
{
    public class ObjectAdapter
    {
        public ObjectAdapter(Type type)
        {
            Type = type;
        }

        public ObjectAdapter(object @object) : this(@object.GetType(), @object)
        {
        }

        public ObjectAdapter(Type type, object @object) : this(type)
        {
            Object = @object;
        }

        protected object Object { get; set; }

        public Type Type { get; }

        public virtual object GetValue()
        {
            return Object;
        }

        public virtual void SetValue(object value)
        {
            if (value != null && value.GetType() != Type)
                throw new ArgumentException("Object and Type don't match", nameof(value));
            Object = value;
        }

    }
}