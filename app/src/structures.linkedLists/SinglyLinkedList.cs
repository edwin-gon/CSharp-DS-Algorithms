using System;
using System.Text;

namespace structures.linkedLists
{
    public class SinglyLinkedList<T> where T : IEquatable<T>
    {
        private Node<T> _Head;
        private Node<T> _Tail;
        public SinglyLinkedList()
        {
            _Head = null;
            _Tail = null;
        }
        public Node<T> GetHead()
        {
            return _Head;
        }
        public Node<T> GetTail()
        {
            return _Tail;
        }
        public void InsertAtHead(T value)
        {
            if (_Head == null)
            {
                _Head = new Node<T>(value, null);
                return;
            }

            var newHead = new Node<T>(value, _Head);
            _Head = newHead;
        }
        public void DeleteAtHead()
        {
            if (_Head == null) return;
            var newHead = _Head.NextNode;
            _Head = newHead;
        }

        public void Add(T value)
        {
            /* Conditions:
            1) When no nodes exist in the structure.
            2) Appending a node, when nodes exist - append to the _Tail and update to point to new _Tail
            */
            if (_Head == null)
            {
                InsertAtHead(value);
                return;
            }

            var pendingNode = new Node<T>(value, null);
            var currentNode = _Head;
            while (true)
            {
                if (currentNode.NextNode == null) // equivalent to saying currentNode == _Tail
                {
                    currentNode.NextNode = pendingNode;
                    return;
                }
                currentNode = currentNode.NextNode;
            }
        }

        public bool Contains(T value)
        {
            var currentNode = _Head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }
                currentNode = currentNode.NextNode;
            }
            return false;
        }

        public void Delete(T value)
        {
            Node<T> previous, current = null;
            current = _Head;
            bool isHeadSet = false;

            if (IsEmpty()) return;
            while (!isHeadSet)
            {
                if (current == null)
                {
                    _Head = current;
                    return;
                }
                else if (!current.Value.Equals(value))
                {
                    isHeadSet = true;
                    _Head = current;
                }
                previous = current;
                current = current.NextNode;

                while (previous != null && current != null && isHeadSet)
                {
                    if (current.Value.Equals(value))
                    {
                        previous.NextNode = current.NextNode;
                    }
                    else
                    {
                        previous = current;
                    }
                    current = current.NextNode;
                }
                if (previous.Value.Equals(value))
                    _Tail = null;
                else
                    _Tail = previous;
            }
        }

        public bool IsEmpty()
        {
            return _Head == null;
        }

        public int Count()
        {
            int count = 0;

            if (IsEmpty()) return count;

            var current = _Head;
            while (current != null)
            {
                current = current.NextNode;
                count++;
            }
            return count;
        }

        public override string ToString()
        {
            if (IsEmpty()) return "";

            StringBuilder sb = new StringBuilder();
            Node<T> current = _Head;
            while (current != null)
            {
                sb.AppendFormat("(Value: {0})", current.Value.ToString());
                current = current.NextNode;
            }
            return sb.ToString();
        }
    }
}