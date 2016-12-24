using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    public class NewAddedEventArgs : EventArgs
    {
        public int Index { get; set; }
        public string Value { get; set; }
        public NewAddedEventArgs(int InSize, object InValue)
        {
            Index = InSize - 1;
            Value = InValue.ToString();
        }   
    }
}
