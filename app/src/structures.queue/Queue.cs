using System;
using structures.linkedLists;

namespace structures.queue
{
    public class Queue<T> where T : IEquatable<T>
    {
        private Node<T> _Top;
        private Node<T> _Bottom;

        public Queue()
        {
            _Top = null;
            _Bottom = null;
        }

        //Enqueue — inserts at the end of queue
        public void Enqueue(T value)
        {
            var entry = new Node<T>(value, null);
            if (_Bottom == null)
            {
                _Bottom = entry;
                _Top = entry;
                return;
            }
            entry.NextNode = _Bottom;
            _Bottom = entry;
        }

        //Dequeue — remove elment from start of the queue
        public void Dequeue()
        {
            if (_Bottom != null)
            {
                if (_Bottom.NextNode == null)
                {
                    _Bottom = null;
                    _Top = null;
                    return;
                }

                _Bottom = _Bottom.NextNode;
            }
        }
        //GetFront — returns first element
        public T GetFront()
        {
            if (_Top == null)
            {
                return default(T);
            }

            return _Top.Value;
        }

        public bool IsEmpty()
        {
            return _Top == null;
        }
    }
}