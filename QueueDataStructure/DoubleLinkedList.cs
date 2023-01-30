using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class DoubleLinkedList<T>
    {
        DoubleLinkedNode<T> head = null;

        public void Add(T inp)
        {
            //moves from front to back, where tmp.next == null
            DoubleLinkedNode<T> tmp = head;
            //if tmp = null here then list is empty
            if(tmp != null)
            {
                while(tmp.next != null)
                {
                    tmp = tmp.next;
                }
                DoubleLinkedNode<T> n = new DoubleLinkedNode<T>(inp);
                //double links the node
                n.previous = tmp;
                tmp.next = n;
            }
            else
            {
                head = new DoubleLinkedNode<T>(inp);
            }
        }

        //INDEXERS AGAIN!?!?!?
        public T this[int i]
        {
            get { return RetrieveAt(i); }
            set { SetAt(i, value); }
        }

        //private get method
        private T RetrieveAt(int i)
        {
            //errors need to be thrown
            if(i < 0) { throw new IndexOutOfRangeException(); }
            //starts at top of list
            DoubleLinkedNode<T> tmp = head;
            while(i > 0)
            {
                if(tmp == null) { throw new IndexOutOfRangeException(); }
                tmp = tmp.next;
                i--;
            }
            return tmp.GetData();
        }

        //private set method
        private void SetAt(int i, T inp)
        {
            //errors need to be thrown
            if (i < 0) { throw new IndexOutOfRangeException(); }
            DoubleLinkedNode<T> tmp = head;
            //moves down list until index is reached, if end is reached before index exception is thrown
            while(i > 0)
            {
                if(tmp == null) { throw new IndexOutOfRangeException(); }
                tmp = tmp.next;
                i--;
            }
            tmp.SetData(inp);
        }

        //count can take input or no input, provides length in case of no inputs
        public int Count()
        {
            return Length(head);
        }

        public int Count(T inp)
        {
            DoubleLinkedNode<T> tmp = head;
            int ctr = 0;
            while(tmp != null)
            {
                if (head.GetData().Equals(inp)) { ctr++; }
                tmp = tmp.next;
            }
            return ctr;
        }

        private int Length(DoubleLinkedNode<T> node)
        {
            //recursively moves down the list, unwinds when reaching null, being the end of the list
            if(node != null)
            {
                return 1 + Length(node.next);
            }
            else
            {
                return 0;
            }
        }

        public T RemoveAt(int i)
        {
            //checks bounds before proceeding
            if(i < 0 || i > this.Count() || head == null) { throw new ArgumentOutOfRangeException(); }
            T ret = default;
            DoubleLinkedNode<T> tmp = head;
            //needs to be handled differently if index is 0
            if(i == 0)
            {
                ret = head.GetData();
                if (head.next != null)
                {
                    head.next.previous = null;
                    head = head.next;
                }
                else
                {
                    //happens if head.next == null
                    head = null;
                }
            }
            else
            {
                //moves down list to index
                while (i > 0)
                {
                    tmp = tmp.next;
                    i--;
                }

                ret = tmp.GetData();
                //handles differently if at end of list (tmp.next == null)
                if(tmp.next == null)
                {
                    //simply dereference tmp
                    tmp.previous.next = null;
                }
                else
                {
                    //more complicated dereferencing
                    tmp.previous.next = tmp.next;
                    tmp.next.previous = tmp.previous;
                }
            }

            return ret;
        }

        public void InsertAt(T inp, int i)
        {

        }
    }
}
