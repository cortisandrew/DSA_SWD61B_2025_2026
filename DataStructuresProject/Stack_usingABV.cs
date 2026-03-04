using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject
{
    public class Stack_usingABV<T> : IStackADT<T>
    {
        private readonly IVectorADT<T> _vector;
        
        public Stack_usingABV(int initialLength = 4)
        {
            _vector = new ArrayBasedVector<T>(initialLength);
        }

        public int Size
        {
            get
            {
                return _vector.Size;
            }
        }

        public T Peek()
        {
            return _vector.ElementAtRank(Size - 1);
        }

        public T Pop()
        {
            // The item at the top of the stack is at position Size - 1
            return _vector.RemoveElementAtRank(Size - 1);
        }

        public void Push(T item)
        {
            // The top of the stack is the last item in the array based vector
            _vector.Append(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = Size - 1; i >= 0; i--)
            {
                sb.Append(" ");
                sb.Append(_vector.ElementAtRank(i));
                sb.AppendLine(" ");
            }

            sb.AppendLine("===");
            return sb.ToString();
        }
    }
}
