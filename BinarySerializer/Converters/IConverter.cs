﻿using System;
using System.IO;

namespace BinarySerializer.Converters
{
    public interface IConverter
    {
        Type Type { get; }
        void Convert(object source, System.IO.Stream stream);
    }
}