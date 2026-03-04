using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject
{
    /// <summary>
    /// The Queue works in a first in first out order (FIFO)
    /// New items are enqueued to the back of the queue
    /// The item at the front of the queue is dequeued first
    /// Since newest items are placed at the back,
    /// The oldest item at the front is dqueued first
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueueADT<T>
    {
        /// <summary>
        /// Enqueue places a new item at the back of the queue
        /// </summary>
        /// <param name="item"></param>
        void Enqueue(T item);

        /// <summary>
        /// Removes the item at the front of the queue
        /// i.e. the item that has been waiting the longest
        /// </summary>
        /// <returns></returns>
        T Dequeue();

        /// <summary>
        /// Look at the item at the front of the queue
        /// without removing it
        /// </summary>
        /// <returns></returns>
        T Peek();

        int Size { get; }
    }
}
