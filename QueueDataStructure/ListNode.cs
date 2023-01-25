using System;

namespace DataStructures
{
    class ListNode<T>
    {
        private T data;
        public ListNode<T> next = null;

        public ListNode(T inp)
        {
            data = inp;
        }

        public T GetData() { return data; }
        public void SetData(T inp) { data = inp; }
    }
}
