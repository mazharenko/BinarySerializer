﻿using BinarySerializer.Attributes;

namespace BinarySerializer.UnitTests.Contracts
{
    public class EmptyHolder
    {
        [SerializerMember(100)]
        public Empty Empty = new Empty();

        [SerializerMember(101)]
        public EmptySubHolder SubHolder { get; set; }
    }
}