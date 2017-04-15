using System;
using System.Reflection;
using BinarySerializer.Attributes;

namespace BinarySerializer
{
    internal class ContractFieldAdapter : ContractMemberAdapter
    {
        protected FieldInfo Info { get; }

        public ContractFieldAdapter(FieldInfo info, int id, object contract)
            : base(id, contract)
        {
            Info = info;
        }

        public override string Name => Info.Name;
        public override Type Type => Info.FieldType; //TODO: ????

        public override object GetValue()
        {
            return Info.GetValue(Contract);
        }

        public override void SetValue(object value)
        {
            Info.SetValue(Contract, value);
        }
    }
}