using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    public delegate void NewAddedQueueEventHandler(object arr, NewAddedEventArgs args);
    public delegate void NewRemovedQueueEventHandler(object arra, NewRemovedEventArgs arg);
    public delegate void StackIsFullQueueEventHandler(object arr, StackIsFullEventArgs args);
    public delegate void StackIsEmptyQueueEventHandler(object arr, StackIsEmptyEventArgs args);

    class DynamicQueue<T> : DynamicArray<T>, IMyQueue<T>
    {
        private int head;
        private int tail;
        private int QSize;
        private int maxSize;

        public DynamicQueue(int sizeQ)
        {
            head = sizeQ;
            tail = 0;
            QSize = 0;
            maxSize = sizeQ;
            linkSize = 0;
            //nodeHead.setNextNode(null);
        }

        public int Size()
        {
            return linkSize;
        }

        public bool IsFull()
        {
            if (linkSize < maxSize)  // check if the buffer is not full yet
            {
                return false;
            }
            else
            {
                QueueIsFull -= QueueInst_StackIsFull;
                QueueIsFull += QueueInst_StackIsFull;
                OnQueueIsFull();
                return true;
            }
        }

        public bool IsEmpty()
        {
            if (QSize <= maxSize && QSize > 0) // check if stack is not empty already
            {
                return false;
            }
            else
            {
                QueueIsEmpty -= QueueInst_StackIsEmpty;
                QueueIsEmpty += QueueInst_StackIsEmpty;
                OnQueueIsEmpty();
                return true;
            }
        }

        public T Peek()
        {
            return TValue;
        }

        public void Enqueue(T newTop)
        {
            //if (linkSize < maxSize)  // check if head index is less than the array size
            // {
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
            head = linkSize;
            TValue = newTop;
            Insert(head, newTop); // adding new element
            NewElementQueueIsAdded -= QueueInst_NewElementIsAdded;
            NewElementQueueIsAdded += QueueInst_NewElementIsAdded;
            OnNewIsAddedQueue();
            QSize++; // increase the size of buffer
            //}
        }

        public T Dequeue()
        {
            //if (linkSize > 0) // if the tail is less than the size of array
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
            TValue = Remove(tail);
            NewElementQueueIsRemoved -= QueueInst_ElementIsRemoved;
            NewElementQueueIsRemoved += QueueInst_ElementIsRemoved;
            OnNewIsRemovedQueue();
            QSize--; // reduce the size of the buffer
            //}
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
        public event NewAddedQueueEventHandler NewElementQueueIsAdded;
        public event NewRemovedQueueEventHandler NewElementQueueIsRemoved;
        public event StackIsFullQueueEventHandler QueueIsFull;
        public event StackIsEmptyQueueEventHandler QueueIsEmpty;

        public void OnNewIsAddedQueue()
        {
            NewAddedEventArgs args = new NewAddedEventArgs(linkSize, TValue);
            if (NewElementQueueIsAdded != null)
            {
                NewElementQueueIsAdded(this, args);
            }
        }
        public void OnNewIsRemovedQueue()
        {
            NewRemovedEventArgs arg = new NewRemovedEventArgs(linkSize, TValue);
            if (NewElementQueueIsRemoved != null)
            {
                NewElementQueueIsRemoved(this, arg);
            }
        }
        public void OnQueueIsFull()
        {
            StackIsFullEventArgs arg = new StackIsFullEventArgs(linkSize, TValue);
            if (QueueIsFull != null)
            {
                QueueIsFull(this, arg);
            }
        }
        public void OnQueueIsEmpty()
        {
            StackIsEmptyEventArgs arg = new StackIsEmptyEventArgs(linkSize, TValue);
            if (QueueIsEmpty != null)
            {
                QueueIsEmpty(this, arg);
            }
        }
        private static void QueueInst_NewElementIsAdded(object arr, NewAddedEventArgs args)
        {
            Console.WriteLine("Event_add: New element {0} was added at index {1} to the queue", args.Value, args.Index);
        }
        private static void QueueInst_ElementIsRemoved(object arr, NewRemovedEventArgs args)
        {
            Console.WriteLine("Event_remove: The element {0} was removed from the queue", args.Value, args.Index);
        }
        private static void QueueInst_StackIsFull(object arr, StackIsFullEventArgs args)
        {
            Console.WriteLine("Event_full: The queue of size {0} is full ", args.Index);
        }
        private static void QueueInst_StackIsEmpty(object arr, StackIsEmptyEventArgs args)
        {
            Console.WriteLine("Event_empty: The queue is empty ", args.Index);
        }
    }
}
