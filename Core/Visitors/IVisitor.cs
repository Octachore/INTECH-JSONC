using Core.Nodes;

namespace Core.Visitors
{
    internal interface IVisitor<out T>
    {
        T Visit(ObjectNode objectNode);

        T Visit(AssignmentNode assignmentNode);

        T Visit(ListNode listNode);

        T Visit<TValue>(ValueNode<TValue> valueNode);
    }
}
