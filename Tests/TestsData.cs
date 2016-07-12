using System.Collections.Generic;
using Core.Lexicon;
using Core.Nodes;

namespace Tests
{
    internal class TestsData
    {
        public class Core
        {
            public class Lexer
            {
                public class ExceptionOnInvalidInput
                {
                    public static object[] Data => new object[]
                    {
                        new object[] {TestCase1.Json},
                        new object[] {TestCase2.Json},
                        new object[] {TestCase3.Json}
                    };

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
                }

                public class TokenProduction
                {
                    public static object[] Data => new object[]
                    {
                        new object[] {TestCase1.Json, TestCase1.Tokens},
                        new object[] {TestCase2.Json, TestCase2.Tokens},
                        new object[] {TestCase3.Json, TestCase3.Tokens}
                    };

                    private static class TestCase1
                    {
                        public const string Json = "{{{10,test,[1,2,3]:)(=";
                        public static readonly IReadOnlyList<Token> Tokens = new List<Token>
                        {
                            new Token(TokenType.OpeningCurlyBracket, "{"),
                            new Token(TokenType.OpeningCurlyBracket, "{"),
                            new Token(TokenType.OpeningCurlyBracket, "{"),
                            new Token(TokenType.Number, 10),
                            new Token(TokenType.Coma, ","),
                            new Token(TokenType.Word, "test"),
                            new Token(TokenType.Coma, ","),
                            new Token(TokenType.OpeningSquareBracket, "["),
                            new Token(TokenType.Number, 1),
                            new Token(TokenType.Coma, ","),
                            new Token(TokenType.Number, 2),
                            new Token(TokenType.Coma, ","),
                            new Token(TokenType.Number, 3),
                            new Token(TokenType.ClosingSquareBracket, "]"),
                            new Token(TokenType.Colon, ":"),
                            new Token(TokenType.ClosingParenthesis, ")"),
                            new Token(TokenType.OpeningParenthesis, "("),
                            new Token(TokenType.Equals, "=")
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

                        public static readonly IReadOnlyList<Token> Tokens = new List<Token>
                        {
                            new Token(TokenType.OpeningCurlyBracket, "{"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "menu"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Colon, ":"),
                            new Token(TokenType.OpeningCurlyBracket, "{"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "id"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Colon, ":"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "abcde"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Coma, ","),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "value"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Colon, ":"),
                            new Token(TokenType.Number, 10),
                            new Token(TokenType.Coma, ","),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "attributes"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Colon, ":"),
                            new Token(TokenType.OpeningCurlyBracket, "{"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "events"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Colon, ":"),
                            new Token(TokenType.OpeningSquareBracket, "["),
                            new Token(TokenType.OpeningCurlyBracket, "{"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "value"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Colon, ":"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "New"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Coma, ","),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "onclick"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Colon, ":"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "CreateNewDoc"),
                            new Token(TokenType.OpeningParenthesis, "("),
                            new Token(TokenType.ClosingParenthesis, ")"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.ClosingCurlyBracket, "}"),
                            new Token(TokenType.Coma, ","),
                            new Token(TokenType.OpeningCurlyBracket, "{"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "value"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Colon, ":"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "Open"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Coma, ","),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "onclick"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Colon, ":"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.Word, "OpenDoc"),
                            new Token(TokenType.OpeningParenthesis, "("),
                            new Token(TokenType.ClosingParenthesis, ")"),
                            new Token(TokenType.DoubleQuotes, "\""),
                            new Token(TokenType.ClosingCurlyBracket, "}"),
                            new Token(TokenType.ClosingSquareBracket, "]"),
                            new Token(TokenType.ClosingCurlyBracket, "}"),
                            new Token(TokenType.ClosingCurlyBracket, "}"),
                            new Token(TokenType.ClosingCurlyBracket, "}")
                        };
                    }

                    private static class TestCase3
                    {
                        public const string Json = @"test //hello world!
                                                     {
                                                        /* This block is empty.
                                                            Really.
                                                          Except for that comment.*/
                                                     }";

                        public static readonly IReadOnlyList<Token> Tokens = new List<Token>
                        {
                            new Token(TokenType.Word, "test"),
                            new Token(TokenType.OneLineComment, "hello world!"),
                            new Token(TokenType.OpeningCurlyBracket, "{"),
                            new Token(TokenType.MultilineComment, @" This block is empty.
                                                            Really.
                                                          Except for that comment."),
                            new Token(TokenType.ClosingCurlyBracket, "}")
                        };
                    }
                }
            }

            public class Parser
            {
                public class TreeCreationWithoutComments
                {
                    public static object[] Data => new object[]
                    {
                        new object[] {TestCase1.Json, TestCase1.Tree},
                        new object[] {TestCase2.Json, TestCase2.Tree},
                        new object[] {TestCase3.Json, TestCase3.Tree},
                        new object[] {TestCase4.Json, TestCase4.Tree}
                    };

                    private static class TestCase1
                    {
                        public const string Json = "";

                        public static Node Tree = null;
                    }

                    private static class TestCase2
                    {
                        public const string Json = "{ }";

                        public static Node Tree = new ObjectNode();
                    }

                    private static class TestCase3
                    {
                        public const string Json = @"{ a = 1 }";

                        public static Node Tree = new ObjectNode(new AssignmentNode("a", new ValueNode<int>(1)));
                    }

                    private static class TestCase4
                    {
                        public const string Json = @"{
                                                        a = 1,
                                                        b = [1, 2, 3],
                                                        c = {
                                                                d = 1,
                                                                e = ""Hello World""
                                                            }
                                                     }";

                        public static Node Tree
                        {
                            get
                            {

                                var propertyA = new AssignmentNode("a", new ValueNode<int>(1));

                                var listB = new ListNode();
                                listB.Values.Add(new ValueNode<int>(1));
                                listB.Values.Add(new ValueNode<int>(2));
                                listB.Values.Add(new ValueNode<int>(3));

                                var propertyB = new AssignmentNode("b", listB);

                                var propertyD = new AssignmentNode("d", new ValueNode<int>(1));
                                var propertyE = new AssignmentNode("e", new ValueNode<string>("Hello World"));

                                var objectC = new ObjectNode(propertyD, propertyE);

                                var propertyC = new AssignmentNode("c", objectC);


                                var root = new ObjectNode(propertyA, propertyB, propertyC);
                                return root;
                            }
                        }
                    }
                }

                public class TreeCreationWithComments
                {
                    public static object[] Data => new object[]
                    {
                        new object[] {1, TestCase1.Json, TestCase1.Tree},
                        new object[] {2, TestCase2.Json, TestCase2.Tree},
                        new object[] {3, TestCase3.Json, TestCase3.Tree},
                        new object[] {10000, TestCase10000.Json, TestCase10000.Tree}
                    };

                    private static class TestCase1
                    {
                        public const string Json = @"{ /* Comment */ a = 1 }";

                        public static Node Tree
                        {
                            get
                            {

                                var propertyA = new AssignmentNode("a", new ValueNode<int>(1));
                                propertyA.Comments.Add(" Comment ");

                                var root = new ObjectNode(propertyA);
                                return root;
                            }
                        }
                    }

                    private static class TestCase2
                    {
                        public const string Json = @"{
                                                            // Comment
                                                            a = 1
                                                     }";

                        public static Node Tree
                        {
                            get
                            {

                                var propertyA = new AssignmentNode("a", new ValueNode<int>(1));
                                propertyA.Comments.Add(" Comment");

                                var root = new ObjectNode(propertyA);
                                return root;
                            }
                        }
                    }

                    private static class TestCase3
                    {
                        public const string Json = @"{
                                                            a = 1 // Comment
                                                     }";

                        public static Node Tree
                        {
                            get
                            {

                                var propertyA = new AssignmentNode("a", new ValueNode<int>(1));

                                var root = new ObjectNode(propertyA);
                                root.Comments.Add(" Comment");
                                return root;
                            }
                        }
                    }

                    private static class TestCase10000
                    {
                        public const string Json = @"{
                                                        //Comment 1
                                                        a = 1,
                                                        b = [1, 2, 3], //Comment 2
                                                        c = {
                                                                /* Comment 3 on
                                                                    several lines */
                                                                d = 1,
                                                                e = ""Hello World""
                                                                // Comment 4
                                                            }
                                                     }";

                        public static Node Tree
                        {
                            get
                            {

                                var propertyA = new AssignmentNode("a", new ValueNode<int>(1));
                                propertyA.Comments.Add("Comment 1");

                                var listB = new ListNode();
                                listB.Values.Add(new ValueNode<int>(1));
                                listB.Values.Add(new ValueNode<int>(2));
                                listB.Values.Add(new ValueNode<int>(3));

                                var propertyB = new AssignmentNode("b", listB);

                                var propertyD = new AssignmentNode("d", new ValueNode<int>(1));
                                propertyD.Comments.Add(@" Comment 3 on
                                                                    several lines ");

                                var propertyE = new AssignmentNode("e", new ValueNode<string>("Hello World"));

                                var objectC = new ObjectNode(propertyD, propertyE);
                                objectC.Comments.Add("Comment 4");

                                var propertyC = new AssignmentNode("c", objectC);
                                propertyC.Comments.Add("Comment 2");

                                var root = new ObjectNode(propertyA, propertyB, propertyC);
                                return root;
                            }
                        }
                    }
                }
            }

            public class Visitor
            {
                public class JsonVisitor
                {
                    public static object[] Data => new object[]
                    {
                        new object[] {TestCase1.Tree, TestCase1.ExpectedResult}
                    };

                    private static class TestCase1
                    {
                        public static Node Tree
                        {
                            get
                            {
                                var propertyA = new AssignmentNode("a", new ValueNode<int>(1));
                                propertyA.Comments.Add("Comment 1");

                                var listB = new ListNode();
                                listB.Values.Add(new ValueNode<int>(1));
                                listB.Values.Add(new ValueNode<int>(2));
                                listB.Values.Add(new ValueNode<int>(3));

                                var propertyB = new AssignmentNode("b", listB);

                                var propertyD = new AssignmentNode("d", new ValueNode<int>(1));
                                propertyD.Comments.Add(@" Comment 3 on
                                                                    several lines ");

                                var propertyE = new AssignmentNode("e", new ValueNode<string>("Hello World"));

                                var objectC = new ObjectNode(propertyD, propertyE);
                                objectC.Comments.Add("Comment 4");

                                var propertyC = new AssignmentNode("c", objectC);
                                propertyC.Comments.Add("Comment 2");

                                var root = new ObjectNode(propertyA, propertyB, propertyC);
                                return root;
                            }
                        }

                        public const string ExpectedResult = "{ a = 1 ,b = [ 1 ,2 ,3 ] ,c = { d = 1 ,e = Hello World } }";
                    }
                }
            }
        }

        public class Utils
        {
            public class Comparison
            {
                public class ListsEquivalence
                {
                    public static object[] Data => new object[]
                    {
                        new object[] {TestCase1.List1, TestCase1.List2, TestCase1.AreEquivalent},
                        new object[] {TestCase2.List1, TestCase2.List2, TestCase2.AreEquivalent},
                        new object[] {TestCase3.List1, TestCase3.List2, TestCase3.AreEquivalent},
                        new object[] {TestCase4.List1, TestCase4.List2, TestCase4.AreEquivalent},
                        new object[] {TestCase5.List1, TestCase5.List2, TestCase5.AreEquivalent},
                        new object[] {TestCase6.List1, TestCase6.List2, TestCase6.AreEquivalent}
                    };

                    private static class TestCase1
                    {
                        public static IList<int> List1 = new List<int> { 1, 2, 3, 4, 5 };
                        public static IList<int> List2 = new List<int> { 1, 2, 3, 4, 5 };
                        public static bool AreEquivalent = true;
                    }

                    private static class TestCase2
                    {
                        public static IList<int> List1 = new List<int> { 1, 2, 3, 4, 5 };
                        public static IList<int> List2 = new List<int> { 1, 2, 3, 4, 6 };
                        public static bool AreEquivalent = false;
                    }

                    private static class TestCase3
                    {
                        public static IList<int> List1 = new List<int> { 1, 2, 3, 4, 5 };
                        public static IList<int> List2 = new List<int> { 1, 2, 3, 4, 5, 6 };
                        public static bool AreEquivalent = false;
                    }

                    private static class TestCase4
                    {
                        public static IList<string> List1 = new List<string> { "a", "b", "c", "d", "e" };
                        public static IList<string> List2 = new List<string> { "a", "b", "c", "d", "e" };
                        public static bool AreEquivalent = true;
                    }

                    private static class TestCase5
                    {
                        public static IList<string> List1 = new List<string> { "a", "b", "c", "d", "e" };
                        public static IList<string> List2 = new List<string> { "a", "b", "c", "d", "f" };
                        public static bool AreEquivalent = false;
                    }

                    private static class TestCase6
                    {
                        public static IList<string> List1 = new List<string> { "a", "b", "c", "d", "e" };
                        public static IList<string> List2 = new List<string> { "a", "b", "c", "d", "e", "f" };
                        public static bool AreEquivalent = false;
                    }
                }
            }
        }
    }
}
