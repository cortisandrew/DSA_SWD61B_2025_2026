using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Heap
    {
        // The arraybasedvector below holds the array with the data of the heap
        // It can also provide the count of elements
        List<int> _data = new List<int>();

        public int Count => _data.Count;


        #region Support operations

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }


        #endregion
    }
}
