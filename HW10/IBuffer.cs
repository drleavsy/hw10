﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    interface IBuffer<T>
    {
        bool IsFull();
        bool IsEmpty();
        T Peek();
        void Print();
    }
}
