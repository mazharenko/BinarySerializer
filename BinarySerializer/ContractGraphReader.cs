using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BinarySerializer.Adapters;
using BinarySerializer.Attributes;
using BinarySerializer.Exceptions;

namespace BinarySerializer
{
    internal class ContractGraphReader
    {
        public ContractMemberAdapter CollectMembers(Type type, object contract)
        {
            if (contract == null) return null;
            if (!type.IsInstanceOfType(contract))
                throw new ArgumentException();

            return CollectMembers(new ObjectAdapter(contract));
        }

        public ContractMemberAdapter CollectMembers(ObjectAdapter contractAdapter)
        {
            var members = CollectMembersInternal(contractAdapter);

            if (!members.Any())
                return new ContractSingleObjectAdapter(contractAdapter);

            var root = new ContractRootAdapter(contractAdapter);
            members.ForEach(root.Children.Add);
            return root;
        }

        private List<ContractMemberAdapter> CollectMembersInternal(ObjectAdapter contractAdapter)
        {
            if (contractAdapter == null)
                return new List<ContractMemberAdapter>();
            
            var visitedAttributes = new List<int>();

            var properties = from prop in contractAdapter.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                let id = GetAndCheckMemberId(contractAdapter.Type, prop, visitedAttributes)
                where id != null
                select new ContractPropertyAdapter(prop, id.Value, contractAdapter);

            var fields = from field in contractAdapter.Type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                let id = GetAndCheckMemberId(contractAdapter.Type, field, visitedAttributes)
                where id != null
                select new ContractFieldAdapter(field, id.Value, contractAdapter);

            var members = properties.Cast<ContractMemberAdapter>().Concat(fields).ToList();
            members.ForEach(a =>
            {
                CollectMembersInternal(new ObjectDelegatingAdapter(a)).ForEach(a.Children.Add);
            });
            return members;
        }

        private static int? GetAndCheckMemberId(Type type, MemberInfo prop, ICollection<int> visitedAttributes)
        {
            var attr = prop.GetCustomAttribute<SerializerMemberAttribute>();
            if (attr == null)
                return null;
            var id = attr.Id;
            if (visitedAttributes.Contains(id))
                throw new DuplicateMemberIdsException(type);
            visitedAttributes.Add(id);
            return id;
        }
    }
}