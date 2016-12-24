using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10
{
    public class DynamicArray<T> : DynamicAbstrBuffer<T>
    {
        protected int linkSize;
        protected T TValue;
        protected Node nodeHead;// = new Node();

        protected class Node
        {
            protected Node next;
            protected T data;

            public Node()
            {
                next = null;
            }

            public Node(T newData)
            {
                next = null;
                data = newData;                
            }
            public T getData()
            {
                return data;
            }
            public void setData(T setData)
            {
                data = setData;
            }
            public Node getNextNode()
            {
                return next;
            }
            public void setNextNode(Node setNode)
            {
                next = setNode;
            }
        }

        public override void Add(T newValue)
        {
            if (nodeHead == null)
            {
                nodeHead = new Node(newValue);
                linkSize++;
            }
            else
            {
                Node newNode = new Node(newValue);
                Node CurrentCursor = nodeHead;
                while (CurrentCursor.getNextNode() != null)
                {
                    CurrentCursor = CurrentCursor.getNextNode();
                }
                CurrentCursor.setNextNode(newNode);// head
                linkSize++;
            }
        }

        public override T Get(int ind)
        {
            int counter = 0;
            Node current = nodeHead;
            if (current.getNextNode() == null)
            {
                return current.getData();
            }
            else
            {
                while (counter < ind && current.getNextNode() != null)
                {
                    current = current.getNextNode();
                    counter++;
                }
                return current.getData();
            }
        }

        public override void Insert(int ind, T newVal)
        {
            int counter = 0;

            Node PrevNode = null;
            Node NextNode = null;
            Node IndxNode = null;
            if (ind <= linkSize && ind >= 0)
            {
                if (nodeHead == null)
                {
                    nodeHead = new Node(newVal);
                    linkSize++;
                }
                else
                {
                    Node newNode = new Node(newVal);
                    Node CurrentCursor = nodeHead;
                    if (ind == 0)
                    {
                        newNode.setNextNode(nodeHead);
                        nodeHead = newNode;
                        linkSize++;
                        return;
                    }
                    while (counter < ind - 1 && CurrentCursor.getNextNode() != null)
                    {
                        CurrentCursor = CurrentCursor.getNextNode();
                        counter++;
                    }

                    PrevNode = CurrentCursor;

                    if (PrevNode.getNextNode() != null)
                    {
                        while (counter < ind && CurrentCursor.getNextNode() != null)
                        {
                            CurrentCursor = CurrentCursor.getNextNode();
                            counter++;
                        }
                        IndxNode = CurrentCursor;
                        if (IndxNode.getNextNode() != null)
                        {
                            while (counter < ind + 1 && CurrentCursor.getNextNode() != null)
                            {
                                CurrentCursor = CurrentCursor.getNextNode();
                                counter++;
                            }
                            NextNode = CurrentCursor;

                            PrevNode.setNextNode(newNode);
                            newNode.setNextNode(IndxNode);
                            IndxNode.setNextNode(NextNode);
                            linkSize++;
                        }
                        else
                        {
                            PrevNode.setNextNode(newNode);
                            newNode.setNextNode(IndxNode);
                            linkSize++;
                        }
                    }
                    else
                    {
                        PrevNode.setNextNode(newNode);
                        newNode.setNextNode(null);
                        linkSize++;
                    }
                }
            }
        }

        public override T Remove(int ind)
        {
            int counter = 0;

            Node PrevNode = null;
            Node NextNode = null;
            Node IndxNode = null;
            if (linkSize > 0 && ind < linkSize && ind >= 0)
            {
                Node CurrentCursor = nodeHead;
                if (ind == 0)
                {
                    nodeHead = CurrentCursor.getNextNode();
                    CurrentCursor.setNextNode(null);
                    linkSize--;
                    return CurrentCursor.getData();
                }
                while (counter < ind - 1 && CurrentCursor.getNextNode() != null)
                {
                    CurrentCursor = CurrentCursor.getNextNode();
                    counter++;
                }

                PrevNode = CurrentCursor;

                if (PrevNode.getNextNode() != null)
                {
                    while (counter < ind && CurrentCursor.getNextNode() != null)
                    {
                        CurrentCursor = CurrentCursor.getNextNode();
                        counter++;
                    }
                    IndxNode = CurrentCursor;
                    if (IndxNode.getNextNode() != null)
                    {
                        while (counter < ind + 1 && CurrentCursor.getNextNode() != null)
                        {
                            CurrentCursor = CurrentCursor.getNextNode();
                            counter++;
                        }
                        NextNode = CurrentCursor;

                        PrevNode.setNextNode(NextNode);
                        IndxNode.setNextNode(null);
                        linkSize--;
                        return IndxNode.getData();
                    }
                    else
                    {
                        PrevNode.setNextNode(null);
                        IndxNode.setNextNode(null);
                        linkSize--;
                        return IndxNode.getData();
                    }
                }
            }
            return TValue;
        }
    }
}
