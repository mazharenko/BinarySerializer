using System;
using System.Reflection;

namespace BinarySerializer.Adapters
{
    internal class ContractPropertyAdapter : ContractMemberAdapter
    {
        protected PropertyInfo Info { get; }

        public ContractPropertyAdapter(PropertyInfo info, int id, ObjectAdapter contract)
            : base(id, contract)
        {
            if (!info.CanRead || !info.CanWrite)
                throw new ArgumentException();
            Info = info;
        }

        public override string Name => Info.Name;
        public override Type Type => Info.PropertyType;

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