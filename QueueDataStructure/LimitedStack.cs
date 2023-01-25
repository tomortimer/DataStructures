using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class LimitedStack<T>
    {
        //using stack as a list
        T[] stack;
        //top index starts at -1 so if the first item is pushed rather than when the stack is intialised it plays nicely
        int index = -1;


        //constructors, see limited queue comment for logic about sizing
        public LimitedStack(int s)
        {
            stack = new T[s];
        }

        public LimitedStack(int s, T inp)
        {
            stack = new T[s];
            this.Push(inp);
        }

        //array items being pushed when exceeding size will not be pushed to stack
        public LimitedStack(int s, T[] inp)
        {
            stack = new T[s];
            foreach(T a in inp) { this.Push(a); }
        }

        //takes array length as size of new stack
        public LimitedStack(T[] inp)
        {
            stack = new T[inp.Length];
            foreach(T a in inp) { this.Push(a); }
        }

        //returns bool whether push is successful or not
        public bool Push(T inp)
        {
            bool success = false;
            int targetInd = index + 1;
            //checks to see if target index for push exceeds stack size
            if(targetInd < stack.Length)
            {
                stack[targetInd] = inp;
                //increments index of top item in a successful push
                index++;
                success = true;
            }
            return success;
        }

        public T Pop()
        {
            T ret = default;
            //checks to see if top item index is less than zero, meaning stack is empty
            if(index > -1)
            {
                ret = stack[index];
                //decrements index, no need to change stack, item will be written over
                index--;
            }
            return ret;
        }

        public int Count()
        {
            return index + 1;
        }

        public bool isFull()
        {
            bool full = false;
            if((index + 1) == stack.Length) { full = true; }
            return full;
        }

        public bool isEmpty()
        {
            bool empty = false;
            if(index == -1) { empty = true; }
            return empty;
        }

        //returns top item without changing stack
        public T Peek()
        {
            T ret = default;
            //checks to see if top item index is less than zero, meaning stack is empty
            if (index > -1)
            {
                ret = stack[index];
            }
            return ret;
        }

        public bool Contains(T inp)
        {
            bool cont = false;
            //checks stack from bottom up
            for(int x = 0; x <= index; x++)
            {
                if (stack[x].Equals(inp))
                {
                    cont = true;
                    x = index + 1;
                }
            }
            return cont;
        }
    }
}
