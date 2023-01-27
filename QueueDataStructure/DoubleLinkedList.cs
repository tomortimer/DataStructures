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
            DoubleLinkedNode<T> tmp = head;
            while(i > 0)
            {
                if(tmp == null) { throw new IndexOutOfRangeException(); }
                tmp = tmp.next;
                i--;
            }
            return tmp.GetData();
        }
    }
}
