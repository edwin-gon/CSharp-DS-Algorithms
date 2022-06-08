using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace structures.linkedLists
{
    public class SinglyLinkedList<T> where T : IEquatable<T>
    {
        private Node<T> _Head;

        public Node<T> Head
        {
            get { return _Head; }
        }

        public SinglyLinkedList()
        {
            _Head = null;
        }
        public void Add(T value)
        {
            var pendingNode = new Node<T>(value, null);
            /* Conditions:
            1) When no nodes exist in the structure.
            2) Appending a node, when nodes exist - append to the _Tail and update to point to new _Tail
            */
            if (_Head == null)
            {
                _Head = pendingNode;
                return;
            }

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
            // Could you simply inspect _Head and _Tail first and then inspect the rest?
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
        /* a-b-c-b-d 
        - Remove a => b-c-d | b points to head 
        - Remove c => a-b-b-d | b next points to deleted node next
        - Remove d => a-b-c-b | delete node and do not update next
        - Remove b => a-c-d | update a to c and c to d 
        */
        public void Remove(T value)
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