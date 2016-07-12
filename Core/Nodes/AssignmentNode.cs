using Core.Visitors;
using Utils;

namespace Core.Nodes
{
    internal class AssignmentNode : Node
    {
        public string Assignee { get; set; }

        public Node Value { get; set; }

        public AssignmentNode(string assignee, Node value)
        {
            Assignee = assignee;
            Value = value;
        }

        public AssignmentNode()
        {
        }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var node = obj as AssignmentNode;
            return Assignee.Equals(node?.Assignee) && Value.Equals(node?.Value) && Comments.IsEquivalentTo(node?.Comments);
        }

        public override int GetHashCode()
        {
            return Assignee.GetHashCode() + 11 * Value.GetHashCode() + 13 * Comments.GetHashCode();
        }
    }
}
