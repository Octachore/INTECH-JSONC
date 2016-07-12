namespace Core.Lexicon
{
    internal abstract class AbstractToken
    {
        public AbstractToken(TokenType type)
        {
            Type = type;
        }

        public TokenType Type { get; set; }
    }
}
