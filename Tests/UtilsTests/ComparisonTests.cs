using System.Collections;
using NUnit.Framework;

namespace Tests.UtilsTests
{
    internal class ComparisonTests
    {
        [Test]
        [TestCaseSource(typeof(TestsData.Utils.Comparison.ListsEquivalence), "Data")]
        public void Can_tell_if_two_lists_are_equivalent(IList list1, IList list2, bool areEquivalent)
        {

        }
    }
}
