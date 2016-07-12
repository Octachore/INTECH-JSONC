using System.Linq;
using System.Text;
using Core.Exceptions;

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

        public Token CurrentToken { get; internal set; }

        public bool IsComment => CurrentToken.Type == TokenType.OneLineComment || CurrentToken.Type == TokenType.MultilineComment;
        public bool IsEnd => _pos >= _input.Length;

        public bool IsEndOfLine => Peek() == '\r' || Peek() == '\n';

        public bool IsEndOfMultilineComment => Peek() == '*' && Peek(1) == '/';

        public bool IsMultilineComment => Peek() == '/' && Peek(1) == '*';

        public bool IsNumber => char.IsNumber(Peek());

        public bool IsOneLineComment => Peek() == '/' && Peek(1) == '/';

        public bool IsWhiteSpace => char.IsWhiteSpace(Peek());

        public bool IsWord => char.IsLetter(Peek());

        public char Consume() => _input[_pos++];

        public char Peek() => Peek(0);

        public char Peek(int offset) => _input[_pos + offset];

        internal void Expect(params TokenType[] expectedTypes)
        {
            if (!expectedTypes.Contains(CurrentToken.Type)) throw new InvalidSyntaxException(CurrentToken?.Type, expectedTypes);
        }

        internal Token GetNextToken()
        {
            while (IsEnd || IsWhiteSpace)
            {
                if (IsEnd) return null;
                if (IsWhiteSpace) HandleWhiteSpaces();
            }

            return DetermineToken();
        }

        private Token DetermineToken()
        {
            char c = Peek();
            switch (c)
            {
                case '(':
                    CurrentToken = new Token(TokenType.OpeningParenthesis, "(");
                    break;
                case ')':
                    CurrentToken = new Token(TokenType.ClosingParenthesis, ")");
                    break;
                case '[':
                    CurrentToken = new Token(TokenType.OpeningSquareBracket, "[");
                    break;
                case ']':
                    CurrentToken = new Token(TokenType.ClosingSquareBracket, "]");
                    break;
                case '{':
                    CurrentToken = new Token(TokenType.OpeningCurlyBracket, "{");
                    break;
                case '}':
                    CurrentToken = new Token(TokenType.ClosingCurlyBracket, "}");
                    break;
                case ':':
                    CurrentToken = new Token(TokenType.Colon, ":");
                    break;
                case ',':
                    CurrentToken = new Token(TokenType.Coma, ",");
                    break;
                case '"':
                    CurrentToken = new Token(TokenType.DoubleQuotes, "\"");
                    break;
                case '=':
                    CurrentToken = new Token(TokenType.Equals, "=");
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

        private void HandleWhiteSpaces()
        {
            do
            {
                Consume();
            } while (!IsEnd && IsWhiteSpace);
        }

        private Token MultilineComment()
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
            return new Token(TokenType.MultilineComment, builder.ToString());
        }

        private Token Number()
        {
            var builder = new StringBuilder();
            do
            {
                builder.Append(Peek());
                Consume();
            } while (!IsEnd && IsNumber);
            return new Token(TokenType.Number, builder.ToString());
        }

        private Token OneLineComment()
        {
            Consume();
            Consume();
            var builder = new StringBuilder();
            do
            {
                builder.Append(Peek());
                Consume();
            } while (!IsEnd && !IsEndOfLine);
            return new Token(TokenType.OneLineComment, builder.ToString());
        }
        private Token Word()
        {
            var builder = new StringBuilder();
            do
            {
                builder.Append(Peek());
                Consume();
            } while (!IsEnd && IsWord);
            return new Token(TokenType.Word, builder.ToString());
        }
    }
}
