using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
            private set { head = value; }
        }
        
        /// <summary>
        /// Implicitly (hidden), we also have the "tail" field
        /// </summary>
        internal Node<T>? Tail
        {
            get;
            private set;
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

            // Extra step to handle Tail of list
            if (head == null) // equivalent to Tail == null, and equivalent to Count == 0
            {
                // This means that we are adding a new element to an empty list
                // Therefore the node to be added is BOTH the first and the last node
                Tail = newNode;
            }

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

            // Extra step for removing last node and maintaing tail
            if (head == null) // Size == 0
            {
                // we have just removed the last node!
                // the linked list should be empty... therefore, no tail
                Tail = null;
            }

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

        public Node<T> Previous(Node<T> cursor)
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

            // Check if we need to update the Tail
            if (Tail == cursor)
            {
                // we are inserting a new node AFTER the tail
                Tail = newNode;
            }

            // Step (iii): Update the next of the cursor
            cursor.Next = newNode;

            // Step (iv): increment size
            Size++;
        }

        public T RemoveAfter(Node<T> cursor)
        {
            // Step (0): Validation
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

            // if cursor.Next == Tail, we are removing the last element
            // this means that the node at cursor is now the new last node (i.e. Tail)
            if (cursor.Next == Tail)
            {
                Tail = cursor;
            }


            // Step (ii): "skip" the node to be removed
            cursor.Next = cursor.Next.Next;
            // identical to the above
            // cursor.Next = (cursor.Next).Next;

            // also identical to the above
            /*
            // first get the node after the cursor
            Node<T> nodeToRemove = cursor.Next;
            cursor.Next = nodeToRemove.Next;
            */

            // Step (iii): Update the size (we removed one node!)
            Size--;

            // Step (iv):
            return returnValue;
        }

        public void InsertBefore(Node<T> cursor, T element)
        {
            // Step (0) - validation (cursor is not nullable, so this issue should not happen...  but if it does, we are checking anyway)
            ArgumentNullException.ThrowIfNull(cursor, nameof(cursor));

            // Check which case we need to apply.

            // Case (i): cursor happens to be the first item in the linked list
            // this is equivalent to AddFirst
            if (cursor == Head)
            {
                AddFirst(element);
                return;
            }
            else // case (ii): cursor is NOT the first item in the linked list
            {
                // Insert before is equivalent to Insert After of the previous
                Node<T> prev = Previous(cursor);
                // A null happens in case (i)
                // or we could get an exception if the cursor is NOT in the linked list
                InsertAfter(prev, element);
                return;
            }
        }

        public T RemoveBefore(Node<T> cursor)
        {
            throw new NotImplementedException("Exercise - use reduction like before!");
        }

        public override string ToString()
        {
            // Create a structure to store all the elements (we don't really need this extra structure... but it will make the implementation easier)
            List<string> elements = new List<string>();

            // Step (i) - start from the head of list. Note: this may be null if the linked list is empty
            Node<T>? cursor = Head;

            // check: when cursor == null, this means that we have finished going through the linked list
            // and we can now print out all the elements that I have found
            while (cursor != null)
            {
                // I am guaranteed that the cursor is NOT null
                // BUT the cursor.Element is of type T. T might be nullable. So it is possible that someone
                // create a node with a null element: new Node(null);

                // while the cursor still points to a node, we have found a new element
                elements.Add(
                    cursor.Element?.ToString() ?? "NULL"
                );

                // cursor.Element.ToString() causes and issue if cursor.Element == null: (null).ToString()
                // cursor.Element?.ToString() helps because this translates to:
                // string? result = null;
                // if (cursor.Element != null) {
                //      result = cursor.Element.ToString();
                // }
                // else 
                // {
                //      result = null;
                // }

                // Null coalesce operators
                // ?. - execute method if variable is not null, return null otherwise
                // ?? - if the LHS is null, replace it with the rhs
                // ??= - assign variable to rhs if it is null

                // move one step forward
                
                // cursor.Next; - this is the next position
                cursor = cursor.Next; // update the cursor to the next position (possibly null if we arrived at the end of list)
            }

            return string.Join(" -> ", elements);
        }

        public void AddLast(T item)
        {
            if (Tail == null) // Size == 0)
            {
                AddFirst(item);
            }
            else
            {
                InsertAfter(Tail, item);
            }
        }
    }
}
