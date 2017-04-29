using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BinarySerializer.Adapters
{
    internal class ContractSingleObjectAdapter : ContractRootAdapter
    {
        private readonly ReadOnlyCollection<ContractMemberAdapter> _children;

        public ContractSingleObjectAdapter(ObjectAdapter contract) : base(contract)
        {
            _children = new List<ContractMemberAdapter>().AsReadOnly();
        }

        public override IList<ContractMemberAdapter> Children => _children;
    }
}