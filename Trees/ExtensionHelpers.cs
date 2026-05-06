using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    /// <summary>
    /// The class MUST be static to allow the creation of extension methods
    /// </summary>
    public static class ExtensionHelpers
    {
        /// <summary>
        /// Methods in static classes must be static
        /// The this keyword in the parameters is used to "attach" the method to the type of this parameter
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void Swap<T>(this List<T> myList, int i, int j)
        {
            // perform a swap at positions i and j in the list
            T temp = myList[i];
            myList[i] = myList[j];
            myList[j] = temp;
        }
    }
}
