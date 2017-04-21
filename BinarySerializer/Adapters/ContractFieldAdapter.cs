using System;
using System.Reflection;

namespace BinarySerializer.Adapters
{
    internal class ContractFieldAdapter : ContractMemberAdapter
    {
        protected FieldInfo Info { get; }

        public ContractFieldAdapter(FieldInfo info, int id, ObjectAdapter contract)
            : base(id, contract)
        {
            Info = info;
        }

        public override string Name => Info.Name;
        public override Type Type => Info.FieldType;

        public override object GetValue()
        {
            return Info.GetValue(ContractAdapter.GetValue());
        }

        public override void SetValue(object value)
        {
            Info.SetValue(ContractAdapter.GetValue(), value);
        }
    }
}