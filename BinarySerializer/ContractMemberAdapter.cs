using System;
using System.Collections.Generic;
using BinarySerializer.Attributes;

namespace BinarySerializer
{
    public abstract class ContractMemberAdapter
    {
        protected object Contract { get; }
        public int Id { get; }
        public abstract string Name { get; }
        public abstract Type Type { get; }
        public abstract object GetValue();
        public abstract void SetValue(object value);
        public ICollection<ContractMemberAdapter> Children { get; set; }

        protected ContractMemberAdapter(int id, object contract)
        {
            Id = id;
            Contract = contract;
        }
    }
}