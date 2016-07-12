using Core.Nodes;
using Core.Parsing;
using NUnit.Framework;

namespace Tests.CoreTests
{
    internal class ParserTests
    {
        [Category("Playground")]
        [TestCaseSource(typeof(TestsData.Core.Parser.TreeCreationWithoutComments), "Data")]
        public void Parser_can_creats_ast_from_json_without_comments(string input, Node expectedTree)
        {
            var parser = new Parser(input);
            Node tree = parser.Parse();

            Assert.That(tree, Is.EqualTo(expectedTree));
        }

        [Category("Playground")]
        [TestCaseSource(typeof(TestsData.Core.Parser.TreeCreationWithComments), "Data")]
        public void Parser_can_creats_ast_from_json_with_comments(string input, Node expectedTree)
        {
            var parser = new Parser(input);
            Node tree = parser.Parse();

            Assert.That(tree, Is.EqualTo(expectedTree));
        }
    }
}
