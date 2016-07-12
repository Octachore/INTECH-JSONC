using System.Collections.Generic;
using Core.Visitors;
using Utils;

namespace Core.Nodes
{
    internal class ObjectNode : Node
    {
        public ObjectNode() : base()
        {
            Properties = new List<AssignmentNode>();
        }

        public ObjectNode(params AssignmentNode[] properties) : this()
        {
            Properties.AddRange(properties);
        }

        public List<AssignmentNode> Properties { get; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var node = obj as ObjectNode;
            return Properties.IsEquivalentTo(node?.Properties) && Comments.IsEquivalentTo(node?.Comments);
        }

        public override int GetHashCode()
        {
            return Properties.GetHashCode() + 11 * Comments.GetHashCode();
        }
    }
}