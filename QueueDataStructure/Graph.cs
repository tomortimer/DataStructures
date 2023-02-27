using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Graph<T>
    {
        //use value/name of node(T) as key, second dictionary uses node name/value - distance
        private Dictionary<T, Dictionary<T, int>> adjacency;

        //takes value of node as input and adjacency matrix(as a dictionary)
        public void addNode(T val, Dictionary<T, int> adj)
        {
            adjacency.Add(val, adj);
        }

        public Graph()
        {
            adjacency = new Dictionary<T, Dictionary<T, int>>();
        }
    }
}
