using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject
{
    /// <summary>
    /// The IStackADT represents the Stack ADT,
    /// Items are pushed to the top of the stack
    /// and popped from the top of the stack
    /// This creates the last in first out priority (LIFO).
    /// The newest item added is found at the top of the stack
    /// and therefore the newest item is removed first
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStackADT<T>
    {
        /// <summary>
        /// Push the item to the top of the stack
        /// </summary>
        /// <param name="item"></param>
        void Push(T item);

        /// <summary>
        /// Remove the item from the top of the stack
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// Look at the item at the top of the stack but do not remove
        /// </summary>
        /// <returns></returns>
        T Peek();

        /// <summary>
        /// Count the items on the stack
        /// </summary>
        int Size { get; }
    }
}
