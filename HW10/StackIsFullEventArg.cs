using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    public class StackIsFullEventArgs : EventArgs
    {
        public int Index { get; set; }
        public string Value { get; set; }
        public StackIsFullEventArgs(int InSize, object InValue)
        {
            Index = InSize;
            Value = InValue.ToString();
        }
    }
}
