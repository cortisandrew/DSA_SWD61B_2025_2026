using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject
{
    public class SinglyLinkedList<T>
    {
        private int _size = 0;
        /// <summary>
        /// Number of elements stored
        /// </summary>
        public int Size
        {
            get
            {
                return _size;
            }
            private set
            {
                _size = value;
            }
        }

        /// <summary>
        /// A link to the Head of list (i.e. the first node in the list)
        /// </summary>
        protected Node<T>? head = default;

        /// <summary>
        /// Add the new elem at the head of list
        /// </summary>
        /// <param name="elem"></param>
        public void AddFirst(T elem)
        {
            // Recommendation: First implement the constructive steps
            // This avoids problems with losing data

            // Step (i): Create a new node, storing the element
            Node<T> newNode = new Node<T>(elem);

            // Step (ii): Update the new node so that it points towards
            // the "old" head of list
            // this means that now every other node is after the newNode
            newNode.Next = head;

            // Step (iii): Destructive step
            // Replace the head of list with the new Node
            head = newNode;

            // Step (iv):
            Size++;
        }

        /// <summary>
        /// Remove an element from the head of list (and return its value)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// TODO: See this work in class
        /// TODO! What happens when we only have 1 node in the list? (Size == 1)
        /// </remarks>
        public T RemoveFirst()
        {
            // Step 0: Validation! We can't remove from an empty linked list
            if (head == null)
            // if (Size == 0) // this is equivalent
            {
                // we have no element to remove!
                throw new InvalidOperationException("You cannot remove an element from an empty linked list!");
            }

            // Step 1:
            // Remember the return value
            T returnValue = head.Element;

            // Step 2:
            // Update the head: move it to the Next element in the linked list
            // A bit like "moving forward" one step
            head = head.Next;

            // Step 3:
            Size--;

            // Step 4:
            return returnValue;
        }

    }
}
