using Core.Visitors;
using Utils;

namespace Core.Nodes
{
    internal class ValueNode<TValue> : Node
    {
        public ValueNode(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; private set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var node = obj as ValueNode<TValue>;
            if (node == null) return false;
            return Value.Equals(node.Value) && Comments.IsEquivalentTo(node?.Comments);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() + 11 * Comments.GetHashCode();
        }
    }
}
