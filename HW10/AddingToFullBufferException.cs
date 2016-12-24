using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    class AddingToFullBufferException : Exception
    {
        public void FullBufferException()
        {
            Console.WriteLine("Exception occured: Attempt to write to a full buffer");
        }

        public void FullBufferException(string message) 
        {
            Console.WriteLine("Exception occured: Attempt to write to a full buffer");

        }
    }
}
