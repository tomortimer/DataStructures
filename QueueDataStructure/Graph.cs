using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Graph<T>
    {
        //use value/name of node(T) as key, second dictionary uses node name/value - distance
        private Dictionary<T, Dictionary<T, int>> adjacency;
        private T startNode;
        private bool empty = true;
        private bool unrouted = false;

        //takes value of node as input and adjacency matrix(as a dictionary)
        public void addNode(T val, Dictionary<T, int> adj)
        {
            adjacency.Add(val, adj);
            //add node to other nodes ajacency matrices if graph is not routed
            if (unrouted)
            {
                //var will be a KeyValuePair
                foreach(var pair in adj)
                {
                    //updates all other nodes' adjacency lists
                    adjacency[pair.Key].Add(val, pair.Value);
                }
            }
            if (empty)
            {
                startNode = val;
                empty = false;
            }
        }

        //if no input, will print whole graph in depth first fashion 
        public void depthsFirstSearch()
        {
            //stack for visting list
            Stack<T> toVisit = new Stack<T>();
            List<T> visited = new List<T>();
            toVisit.Push(startNode);
            T currentNode = default;

            while(toVisit.Count() != 0)
            {
                currentNode = toVisit.Pop();
                visited.Add(currentNode);
                foreach(KeyValuePair<T, int> pair in adjacency[currentNode])
                {
                    if(!visited.Contains(pair.Key) && !toVisit.Contains(pair.Key))
                    {
                        toVisit.Push(pair.Key);
                    }
                }
            }
            
            for(int x = 0; x < visited.Count(); x++)
            {
                Console.WriteLine(visited[x]);
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
            Dictionary<T, int> newDict = new Dictionary<T, int>();
            adjacency.Add(val, newDict);
            startNode = val;
            empty = false;
        }

        //takes graph as a dictionary, requires a startnode argument
        public Graph(Dictionary<T, Dictionary<T, int>> adj, T start)
        {
            adjacency = adj;
            startNode = start;
            empty = false;
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
            Dictionary<T, int> newDict = new Dictionary<T, int>();
            adjacency.Add(val, newDict);
            unrouted = unroute;
            startNode = val;
            empty = false;
        }

        //takes graph as a dictionary - has bool NEEDS startnode root arugment thingky
        public Graph(Dictionary<T, Dictionary<T, int>> adj, bool unroute, T start)
        {
            adjacency = adj;
            unrouted = unroute;
            startNode = start;
            empty = false;
        }
    }
}
