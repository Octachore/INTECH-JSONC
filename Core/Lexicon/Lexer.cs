using System.Text;

namespace Core.Lexicon
{
    internal class Lexer
    {
        private readonly string _input;
        private int _pos;

        public Lexer(string input)
        {
            _input = input;
        }

        public AbstractToken CurrentToken { get; internal set; }

        public bool IsEnd => _pos >= _input.Length;

        public bool IsMultilineComment => Peek() == '/' && Peek(1) == '*';

        public bool IsNumber => char.IsNumber(Peek());

        public bool IsOneLineComment => Peek() == '/' && Peek(1) == '/';

        public bool IsWhiteSpace => char.IsWhiteSpace(Peek());

        public bool IsWord => char.IsLetter(Peek());

        public bool IsEndOfLine => Peek() == '\r' || Peek() == '\n';

        public bool IsEndOfMultilineComment => Peek() == '*' && Peek(1) == '/';

        public char Consume() => _input[_pos++];

        public char Peek() => Peek(0);

        public char Peek(int offset) => _input[_pos + offset];

        internal AbstractToken GetNextToken()
        {
            while (IsEnd || IsWhiteSpace)
            {
                if (IsEnd) return null;
                if (IsWhiteSpace) HandleWhiteSpaces();
            }

            return DetermineToken();
        }

        private AbstractToken DetermineToken()
        {
            char c = Peek();
            switch (c)
            {
                case '(':
                    CurrentToken = new Token<string>(TokenType.OpeningParenthesis, "(");
                    break;
                case ')':
                    CurrentToken = new Token<string>(TokenType.ClosingParenthesis, ")");
                    break;
                case '[':
                    CurrentToken = new Token<string>(TokenType.OpeningSquareBracket, "[");
                    break;
                case ']':
                    CurrentToken = new Token<string>(TokenType.ClosingSquareBracket, "]");
                    break;
                case '{':
                    CurrentToken = new Token<string>(TokenType.OpeningCurlyBracket, "{");
                    break;
                case '}':
                    CurrentToken = new Token<string>(TokenType.ClosingCurlyBracket, "}");
                    break;
                case ':':
                    CurrentToken = new Token<string>(TokenType.Colon, ":");
                    break;
                case ',':
                    CurrentToken = new Token<string>(TokenType.Coma, ",");
                    break;
                case '"':
                    CurrentToken = new Token<string>(TokenType.DoubleQuotes, "\"");
                    break;
                default:
                    if (IsNumber) return CurrentToken = Number();
                    else if (IsWord) return CurrentToken = Word();
                    else if (IsOneLineComment) return CurrentToken = OneLineComment();
                    else if (IsMultilineComment) return CurrentToken = MultilineComment();
                    throw new UnknownTokenException(c);
            }
            Consume();
            return CurrentToken;
        }

        private AbstractToken MultilineComment()
        {
            Consume();
            Consume();
            var builder = new StringBuilder();
            do
            {
                builder.Append(Peek());
                Consume();
            } while (!IsEnd && !IsEndOfMultilineComment);
            Consume();
            Consume();
            return new Token<string>(TokenType.MultilineComment, builder.ToString());
        }

        private AbstractToken OneLineComment()
        {
            Consume();
            Consume();
            var builder = new StringBuilder();
            do
            {
                builder.Append(Peek());
                Consume();
            } while (!IsEnd && !IsEndOfLine);
            return new Token<string>(TokenType.OneLineComment, builder.ToString());
        }

        private void HandleWhiteSpaces()
        {
            do
            {
                Consume();
            } while (!IsEnd && IsWhiteSpace);
        }

        private AbstractToken Number()
        {
            var builder = new StringBuilder();
            do
            {
                builder.Append(Peek());
                Consume();
            } while (!IsEnd && IsNumber);
            return new Token<int>(TokenType.Number, int.Parse(builder.ToString()));
        }

        private AbstractToken Word()
        {
            var builder = new StringBuilder();
            do
            {
                builder.Append(Peek());
                Consume();
            } while (!IsEnd && IsWord);
            return new Token<string>(TokenType.Word, builder.ToString());
        }
    }
}
