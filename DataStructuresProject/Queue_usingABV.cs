using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject
{
    public class Queue_usingABV<T> : IQueueADT<T>
    {
        private readonly IVectorADT<T> _vector = new ArrayBasedVector<T>();

        public int Size
        {
            get
            {
                return _vector.Size;
            }
        }

        public T Dequeue()
        {
            /* Attempt 1 */
            // Remove the element at rank 0 (front of queue)
            // Slow! I need to shift each other element on the queue!
            return _vector.RemoveElementAtRank(0);
            
            /* Attempt 2
            // Fast
            return _vector.RemoveElementAtRank(Size - 1);
            */
        }

        public void Enqueue(T item)
        {
            /* Attempt 1 */
            // Fast!
            // The back of the queue is at position Size - 1
            // The front of the queue is at position 0
            _vector.Append(item);
            
            /*
            // Slow
            // The back of the queue is at position 0
            _vector.InsertElementAtRank(0, item);
            */
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }
    }
}
