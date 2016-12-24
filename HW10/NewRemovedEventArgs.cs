using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    public class NewRemovedEventArgs : EventArgs
    {
        public int Index { get; set; }
        public string Value { get; set; }
        public NewRemovedEventArgs(int InSize, object InValue)
        {
            Index = InSize;
            Value = InValue.ToString();
        }
    }
}
