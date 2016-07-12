using System;
using Core.Lexicon;

namespace Core.Exceptions
{
    internal class InvalidSyntaxException : Exception
    {
        string _message;
        public override string Message => _message;

        public TokenType[] ExpectedTypes { get; set; }

        public TokenType ActualType { get; set; }

        public InvalidSyntaxException(TokenType? actualType, params TokenType[] expectedTypes)
        {
            _message = $"Wrong token type. Got {actualType} but needed one of the following: [ {string.Join(", ", expectedTypes)} ]";
        }
    }
}
