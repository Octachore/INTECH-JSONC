using System;

namespace Core.Exceptions
{
    internal class UnknownTokenException : Exception
    {
        public UnknownTokenException(char c) : base($"Unknown token : {c}.")
        {
        }
    }
}