﻿namespace BinarySerializer.Console
{
    public interface IOptions
    {
        string Type { get; set; }
        string Assembly { get; set; }
        string Input { get; set; }
        string Output { get; set; }
    }
}