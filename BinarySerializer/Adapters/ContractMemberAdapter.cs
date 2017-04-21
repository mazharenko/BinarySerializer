using System;
using System.Collections.Generic;

namespace BinarySerializer.Adapters
{
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
}