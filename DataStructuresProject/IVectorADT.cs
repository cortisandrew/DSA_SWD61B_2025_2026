using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject
{
    /// <summary>
    /// An ADT (Abstract Data Type) is an abstraction of some data that I want to use
    /// The abstraction does not describe HOW it is implemented (like an Interface)
    /// But it describes what I expect the interface to do and the behaviour of the interface.
    /// 
    /// In particular, the IVectorADT represents something that stores an ordered sequence of elements
    /// We don't worry HOW it is implemented (actually in a basic interface, there is no implementation)
    /// The interface is a contract that states, whoever implements the interface will provide the
    /// expected behaviour in some way.
    /// </summary>
    /// <typeparam name="T">T represents the type of element stored in the VectorADT</typeparam>
    public interface IVectorADT<T>
    {
        /// <summary>
        /// Returns the number of elements stores in the IVectorADT
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Return the element at a given rank
        /// </summary>
        /// <param name="rank">The number of elements BEFORE the current element</param>
        /// <returns>The element at the given rank</returns>
        T ElementAtRank(int rank);

        /// <summary>
        /// Add a new element to the IVectorADT at a specific rank
        /// </summary>
        /// <param name="rank">The rank of the newly added element</param>
        /// <param name="element">The element to add to the IVectorADT</param>
        void InsertElementAtRank(int rank, T element);

        /// <summary>
        /// Removes the element found at the given rank from the IVectorADT
        /// (Remember that the rank of the elements succeeding the removed element will have to "shift")
        /// </summary>
        /// <param name="rank">The rank of the element to remove</param>
        /// <returns>The removed element</returns>
        T RemoveElementAtRank(int rank);

        /// <summary>
        /// Find the element at a given rank and replace the element with the newElement
        /// </summary>
        /// <param name="rank">The rank to replace</param>
        /// <param name="newElement">The new element to place in the IVectorADT at rank</param>
        /// <returns>The replaced element</returns>
        T ReplaceElementAtRank(int rank, T newElement);

        /// <summary>
        /// Add a new element at the last rank of the IVectorADT
        /// </summary>
        /// <param name="element">The element to append to the IVectorADT</param>
        void Append(T element);

    }
}
