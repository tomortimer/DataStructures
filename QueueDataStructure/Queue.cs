using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Queue<T>
    {
        //using a List as the queue
        private List<T> queue = new List<T>();
        private bool empty = true;
        private int startPtr = 0;
        //endPtr is always one more than index of last element, therefore if start and end are same, queue is empty
        private int endPtr = 0;

        //constructors can take single argument or array
        public Queue()
        {

        }

        public Queue(T inp)
        {
            queue.Add(inp);
            endPtr++;
        }

        public Queue(T[] inp)
        {
            foreach(T a in inp)
            {
                queue.Add(a);
                endPtr++;
            }
        }

        public T deQueue()
        {
            //default value for T will be returned if the queue is empty to avoid errors
            T ret = default;
            checkEmpty();
            if(!empty)
            {
                //takes first item in the queue then moves pointer forward
                ret = queue[startPtr];
                startPtr++;
            }
            return ret;
        }

        public T Peek()
        {
            //default value for T in case queue is empty
            T ret = default;
            checkEmpty();
            if (!empty)
            {
                //takes first item in queue BUT DOES NOT CHANGE POINTER
                ret = queue[startPtr];
            }
            return ret;
        }

        public void enQueue(T inp)
        {
            //adds item to queue and increments end pointer
            queue.Add(inp);
            endPtr++;
        }

        public bool Contains(T inp)
        {
            bool cont = false;
            for(int x = startPtr; x < endPtr; x++)
            {
                if(queue[x].Equals(inp))
                {
                    cont = true;
                    x = endPtr;
                }
            }
            return cont;
        }

        //returns number of items
        public int Count()
        {
            return endPtr - startPtr;
        }

        private void checkEmpty()
        {
            //see comment in variables for pointer logic
            if(startPtr == endPtr)
            {
                empty = true;
            }
            else
            {
                empty = false;
            }
        }

        public bool isEmpty()
        {
            checkEmpty();
            return empty;
        }

    }
}
