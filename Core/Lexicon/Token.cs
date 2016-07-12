namespace Core.Lexicon
{
    internal class Token
    {
        public Token(TokenType type, string value)
        {
            Value = value;
            Type = type;
        }

        public Token(TokenType type, int value) : this(type, value.ToString())
        {
        }

        public string Value { get; set; }

        public TokenType Type { get; set; }

        public override bool Equals(object obj)
        {
            Token token = obj as Token;
            if (token == null) return false;
            return Value.Equals(token.Value) && Type.Equals(token.Type);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() + 11 * Type.GetHashCode();
        }

        public override string ToString() => $"{Type} {Value}";
    }
}