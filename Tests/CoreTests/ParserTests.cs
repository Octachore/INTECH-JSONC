using Core.Nodes;
using Core.Parsing;
using NUnit.Framework;

namespace Tests.CoreTests
{
    internal class ParserTests
    {
        [Category("Playground")]
        [TestCaseSource(typeof(TestsData.Core.Parser.TreeCreationWithoutComments), "Data")]
        public void AST_from_json(string input, Node expectedTree)
        {
            var parser = new Parser(input);
            Node tree = parser.Parse();

            Assert.That(tree, Is.EqualTo(expectedTree));
        }

        [Category("Playground")]
        [TestCaseSource(typeof(TestsData.Core.Parser.TreeCreationWithComments), "Data")]
        public void AST_from_jsonc(int testCaseid, string input, Node expectedTree)
        {
            var parser = new Parser(input);
            Node tree = parser.Parse();

            Assert.That(tree, Is.EqualTo(expectedTree));
        }
    }
}