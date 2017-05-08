using System;
using BinarySerializer.Converters.Base;

namespace BinarySerializer.Converters
{
    public class TimeSpanConverter : SubConverter<TimeSpan, int>
    {
        protected override int WriteInternal(TimeSpan source)
        {
            return (int)source.TotalMilliseconds;
        }

        protected override TimeSpan ReadInternal(int source)
        {
            return TimeSpan.FromMilliseconds(source);
        }
    }
}