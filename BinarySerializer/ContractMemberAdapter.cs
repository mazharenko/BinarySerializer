using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BinarySerializer
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

    public abstract class ContractMemberAdapter
    {
        public ObjectAdapter ContractAdapter { get; protected set; }
        public int Id { get; }
        public abstract string Name { get; }
        public abstract Type Type { get; }
        public abstract object GetValue();
        public abstract void SetValue(object value);
        public virtual IList<ContractMemberAdapter> Children { get; }

        protected ContractMemberAdapter(int id, ObjectAdapter contract)
        {
            Id = id;
            ContractAdapter = contract;
            Children = new List<ContractMemberAdapter>();
        }
    }

    internal class ContractSingleObjectAdapter : ContractMemberAdapter
    {
        public ContractSingleObjectAdapter(int id, ObjectAdapter contract) : base(id, contract)
        {
        }

        public override string Name => "root";
        public override Type Type => ContractAdapter.GetType();

        public override object GetValue()
        {
            return ContractAdapter.GetValue();
        }

        public override void SetValue(object value)
        {
            ContractAdapter.SetValue(value);
        }

        public override IList<ContractMemberAdapter> Children
            => new ReadOnlyCollection<ContractMemberAdapter>(base.Children);
    }
}