using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Attributes;

namespace Contracts
{
    public class ListComplexObject
    {
        [SerializerMember(701)]
        public List<int> ListInt { get; set; }

        [SerializerMember(702)]

        public int[] ArrayInt { get; set; }

        [SerializerMember(703)]
        public List<ListComplexObject> ListComplex { get; set; }

        [SerializerMember(704)]
        public ListComplexObject[] ArrayComplex { get; set; }

        protected bool Equals(ListComplexObject other)
        {
            return SequencesEqual(ListInt, other.ListInt)
                   && SequencesEqual(ArrayInt, other.ArrayInt)
                   && SequencesEqual(ListComplex, other.ListComplex)
                   && SequencesEqual(ArrayComplex, other.ArrayComplex);
        }

        private static bool SequencesEqual<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            return first == null && second == null || first != null && second != null && first.SequenceEqual(second);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ListComplexObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ListInt != null ? ListInt.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ArrayInt != null ? ArrayInt.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ListComplex != null ? ListComplex.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ArrayComplex != null ? ArrayComplex.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}