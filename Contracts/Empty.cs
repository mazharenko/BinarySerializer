namespace Contracts
{
    public class Empty
    {
        protected bool Equals(Empty other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Empty) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}