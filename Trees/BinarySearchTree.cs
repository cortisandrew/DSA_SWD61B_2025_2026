using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BinarySearchTree<T>
    {
        private Node<T>? root;

        /// <summary>
        /// Insert a new Node into the BST (preserving the order-property)
        /// We will use a recursive implementation
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Insert(int key, T value)
        {
            // if there is not even the root
            if (root == null)
            {
                // we need the first node to store data and we place it at the root
                root = new Node<T>(key, value);
            }
            else
            {
                // the root already exists,
                // we ask the root to insert the new node
                root.Insert(key, value);
            }
        }

        /// <summary>
        /// If the key is not found, an exception should be thrown.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T Search(int key)
        {
            if (root == null)
            {
                // this means that the BST is empty, so the key cannot be found
                throw new KeyNotFoundException($"The key {key} was not found in the BST.");
            }
            else
            {
                // we ask the root to search for the key
                return root.Search(key);
            }
        }

        /// <summary>
        /// Create a description of the BST using the dot language
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Works but has a bug if the key is duplicate!
        /// </remarks>
        public override string ToString()
        {
            // HashSet<int> keysAlreadyAdded = new HashSet<int>();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("digraph BST {");

            if (root != null)
            {
                sb.AppendLine($"{root.Key};");
                sb.AppendLine(root.ToString());
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
