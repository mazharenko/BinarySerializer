using System;
using System.Collections.Generic;
using BinarySerializer.Extensions;

namespace BinarySerializer.Adapters
{
    internal class ContractRootAdapter : ContractMemberAdapter
    {
        public ContractRootAdapter(ObjectAdapter contract) : base(Constants.RootMark, contract)
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

    }
}