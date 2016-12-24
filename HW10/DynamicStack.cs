using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    public delegate void NewAddedEventHandler(object arr, NewAddedEventArgs args);
    public delegate void NewRemovedEventHandler(object arra, NewRemovedEventArgs arg);
    public delegate void StackIsFullEventHandler(object arr, StackIsFullEventArgs args);
    public delegate void StackIsEmptyEventHandler(object arr, StackIsEmptyEventArgs args);

    class DynamicStack<T> : DynamicArray<T>, IMyStack<T>
    {
        private int top;
        private int stackSize;
        private int maxSize;

        public DynamicStack(int sizeStack)
        {
            linkSize = 0;
            top = 0;
           // nodeHead.setNextNode(null);
            stackSize = 0;
            maxSize = sizeStack;
        }

        public int Size()
        {
            return linkSize;
        }

        public bool IsFull()
        {
            if (linkSize == maxSize) //if stack is full
            {
                StackIsFull -= StackInst_StackIsFull;
                StackIsFull += StackInst_StackIsFull;
                OnStackIsFull();
                return true;
            }
            return false;
        }

        public bool IsEmpty()
        {
            if (linkSize == 0) // check if stack is not empty already
            {
                StackIsEmpty -= StackInst_StackIsEmpty;
                StackIsEmpty += StackInst_StackIsEmpty;
                OnStackIsEmpty();

                return true;
            }
            return false;
        }

        public T Peek()
        {
            return TValue;
        }

        public void Print()
        {
            int i = 0;
            int count_print = linkSize;
            if (count_print == 0) // if buffer is empty print [ ]
            {
                Console.Write("[ ]\n");
            }
            else
            {
                Console.Write("[ ");
                while (count_print > 0)
                {
                    Console.Write(Get(i).ToString());
                    if (count_print > 1)
                    {
                        Console.Write(", ");
                    }
                    i++;
                    count_print--; // reduce the size of printed array

                    if (count_print == 0)
                    {
                        Console.Write(" ]\n");
                    }
                }
            }
        }
        //public event NewAddedEventHandler NewElementIsAdded;
        public void Push(T newTop)
        {
            //if (!IsFull())
            //{
            try
            {
                if (linkSize == maxSize)
                {
                    throw new AddingToFullBufferException();
                }
            }
            catch (AddingToFullBufferException e)
            {
                e.FullBufferException();
                return;
            }
            top = linkSize;
            // Insert(top, newTop); // push one element
            Add(newTop);
            stackSize++;
            TValue = newTop;
            NewElementIsAdded -= StackInst_NewElementIsAdded;
            NewElementIsAdded += StackInst_NewElementIsAdded;
            OnNewIsAdded(); // Event handler
        }

        public T Pop()
        {
            //if (!IsEmpty())
            //{
            try
            {
                if (linkSize == 0)
                {
                    throw new RemoveFromEmptyBuffer();
                }
            }
            catch (RemoveFromEmptyBuffer e)
            {
                e.EmptyBufferException();
                return TValue;
            }
            top = linkSize;
            TValue = Remove(top - 1);  // save value from the top and pass it out from the method 
            NewElementIsRemoved -= StackInst_ElementIsRemoved;
            NewElementIsRemoved += StackInst_ElementIsRemoved;
            OnNewIsRemoved();
            top--; // move top one step back
            stackSize--;  // decrease the size of the stack
            return TValue;
            //}
            //else
            //{
            //Console.WriteLine("The stack is empty!");
            //    return TValue;
            //}
        }
        public event NewAddedEventHandler NewElementIsAdded;
        public event NewRemovedEventHandler NewElementIsRemoved;
        public event StackIsFullEventHandler StackIsFull;
        public event StackIsEmptyEventHandler StackIsEmpty;

        public void OnNewIsAdded()
        {
            NewAddedEventArgs args = new NewAddedEventArgs(linkSize, TValue);
            if (NewElementIsAdded != null)
            {
                NewElementIsAdded(this, args);
            }
        }
        public void OnNewIsRemoved()
        {
            NewRemovedEventArgs arg = new NewRemovedEventArgs(linkSize, TValue);
            if (NewElementIsRemoved != null)
            {
                NewElementIsRemoved(this, arg);
            }
        }
        public void OnStackIsFull()
        {
            StackIsFullEventArgs arg = new StackIsFullEventArgs(linkSize, TValue);
            if (StackIsFull != null)
            {
                StackIsFull(this, arg);
            }
        }
        public void OnStackIsEmpty()
        {
            StackIsEmptyEventArgs arg = new StackIsEmptyEventArgs(linkSize, TValue);
            if (StackIsEmpty != null)
            {
                StackIsEmpty(this, arg);
            }
        }
        private static void StackInst_NewElementIsAdded(object arr, NewAddedEventArgs args)
        {
            Console.WriteLine("Event_add: New element {0} was added at index {1}", args.Value, args.Index);
        }
        private static void StackInst_ElementIsRemoved(object arr, NewRemovedEventArgs args)
        {
            Console.WriteLine("Event_remove: The element {0} was removed at index {1}", args.Value, args.Index);
        }
        private static void StackInst_StackIsFull(object arr, StackIsFullEventArgs args)
        {
            Console.WriteLine("Event_full: The stack of size {0} is full ", args.Index);
        }
        private static void StackInst_StackIsEmpty(object arr, StackIsEmptyEventArgs args)
        {
            Console.WriteLine("Event_empty: The stack is empty ", args.Index);
        }
    }
}
