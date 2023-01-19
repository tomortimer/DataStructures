using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class LimitedQueue<T>
    {
        //using an array as the queue
        private T[] queue;
        //can compare itemCtr and size to see if queue is full
        private int size;
        private int itemCtr = 0;
        private int startPtr = 0;
        //still needs endPtr, for .Contains()
        private int endPtr = 0;

        //constructors can take no value, single or array as with unlimited queue
        public LimitedQueue (int s)
        {
            size = s;
            //initialises array with size as specified by object instantiation parameters
            queue = new T[s];
        }

        public LimitedQueue (int s, T inp)
        {
            size = s;
            //initialises array with size as specified by object instantiation parameters
            queue = new T[s];
            this.enQueue(inp);
        }

        //items over queue size won't be added to queue with this constructor
        public LimitedQueue(int s, T[] inp) 
        {
            size = s;
            //initialises array with size as specified by object instantiation parameters
            queue = new T[s];
            foreach(T a in inp)
            {
                this.enQueue(a);
            }
        }

        //also takes array but no size, so queue size is made to be original array's size
        public LimitedQueue(T[] inp)
        {
            size = inp.Length;
            queue = inp;

        }

        //returns false is queue is full and unable to enqueue
        public bool enQueue(T inp)
        {
            bool success = false;
            if(itemCtr < size)
            {
                //adds item to end of queue
                queue[endPtr] = inp;
                //increments endPtr and modulus so that queue is cyclic within array
                endPtr = (endPtr + 1) % size;
                itemCtr++;
                success = true;
            }
            return success;
        }

        public T deQueue()
        {
            //default value for T in case queue is empty
            T ret = default;
            if(itemCtr != 0) 
            {
                ret = queue[startPtr];
                //increments start pointer and modulus so that queue is cyclic within array
                startPtr = (startPtr + 1) % size;
                itemCtr--;
            }
            return ret;
        }

        public T Peek()
        {
            //default value for T in case queue is empty
            T ret = default;
            //queue is empty if start ptr and end ptr are the same
            if (startPtr != endPtr)
            {
                ret = queue[startPtr];
            }
            return ret;
        }

        public int Count()
        {
            return itemCtr;
        }

        public bool Contains(T inp)
        {
            bool cont = false;
            //same issue as Count
            for (int x = startPtr; x < itemCtr + startPtr; x++)
            {
                if (queue[x % size].Equals(inp))
                {
                    cont = true;
                    x = itemCtr + startPtr;
                }
            }
            return cont;
        }
    }
}
