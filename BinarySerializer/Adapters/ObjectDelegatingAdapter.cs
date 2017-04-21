using System;

namespace BinarySerializer.Adapters
{
    public class ObjectDelegatingAdapter : ObjectAdapter
    {
        public ContractMemberAdapter DelegateTo { get; }

        public ObjectDelegatingAdapter(ContractMemberAdapter delegateTo) : this(null, delegateTo)
        {
        }

        public ObjectDelegatingAdapter(object @object, ContractMemberAdapter delegateTo) : base(delegateTo.Type, @object)
        {
            if (@object != null && @object.GetType() == delegateTo.Type)
                throw new ArgumentException();
            DelegateTo = delegateTo;
        }

        public override object GetValue()
        {
            return Object = DelegateTo.GetValue();
        }

        public override void SetValue(object value)
        {
            DelegateTo.SetValue(value);
            Object = value;
        }
    }
}