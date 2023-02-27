using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Graph<T>
    {
        //use value/name of node(T) as key, second dictionary uses node name/value - distance
        private Dictionary<T, Dictionary<T, int>> adjacency;
        private bool unrouted = false;

        //takes value of node as input and adjacency matrix(as a dictionary)
        public void addNode(T val, Dictionary<T, int> adj)
        {
            adjacency.Add(val, adj);
            //add node to other nodes ajacency matrices if graph is not routed
            if (unrouted)
            {
                foreach(var pair in adj)
                {
                    adjacency[pair.Key].Add(val, pair.Value);
                }
            }
        }


        //constructors take bool for unrouted, otherwise assumes routed
        public Graph()
        {
            adjacency = new Dictionary<T, Dictionary<T, int>>();
        }

        //graph constructor with one start node
        public Graph(T val)
        {
            adjacency = new Dictionary<T, Dictionary<T, int>>();
            Dictionary<T, int> empty = new Dictionary<T, int>();
            adjacency.Add(val, empty);
        }

        //takes graph as a dictionary
        public Graph(Dictionary<T, Dictionary<T, int>> adj)
        {
            adjacency = adj;
        }

        public Graph(bool unroute)
        {
            adjacency = new Dictionary<T, Dictionary<T, int>>();
            unrouted = unroute;
        }

        //graph constructor with one start node - has bool
        public Graph(T val, bool unroute)
        {
            adjacency = new Dictionary<T, Dictionary<T, int>>();
            Dictionary<T, int> empty = new Dictionary<T, int>();
            adjacency.Add(val, empty);
            unrouted = unroute;
        }

        //takes graph as a dictionary - has bool
        public Graph(Dictionary<T, Dictionary<T, int>> adj, bool unroute)
        {
            adjacency = adj;
            unrouted = unroute;
        }
    }
}
