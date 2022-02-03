namespace DataStructures.LinkedList
{
    public class LinkedList<T>
    {
        private LinkedListNode<T> _Head;
        private LinkedListNode<T> _Tail;
        private int _Count;

        public LinkedListNode<T> Head
        {
            get { return _Head; }
        }
        public LinkedListNode<T> Tail
        {
            get { return _Tail; }
        }
        public int Count
        {
            get { return _Count; }
        }


        public void Add(T value)
        {
            var pendingNode = new LinkedListNode<T>(value, null);
            /* Conditions:
            1) When no nodes exist in the structure.
            2) Appending a node, when nodes exist - append to the _Tail and update to point to new _Tail
            */
            if (_Head == null)
            {
                _Head = pendingNode;
                _Tail = _Head;
                _Count++;
                return;
            }

            var currentNode = _Head;
            while (true)
            {
                if (currentNode.NextNode == null) // equivalent to saying currentNode == _Tail
                {
                    currentNode.NextNode = pendingNode;
                    _Tail = pendingNode;
                    _Count++;
                    return;
                }
                currentNode = currentNode.NextNode;
            }
        }

        public LinkedListNode<T> Find(T Value)
        {
            // Could you simply inspect _Head and _Tail first and then inspect the rest?
            var currentNode = _Head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(Value))
                {
                    return currentNode;
                }
                currentNode = currentNode.NextNode;
            }

            return currentNode;
        }

        // TODO: Enable removal of duplicates
        public void Remove(T Value)
        {
            if (_Head.Equals(Value))
            {
                _Head = _Head.NextNode;
                _Count--;
                return;
            }

            var currentNode = _Head;
            while (currentNode.NextNode != null)
            {
                if (currentNode.NextNode.Value.Equals(Value))
                {
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                    _Count--;
                    if (currentNode.NextNode == null)
                    {
                        _Tail = currentNode;
                        return;
                    }
                }
                currentNode = currentNode.NextNode;


            }
        }

        public class LinkedListNode<T>
        {
            public LinkedListNode(T value, LinkedListNode<T> nextNode)
            {
                Value = value;
                NextNode = nextNode;
            }
            public T Value { get; set; }
            public LinkedListNode<T> NextNode { get; set; }
        }
    }
}