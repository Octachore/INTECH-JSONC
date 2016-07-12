using System.Collections.Generic;
using Core.Visitors;

namespace Core.Nodes
{
    internal abstract class Node
    {
        public List<string> Comments { get; set; } = new List<string>();

        public abstract T Accept<T>(IVisitor<T> visitor);

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }
}