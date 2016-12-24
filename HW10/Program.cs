using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int bufferSize = 5;
            int ValueIn = 0;

            Console.WriteLine("Please select one of the following option: 1=Stack, 2=Queue");
            Console.Write("Please enter your selection: ");
            string str = Console.ReadLine();

            switch (str)
            {
                case "1":
                case "Stack":
                    DynamicStack<int> StackInst = new DynamicStack<int>(bufferSize);
                    while (str != "q")
                    {
                        Console.WriteLine("Please select one of the following option: 1=push, 2=pop, q=quit");
                        //Console.WriteLine("Please enter your selection: ");
                        str = Console.ReadLine();
                        switch (str)
                        {
                            case "1":
                            case "push":
                                // return true if stack is still not full, otherwise return false
                                //if (!StackInst.IsFull())
                                //{
                                    Console.Write("Please enter the value to push: ");
                                    while (!(int.TryParse(Console.ReadLine(), out ValueIn))) // validate the input from console
                                    {
                                        Console.Write("Wrong value. Please enter the value to push: ");
                                    }
                                    //StackInst.NewElementIsAdded = 0;
                                    //StackInst.NewElementIsAdded += StackInst_NewElementIsAdded;
                                    StackInst.Push(ValueIn);
                                    Console.Write("Your stack is: ");
                                    StackInst.Print();// print the stack current status
                                //}
                                //else
                                //{
                                //    Console.WriteLine("The stack is full");
                                //}
                                break;
                            case "2":
                            case "pull":
                                // return true if stack is still not empty, otherwise return false
                                //if (!StackInst.IsEmpty())
                                //{
                                    StackInst.Pop();
                                    Console.Write("Your stack is: ");
                                    StackInst.Print(); // print the stack current status
                                    Console.WriteLine("The value pulled from top is: " + StackInst.Peek());
                                //}
                                //else
                                //{
                                //    Console.WriteLine("The stack is empty ");
                                //}
                                break;
                            case "q":
                            case "quite":
                                break;
                            default:
                                Console.Write("Invalid selection. ");
                                break;
                        }
                    }
                    break;
                case "2":
                case "Queue":
                    str = "";
                    DynamicQueue<int> QueueInst = new DynamicQueue<int>(bufferSize);

                    while (str != "q")
                    {
                        Console.WriteLine("Please select one of the following option: 1=enqueue, 2=dequeue q=quit");
                        str = Console.ReadLine();  // read user input from the console
                        switch (str)
                        {
                            case "1":
                            case "enqueue": // write new element to the buffer from the head
                                Console.Write("Please enter the value to enqueue: ");
                                str = Console.ReadLine();

                                if (int.TryParse(str, out ValueIn))
                                {
                                    //if (!QueueInst.IsFull())
                                    //{
                                        QueueInst.Enqueue(ValueIn);
                                        QueueInst.Print();
                                    //}
                                    //else
                                    //{
                                    //    Console.WriteLine("The queue is full");
                                    //}
                                }
                                break;
                            case "2":
                            case "dequeue": // delete first element from the buffer from the tail
                                //if (!QueueInst.IsEmpty())
                                //{
                                    QueueInst.Dequeue();
                                    QueueInst.Print();
                                    Console.WriteLine("The value deleted from the queue: " + QueueInst.Peek());
                                //}
                                //else
                                //{
                                //    Console.WriteLine("The queue is empty ");
                                //}
                                break;
                            case "q":
                            case "quit":
                                break;
                            default:
                                Console.Write("Invalid selection. ");
                                break;
                        }

                    }
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, or 3, or 4.");
                    break;
            }
            Console.WriteLine("Press ENTER to quite");
            Console.Read();
        }

        private static void StackInst_NewElementIsAdded(object arr, NewAddedEventArgs args)
        {
            Console.WriteLine("New element {0} was added at index {1}", args.Value, args.Index);
        }
    }
}
