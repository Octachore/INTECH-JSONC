using Core.Nodes;
using Core.Visitors;
using NUnit.Framework;

namespace Tests.CoreTests
{
    internal class VisitorTests
    {
        [TestCaseSource(typeof(TestsData.Core.Visitor.JsonVisitor), "Data")]
        public void JsonVisitor(ObjectNode tree, string expectedResult)
        {
            var visitor = new JsonVisitor();

            string result = visitor.Visit(tree);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}