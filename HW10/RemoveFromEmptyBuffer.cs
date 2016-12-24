using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    class RemoveFromEmptyBuffer : Exception
    {
        public void EmptyBufferException()
        {
            Console.WriteLine("Exception occured: Attempt to remove from empty buffer");
        }

        public void EmptyBufferException(string message)
        {
            Console.WriteLine("Exception occured: Attempt to remove from empty buffer");
        }
    }
}
