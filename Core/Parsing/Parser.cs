using System.Collections.Generic;
using Core.Exceptions;
using Core.Lexicon;
using Core.Nodes;

namespace Core.Parsing
{
    internal class Parser
    {
        private List<string> _commentsPool = new List<string>();
        private Lexer _lexer;

        public Parser(string input)
        {
            _lexer = new Lexer(input);
        }

        internal Node Parse()
        {
            Token token = _lexer.GetNextToken();

            if (token == null) return null;

            return ParseObject();
        }

        private Node ParseObject()
        {
            _lexer.Expect(TokenType.OpeningCurlyBracket);
            _lexer.GetNextToken();

            var node = new ObjectNode();
            while (_lexer.CurrentToken.Type != TokenType.ClosingCurlyBracket)
            {
                AssignmentNode property = ParseProperty();
                node.Properties.Add(property);
                _lexer.GetNextToken();
                if (_lexer.IsComment) node.Comments.AddRange(HandleComments());
                if (_lexer.CurrentToken.Type != TokenType.ClosingCurlyBracket)
                {
                    _lexer.Expect(TokenType.Coma, TokenType.OneLineComment, TokenType.MultilineComment);
                    _lexer.GetNextToken();
                }
            }

            _lexer.Expect(TokenType.ClosingCurlyBracket);
            _lexer.GetNextToken();

            return node;
        }

        private AssignmentNode ParseProperty()
        {
            var node = new AssignmentNode();
            _lexer.Expect(TokenType.Word, TokenType.OneLineComment, TokenType.MultilineComment);

            if (_lexer.IsComment) node.Comments.AddRange(HandleComments());

            node.Assignee = _lexer.CurrentToken.Value;

            _lexer.GetNextToken();
            _lexer.Expect(TokenType.Equals);
            _lexer.GetNextToken();

            node.Value = ParseValue();

            return node;
        }

        private List<string> HandleComments()
        {
            _lexer.Expect(TokenType.OneLineComment, TokenType.MultilineComment);

            var comments = new List<string>();
            while (_lexer.IsComment)
            {
                comments.Add(_lexer.CurrentToken.Value);
                _lexer.GetNextToken();
            }
            return comments;
        }

        private ListNode ParseList()
        {
            _lexer.Expect(TokenType.OpeningSquareBracket);
            _lexer.GetNextToken();

            var node = new ListNode();

            while (_lexer.CurrentToken.Type != TokenType.ClosingSquareBracket)
            {
                node.Values.Add(ParseValue());
                _lexer.GetNextToken();

                if (_lexer.CurrentToken.Type != TokenType.ClosingSquareBracket)
                {
                    _lexer.Expect(TokenType.Coma);
                    _lexer.GetNextToken();
                }
            }

            return node;
        }

        private Node ParseValue()
        {
            switch (_lexer.CurrentToken.Type)
            {
                //case TokenType.Word:
                case TokenType.DoubleQuotes:
                    return ParseString();
                case TokenType.Number:
                    return new ValueNode<int>(int.Parse(_lexer.CurrentToken.Value));
                case TokenType.OpeningCurlyBracket:
                    return ParseObject();
                case TokenType.OpeningSquareBracket:
                    return ParseList();
                default:
                    throw new InvalidSyntaxException(_lexer.CurrentToken?.Type, TokenType.DoubleQuotes, TokenType.Number, TokenType.OpeningCurlyBracket, TokenType.OpeningSquareBracket);
            }
        }

        private ValueNode<string> ParseString()
        {
            _lexer.Expect(TokenType.DoubleQuotes);
            _lexer.GetNextToken();

            var words = new List<string>();
            while (_lexer.CurrentToken?.Type != TokenType.DoubleQuotes)
            {
                words.Add(_lexer.CurrentToken.Value);
                _lexer.GetNextToken();
            }

            return new ValueNode<string>(string.Join(" ", words));
        }
    }
}
