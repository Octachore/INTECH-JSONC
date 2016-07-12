using System.Collections.Generic;
using Core.Visitors;
using Utils;

namespace Core.Nodes
{
    internal class ListNode : Node
    {
        public ListNode()
        {
            Values = new List<Node>();
        }

        public IList<Node> Values { get; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var node = obj as ListNode;
            return Values.IsEquivalentTo(node?.Values) && Comments.IsEquivalentTo(node?.Comments);
        }

        public override int GetHashCode()
        {
            return Values.GetHashCode() + 11 * Comments.GetHashCode();
        }
    }
}