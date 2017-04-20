﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BinarySerializer.Attributes;
using BinarySerializer.Exceptions;

namespace BinarySerializer
{
    internal class ContractReader
    {
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
            if (contract == null) return new List<ContractMemberAdapter>();
            if (!type.IsInstanceOfType(contract))
                throw new ArgumentException();

            return CollectMembers(new ObjectAdapter(contract));
        }

        public ICollection<ContractMemberAdapter> CollectMembers(ObjectAdapter contractAdapter)
        {
            if (contractAdapter == null) return new List<ContractMemberAdapter>();

            ValidateContractType(contractAdapter.Type);

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
                if (!IsTerminalType(a.Type))
                    CollectMembers(new ObjectDelegatingAdapter(a)).ForEach(a.Children.Add);
            });

            return members.Any()
                ? members
                : new ContractSingleObjectAdapter(0, contractAdapter).AsEnumerable<ContractMemberAdapter>().ToList();
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