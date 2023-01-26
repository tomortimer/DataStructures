using System;

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

        public T RemoveAt(int i) 
        {
            ListNode<T> tmp = head;

        }

        //wanted to have these two options for count but functionality's different, so:
        public int Count()
        {
            return Length(head);
        }

        public int Count(T inp)
        {
            return Search(head, inp);
        }

        //recursive, looks a bit messy but it's built on the Length method so it's alright really
        private int Search(ListNode<T> node, T inp)
        {
            //if node == null list is empty or somehow got out of bounds or is missing a node, most normally an empty list or the end of one so returns 0
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

        //this could also be done with while but seems like clean recursion so I'll leave it in :)
        private int Length(ListNode<T> node)
        {
            //if node == null, the list is empty
            if (node != null)
            {
                return 1 + Length(node.next);
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
