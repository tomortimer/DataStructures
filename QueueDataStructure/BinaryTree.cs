using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class BinaryTree<T>
    {
        BinaryTreeNode<T> root = null;
        public void Add(T inp)
        {
            if(root != null)
            {
                int hashInp = inp.GetHashCode();
                BinaryTreeNode<T> tmp = root;
                while(tmp != null)
                {
                    //if neither of these conditions are satisfied, value is already in tree (presumably)
                    if(hashInp < tmp.data.GetHashCode())
                    {
                        tmp = tmp.left;
                    }else if(hashInp > tmp.data.GetHashCode())
                    {
                        tmp = tmp.right;
                    }
                }
                tmp = new BinaryTreeNode<T>(inp);
            }
            else
            {
                root = new BinaryTreeNode<T>(inp);
            }
        }
    }
}
