using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class BinaryTreeNode<T>
    {
        public BinaryTreeNode<T> left = null;
        public BinaryTreeNode<T> right = null;
        public T data;

        public BinaryTreeNode(T inp) { data = inp; }
    }
}
