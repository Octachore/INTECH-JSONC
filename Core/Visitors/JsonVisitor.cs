using System.Linq;
using Core.Nodes;

namespace Core.Visitors
{
    internal class JsonVisitor : IVisitor<string>
    {
        public string Visit(ListNode listNode)
        {
            return $"[ {string.Join(" ,", listNode.Values.Select(v => v.Accept(this)))} ]";
        }

        public string Visit(AssignmentNode assignmentNode)
        {
            return $"{assignmentNode.Assignee} = {assignmentNode.Value.Accept(this)}";
        }

        public string Visit(ObjectNode objectNode)
        {
            return $"{{ {string.Join(" ,", objectNode.Properties.Select(p => p.Accept(this)))} }}";
        }

        public string Visit<TValue>(ValueNode<TValue> valueNode)
        {
            return valueNode.Value.ToString();
        }
    }
}
