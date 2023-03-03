using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class dijkstraNode<T>
    {
        public int distance = 999;
        public T value;

        public dijkstraNode(T val)
        {
            value = val;
        }

        public dijkstraNode(T val, int dist)
        {
            value = val;
            distance = dist;
        }
    }
}
