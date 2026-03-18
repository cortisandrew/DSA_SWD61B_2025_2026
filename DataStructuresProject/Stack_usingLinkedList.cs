using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject
{
    public class Stack_usingLinkedList<T> : IStackADT<T>
    {
        private readonly SinglyLinkedList<T> _singlyLinkedList = new SinglyLinkedList<T>();

        public int Size {
            get { return _singlyLinkedList.Size; }
        }

        public T Peek()
        {
            if (_singlyLinkedList.Head == null) // Size == 0
            {
                // there is no element to peek at!
                throw new InvalidOperationException("You cannot peek inside a stack with no elements");
            }

            return _singlyLinkedList.Head.Element;
        }

        public T Pop()
        {
            return _singlyLinkedList.RemoveFirst();
        }

        public void Push(T item)
        {
            _singlyLinkedList.AddFirst(item);
        }
    }
}
