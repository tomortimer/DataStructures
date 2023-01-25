﻿using System;

namespace DataStructures
{
    class LList<T>
    {
        //head node poiting to nothing by default
        private ListNode<T> head = null;

        //adds to end of list
        public void Add(T inp)
        {
            ListNode<T> tmp = head;
            //checks if head is null, if it is it starts the list there with a new node
            if(head != null)
            {
                //moves through to end of list
                while (tmp.next != null)
                {
                    tmp = tmp.next;
                }
                //sets next reference to a new node
                tmp.next = new ListNode<T>(inp);
            }
            else { head = new ListNode<T>(inp); }
            
        }

        //ALLOWS THE LIST TO BE ACCESSED BY INDEXERS?!?!?!?
        public T this[int i]
        {
            //uses private methods - for readability I think?
            get { return RetrieveAt(i, head); }
            set { SetAt(i, head, value); }
        }

        //private method for retrieving data, adjusted to use while loops like SetAt()
        private T RetrieveAt(int i, ListNode<T> node)
        {
            ListNode<T> tmp = node;
            while(i > 0)
            {
                //if tmp points to null then that means index has run out of bounds
                if (tmp == null) { throw new IndexOutOfRangeException(); }
                tmp = tmp.next;
                i--;
            }
            return tmp.GetData();
        }

        //private set method - didn't work when recursive so need to fix this to work with while I think - it may have work recursively but I just didn't put the method in the indexer... oh well, while is probably safer
        private void SetAt(int i, ListNode<T> node, T inp)
        {
            ListNode<T> tmp = node;
            //runs while i >= 0, fine to do this here since using ints
            while(i > 0)
            {
                //if tmp is empty then that means index has run out of bounds
                if (tmp == null) { throw new IndexOutOfRangeException(); }
                tmp = tmp.next;
                i--;
            }
            tmp.SetData(inp);
        }

        public int Count()
        {
            return Length(head);
        }

        public int Count(T inp)
        {
            return Search(head, inp);
        }

        private int Search(ListNode<T> node, T inp)
        {
            //is node != null list is empty as this method is only called in Count with an input
            if (node != null)
            {
                if (node.next != null)
                {
                    //only increments return, via recursion, when data == input
                    if (node.GetData().Equals(inp))
                    {
                        return 1 + Search(node.next, inp);
                    }
                    else { return Search(node.next, inp); }
                }
                else
                {
                    //if we are here, next node is null, therefore recursion unspools
                    if (node.GetData().Equals(inp))
                    {
                        return 1;
                    }
                    else { return 0; }
                }
            }
            else { return 0; }
        }

        private int Length(ListNode<T> node)
        {
            //if node == null, the list is empty as this is a private method and only called by count without input
            if (node != null)
            {
                //when node.next (pointer) == null we have reached the end of the list and the recursion unspools
                if (node.next != null)
                {
                    return 1 + Length(node.next);
                }
                else
                {
                    return 1;
                }
            }
            else { return 0; }
        }

        public void AddFront(T inp)
        {
            //creates new node of input value
            ListNode<T> a = new ListNode<T>(inp);
            //points new node towards current head so it isn't lost when head now points at our new node
            a.next = head;
            head = a;
        }

    }
}