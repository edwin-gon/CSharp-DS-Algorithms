using System;

namespace structures.linkedLists
{
    public class Node<T> where T : IEquatable<T>
    {
        public Node(T value, Node<T> nextNode)
        {
            Value = value;
            NextNode = nextNode;
        }
        public T Value { get; set; }
        public Node<T> NextNode { get; set; }
    }
}
