using System;

namespace Core.Lexicon
{
    [Serializable]
    internal class UnknownTokenException : Exception
    {
        public UnknownTokenException(char c) : base($"Unknown token : {c}.")
        {
        }
    }
}