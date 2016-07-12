namespace Core.Lexicon
{
    internal class Token<T> : AbstractToken
    {
        public Token(TokenType type, T value) : base(type)
        {
            Value = value;
        }

        public T Value { get; set; }

        public override string ToString() => $"{Type} {Value}";

        public override bool Equals(object obj)
        {
            Token<T> token = obj as Token<T>;
            if (token == null) return false;
            return Value.Equals(token.Value) && Type.Equals(token.Type);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() + 11 * Type.GetHashCode();
        }
    }
}
