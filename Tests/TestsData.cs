using System.Collections.Generic;
using Core.Lexicon;

namespace Tests
{
    internal class TestsData
    {
        public class Core
        {
            public class Lexer
            {
                public class TokenProduction
                {
                    private static class TestCase1
                    {
                        public const string Json = "{{{10,test,[1,2,3]:)(";
                        public static readonly IReadOnlyList<AbstractToken> Tokens = new List<AbstractToken>
                        {
                            new Token<string>(TokenType.OpeningCurlyBracket, "{"),
                            new Token<string>(TokenType.OpeningCurlyBracket, "{"),
                            new Token<string>(TokenType.OpeningCurlyBracket, "{"),
                            new Token<int>(TokenType.Number, 10),
                            new Token<string>(TokenType.Coma, ","),
                            new Token<string>(TokenType.Word, "test"),
                            new Token<string>(TokenType.Coma, ","),
                            new Token<string>(TokenType.OpeningSquareBracket, "["),
                            new Token<int>(TokenType.Number, 1),
                            new Token<string>(TokenType.Coma, ","),
                            new Token<int>(TokenType.Number, 2),
                            new Token<string>(TokenType.Coma, ","),
                            new Token<int>(TokenType.Number, 3),
                            new Token<string>(TokenType.ClosingSquareBracket, "]"),
                            new Token<string>(TokenType.Colon, ":"),
                            new Token<string>(TokenType.ClosingParenthesis, ")"),
                            new Token<string>(TokenType.OpeningParenthesis, "("),
                        };
                    }

                    private static class TestCase2
                    {
                        public const string Json = @"{
                                                    ""menu"": {
                                                        ""id"": ""abcde"",
                                                        ""value"": 10,
                                                        ""attributes"": {
                                                            ""events"": [
                                                                { ""value"": ""New"", ""onclick"": ""CreateNewDoc()"" },
                                                                { ""value"": ""Open"", ""onclick"": ""OpenDoc()"" }
                                                            ]
                                                        }
                                                    }
                                                }";

                        public static readonly IReadOnlyList<AbstractToken> Tokens = new List<AbstractToken>
                        {
                            new Token<string>(TokenType.OpeningCurlyBracket, "{"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "menu"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Colon, ":"),
                            new Token<string>(TokenType.OpeningCurlyBracket, "{"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "id"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Colon, ":"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "abcde"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Coma, ","),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "value"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Colon, ":"),
                            new Token<int>(TokenType.Number, 10),
                            new Token<string>(TokenType.Coma, ","),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "attributes"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Colon, ":"),
                            new Token<string>(TokenType.OpeningCurlyBracket, "{"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "events"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Colon, ":"),
                            new Token<string>(TokenType.OpeningSquareBracket, "["),
                            new Token<string>(TokenType.OpeningCurlyBracket, "{"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "value"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Colon, ":"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "New"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Coma, ","),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "onclick"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Colon, ":"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "CreateNewDoc"),
                            new Token<string>(TokenType.OpeningParenthesis, "("),
                            new Token<string>(TokenType.ClosingParenthesis, ")"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.ClosingCurlyBracket, "}"),
                            new Token<string>(TokenType.Coma, ","),
                            new Token<string>(TokenType.OpeningCurlyBracket, "{"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "value"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Colon, ":"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "Open"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Coma, ","),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "onclick"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Colon, ":"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.Word, "OpenDoc"),
                            new Token<string>(TokenType.OpeningParenthesis, "("),
                            new Token<string>(TokenType.ClosingParenthesis, ")"),
                            new Token<string>(TokenType.DoubleQuotes, "\""),
                            new Token<string>(TokenType.ClosingCurlyBracket, "}"),
                            new Token<string>(TokenType.ClosingSquareBracket, "]"),
                            new Token<string>(TokenType.ClosingCurlyBracket, "}"),
                            new Token<string>(TokenType.ClosingCurlyBracket, "}"),
                            new Token<string>(TokenType.ClosingCurlyBracket, "}")
                        };
                    }

                    public static object[] Data => new object[]
                    {
                        new object[] {TestCase1.Json, TestCase1.Tokens},
                        new object[] {TestCase2.Json, TestCase2.Tokens}
                    };
                }

                public class ExceptionOnInvalidInput
                {
                    private static class TestCase1
                    {
                        public const string Json = "{{{10,test,[1,2,$3]:)(";
                    }

                    private static class TestCase2
                    {
                        public const string Json = "{{{10,test,[1,2,3]:)(#";
                    }

                    private static class TestCase3
                    {
                        public const string Json = "{{{10,t+est,[1,2,$3]:)(";
                    }

                    public static object[] Data => new object[]
                    {
                        new object[] {TestCase1.Json},
                        new object[] {TestCase2.Json},
                        new object[] {TestCase3.Json}
                    };
                }
            }
        }
    }
}
