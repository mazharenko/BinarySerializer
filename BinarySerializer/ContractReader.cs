using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BinarySerializer.Attributes;
using BinarySerializer.Exceptions;

namespace BinarySerializer
{
    internal class ContractReader
    {
        private readonly SerializationContext _context;

        public ContractReader(SerializationContext settings)
        {
            _context = settings;
        }
// todo что теперь делать с этой проверкой
        public void ValidateContractType(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));


            // todo: или забить, пусть десериализация упадет, если что
            // либо создаваемый, либо конвертируемый
            /*if (type.IsGenericParameter || type.IsGenericTypeDefinition || type.IsAbstract
                || type.GetConstructor(new Type[0]) == null)
                throw new InvalidConfigurationException($"The specified type can't by instantiated - {type}");*/
        }

        private bool IsTerminalType(Type type)
        {
            return false;
        }

        public ICollection<ContractMemberAdapter> CollectMembers(Type type, object contract)
        {
            if (contract == null) throw new ArgumentNullException(nameof(contract));
            if (!type.IsInstanceOfType(contract))
                throw new ArgumentException();

            ValidateContractType(type);

            var visitedAttributes = new List<int>();

            var properties = from prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                let id = GetAndCheckMemberId(type, prop, visitedAttributes)
                where id != null
                select new ContractPropertyAdapter(prop, id.Value, contract);

            var fields = from field in type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                let id = GetAndCheckMemberId(type, field, visitedAttributes)
                where id != null
                select new ContractFieldAdapter(field, id.Value, contract);

            var members = properties.Cast<ContractMemberAdapter>().Concat(fields).ToList();
            members.ForEach(a =>
            {
                if (!IsTerminalType(a.Type))
                    a.Children = CollectMembers(a.Type, a.GetValue());
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