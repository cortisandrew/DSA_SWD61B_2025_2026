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

        internal Node<T>? Head
        {
            get { return head; }
            set { head = value; }
        }

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


        public Node<T>? Next(Node<T>? cursor)
        {
            // Check for null inputs!
            // A null cannot have a Next
            if (cursor == null)
            {
                throw new InvalidOperationException("A null cursor has no next!");
            }

            // Move one step forward
            cursor = cursor.Next;

            return cursor;
        }

        public Node<T>? Previous(Node<T>? cursor)
        {
            // cursor = cursor.Previous;

            if (cursor == null)
            {
                throw new InvalidOperationException("A null cursor does not have a previous!");
            }

            Node<T>? currentNode = Head; // start from the very first node in the linked list

            // until we are able to continue searching...
            while (currentNode != null)
            {
                // check if the current node is the correct node
                if(currentNode.Next == cursor)
                {
                    // the currentNode is the previous to the cursor!
                    return currentNode;
                }

                // else... we did not find the node we need... try the next one
                currentNode = currentNode.Next; // move one step forward
            }

            // the previous was not found
            // this means that the cursor is not a member of the linked list!
            throw new InvalidOperationException("The cursor does not belong to this linked list!");
        }

        public void InsertAfter(Node<T> cursor, T element)
        {
            if (cursor == null)
            {
                throw new InvalidOperationException(
                    "You cannot insert after a null!");
            }

            // Step (i): Create a new instance of type Node
            // to store the new element
            Node<T> newNode = new Node<T>(element);

            // Step (ii): Update the next of the newNode
            newNode.Next = cursor.Next;

            // Step (iii): Update the next of the cursor
            cursor.Next = newNode;

            // Step (iv): increment size
            Size++;
        }

        public T RemoveAfter(Node<T> cursor)
        {
            // Cursor is null (i.e. there is no cursor)
            if (cursor == null)
            {
                throw new InvalidOperationException(
                    "You cannot remove after a null!");
            }

            // Cursor is the last node in the linked list
            if (cursor.Next == null)
            {
                throw new InvalidOperationException(
                    "There is no element to remove after the cursor!");
            }

            // Step (i)
            T returnValue = 
                cursor.Next.Element;


            Node<T> cursorNext = cursor.Next;


            throw new NotImplementedException();
        }

        public void InsertBefore(Node<T> cursor, T element)
        {
            throw new NotImplementedException();
        }

        public T RemoveBefore(Node<T> cursor)
        {
            throw new NotImplementedException();
        }
    }
}
