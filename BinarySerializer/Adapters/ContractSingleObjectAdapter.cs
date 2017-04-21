using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BinarySerializer.Adapters
{
    internal class ContractSingleObjectAdapter : ContractMemberAdapter
    {
        public ContractSingleObjectAdapter(int id, ObjectAdapter contract) : base(id, contract)
        {
        }

        public override string Name => "root";
        public override Type Type => ContractAdapter.Type;

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