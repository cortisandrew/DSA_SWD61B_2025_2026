using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees;

/// <summary>
/// A Node (or Vetex) for a Binary Search Tree.
/// </summary>
/// <typeparam name="T"></typeparam>
internal class Node<T>
{
    #region Properties to store the data in the node
    internal int Key { get; private set; }

    internal T Value { get; private set; }
    #endregion

    #region Properties to store the reference to the left and right child
    internal Node<T>? Left { get; private set; }

    internal Node<T>? Right { get; private set; }
    #endregion

    internal Node(int key, T value)
    {
        Key = key;
        Value = value;
    }

    internal void Insert(int key, T value)
    {
        // this node is already "occupied".
        // this node already has a key

        // Compare the key (parameter) against the Key (property of this node)
        if (key <= Key)
        {
            // the new node should be inserted in the left subtree of this node
            if (Left != null) // left sub-tree exists
            {
                // pass the call to the Left child
                Left.Insert(key, value);
            }
            else // there is an empty space
            {
                Left = new Node<T>(key, value);
            }
        }
        else
        {
            // the new key is larger than the key of this node,
            // so the new node should be inserted in the right subtree of this node
            if (Right != null) // right sub-tree exists
            {
                // pass the call to
                Right.Insert(key, value);
            }
            else
            {
                Right = new Node<T>(key, value);
            }
        }
    }

    internal T Search(int key)
    {
        if (key == Key)
        {
            // we have found the key, so we return the value of this node
            return Value;
        }
        else if (key < Key)
        {
            // the key we are looking for is smaller than the key of this node, so we need to search in the left subtree
            if (Left != null) // left sub-tree exists
            {
                return Left.Search(key);
            }
            else
            {
                // there is no left sub-tree, so the key cannot be found
                throw new KeyNotFoundException($"The key {key} was not found in the BST.");
            }
        }
        else
        { // the key we are looking for is larger than the key of this node, so we need to search in the right subtree
            if (Right != null) // right sub-tree exists
            {
                return Right.Search(key);
            }
            else
            {
                // there is no right sub-tree, so the key cannot be found
                throw new KeyNotFoundException($"The key {key} was not found in the BST.");
            }
        }
    }

    override public string ToString()
    {
        // get the keysAlreadyAdded....

        StringBuilder sb = new StringBuilder();

        if (Left != null)
        {
            sb.AppendLine($"{Key} -> {Left.Key};");
            // while Left.Key is already added,
            // change the name by appending a number
            sb.Append(Left.ToString());
        }
        
        if (Right != null)
        {
            sb.AppendLine($"{Key} -> {Right.Key};");
            sb.Append(Right.ToString());
        }

        return sb.ToString();
    }
}
