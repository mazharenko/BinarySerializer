using System;
using System.Reflection;

namespace BinarySerializer
{
    internal class ContractPropertyAdapter : ContractMemberAdapter
    {
        protected PropertyInfo Info { get; }

        public ContractPropertyAdapter(PropertyInfo info, int id, object contract)
            : base(id, contract)
        {
            if (!info.CanRead || !info.CanWrite)
                throw new ArgumentException();
            Info = info;
        }

        public override string Name => Info.Name;
        public override Type Type => Info.PropertyType; //TODO: ????

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