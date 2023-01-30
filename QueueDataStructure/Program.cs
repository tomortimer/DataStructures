using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //queueTest();
            //limitedQueueTest();
            stackTest();
            //limitedStackTest();
            //listTest();
            //doubleLinkedListTest();
        }

        static void queueTest()
        {
            int[] i = { 1, 2, 3, 4, 5, 6 };
            Queue<int> Q = new Queue<int>(i);
            Console.WriteLine("Count " + Q.Count());
            Console.WriteLine(Q.Contains(3));
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.deQueue());
            Console.WriteLine("Count " + Q.Count());
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.Contains(3));
            Console.WriteLine("Count " + Q.Count());
        }
        
        static void limitedQueueTest()
        {
            LimitedQueue<int> Q = new LimitedQueue<int>(6);
            Q.enQueue(1);
            Q.enQueue(2);
            Q.enQueue(3);
            Q.enQueue(4);
            Q.enQueue(5);
            Q.enQueue(6);
            Console.WriteLine("Count " + Q.Count());
            Console.WriteLine(Q.Contains(3));
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.deQueue());
            Console.WriteLine("Count " + Q.Count());
            Console.WriteLine(Q.Contains(3));
            Q.enQueue(1);
            Q.enQueue(2);
            Q.enQueue(3);
            
            Console.WriteLine("Count " + Q.Count());
            Console.WriteLine(Q.Contains(3));
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.deQueue()); 
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.deQueue());
            Console.WriteLine(Q.deQueue());
        }

        static void stackTest()
        {
            int[] i = { 1, 2, 3, 4, 5 , 6};
            Stack<int> s = new Stack<int>(i);
            Console.WriteLine("Count: " + s.Count());
            Console.WriteLine("Peek: " + s.Peek());
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Count: " + s.Count());
            Console.WriteLine("Contains 3: " + s.Contains(3));
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Count: " + s.Count());
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Count: " + s.Count());
            Console.WriteLine("Contains 3: " + s.Contains(3));
        }

        static void limitedStackTest()
        {
            LimitedStack<int> s = new LimitedStack<int>(6);
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);
            s.Push(6);
            s.Push(7);
            s.Push(8);
            Console.WriteLine("Count: " + s.Count());
            Console.WriteLine("Peek: " + s.Peek());
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Count: " + s.Count());
            Console.WriteLine("Contains 3: " + s.Contains(3));
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Count: " + s.Count());
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Pop: " + s.Pop());
            Console.WriteLine("Count: " + s.Count());
            Console.WriteLine("Contains 3: " + s.Contains(3));
        }

        static void listTest()
        {
            LList<int> L = new LList<int>();
            Console.WriteLine("Count " + L.Count());
            L.Add(1);
            L.Add(2);
            L[0] = 7382952;
            L.Add(3);
            L.Add(4);
            L.Add(5);
            L.Insert(3, 990);
            Console.WriteLine(L[0]);
            Console.WriteLine(L[1]);
            Console.WriteLine(L[2]);
            Console.WriteLine(L[3]);
            Console.WriteLine(L[4]);
            Console.WriteLine(L[5]);
            Console.WriteLine("Count " + L.Count());
        }

        static void doubleLinkedListTest()
        {
            DoubleLinkedList<int> L = new DoubleLinkedList<int>();
            Console.WriteLine("Count " + L.Count());
            L.Add(1);
            L.Add(1);
            L.Add(1);
            Console.WriteLine("Count " + L.Count());
            L.Add(1);
            L.Add(1);
            Console.WriteLine(L.RemoveAt(4) + " removed");
            Console.WriteLine("Count 1 = " + L.Count(1));
            Console.WriteLine(L[0]);
            Console.WriteLine(L[1]);
            Console.WriteLine(L[2]);
            Console.WriteLine(L[3]);
            Console.WriteLine("Count " + L.Count());
        }
    }
}
