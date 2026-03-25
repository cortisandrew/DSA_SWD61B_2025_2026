using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject
{
    public class Queue_usingLinkedList<T> : IQueueADT<T>
    {
        private readonly SinglyLinkedList<T> singlyLinkedList = new SinglyLinkedList<T>();

        public int Size
        {
            get
            {
                return singlyLinkedList.Size;
            }
        }

        public T Dequeue()
        {
            return singlyLinkedList.RemoveFirst();
        }

        public void Enqueue(T item)
        {
            singlyLinkedList.AddLast(item);

            
        }

        public T Peek()
        {
            if (singlyLinkedList.Size == 0)
            {
                throw new InvalidOperationException("You cannot peek in an empty Queue!");
            }

            return singlyLinkedList.Head!.Element;
        }
    }
}
