using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class DoubleLinkedNode<T>
    {
        //list linked double!!
        public DoubleLinkedNode<T> previous = null;
        public DoubleLinkedNode<T> next = null;
        private T data;

        //constructor
        public DoubleLinkedNode(T inp)
        {
            data = inp;
        }

        public T GetData() { return data; }
        public void SetData(T inp) { data = inp; }
    }
}
