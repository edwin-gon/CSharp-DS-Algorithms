using System;
using structures.linkedLists;

namespace structures.stack
{
    public class Stack<T> where T : IEquatable<T>
    {
        private Node<T> _Top;

        public void Push(T value)
        {
            var newTop = new Node<T>(value, null);
            if (_Top == null)
            {
                _Top = newTop;
                return;
            }
            newTop.NextNode = _Top;
            _Top = newTop;
        }
        public void Pop()
        {
            if (_Top != null)
            {
                _Top = _Top.NextNode;
            }
        }
        public T Peek()
        {
            if (_Top == null) return default(T);
            return _Top.Value;
        }
        public bool IsEmpty()
        {
            return _Top == null;
        }
    }
}
