namespace DataStructuresProject
{
    public class Node<T>
    {
        private T _element;

        public T Element { get { return _element; } }

        internal Node<T>? Next = default;

        public Node(T element, Node<T>? Next = null)
        {
            _element = element;
            this.Next = Next;
        }
    }
}