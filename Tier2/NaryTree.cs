using System.Collections.Generic;

namespace CSharpCodeExercises.Tier2
{
    public class NaryTree
    {
        //Required Data Structure for exercises
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        #region Traversal
        #region N-ary Tree Preorder Traversal
        /*
        Given the root of an n-ary tree, return the preorder traversal of its nodes' values.

        Nary-Tree input serialization is represented in their level order traversal. Each group of children is separated by the null value (See examples)

        Example 1:
        Input: root = [1,null,3,2,4,null,5,6]
        Output: [1,3,5,6,2,4]

        Example 2:
        Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
        Output: [1,2,3,6,7,11,14,4,8,12,5,9,13,10]

        Constraints:

            The number of nodes in the tree is in the range [0, 104].
            0 <= Node.val <= 104
            The height of the n-ary tree is less than or equal to 1000.

        Follow up: Recursive solution is trivial, could you do it iteratively?
        Extra test case:
        [] 38th test case out of 39.
        https://leetcode.com/problems/n-ary-tree-preorder-traversal/
        */

        //Official solutions for traversal are behind the paywall. All of them.
        List<int> myList = new();

        public IList<int> Preorder(Node root)
        {
            if (root == null)
                return null;

            if (!myList.Contains(root.val))
                myList.Add(root.val);

            foreach (Node passing in root.children)
            {
                myList.Add(passing.val);
                if (passing.children != null)
                {
                    Preorder(passing);
                }
            }
            return myList;
        }
        public IList<int> PreorderIterative(Node root)
        {
            IList<int> r = new List<int>();
            Stack<Node> st = new Stack<Node>();
            st.Push(root);

            while (st.Count > 0)
            {
                Node cr = st.Pop();
                if (cr != null)
                {
                    r.Add(cr.val);
                    IList<Node> temp = cr.children;
                    for (int i = temp.Count - 1; i >= 0; i--)
                        st.Push(temp[i]);
                }
            }
            return r;
        }
        #endregion
        #region N-ary Tree Postorder Traversal
        /*
        Given the root of an n-ary tree, return the postorder traversal of its nodes' values.

        Nary-Tree input serialization is represented in their level order traversal. Each group of children is separated by the null value (See examples)
        Example 1:
        Input: root = [1,null,3,2,4,null,5,6]
        Output: [5,6,3,2,4,1]

        Example 2:
        Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
        Output: [2,6,14,11,7,3,12,8,4,13,9,10,5,1]

        Constraints:
            The number of nodes in the tree is in the range [0, 104].
            0 <= Node.val <= 104
            The height of the n-ary tree is less than or equal to 1000.

        Follow up: Recursive solution is trivial, could you do it iteratively?
        https://leetcode.com/problems/n-ary-tree-postorder-traversal/description/
        */
        //Both of the solutions below belong to me.
        List<int> myList2 = new();
        public IList<int> Postorder(Node root)
        {
            postrecur(root);
            return myList2;
        }

        public void postrecur(Node root)
        {
            if (root == null)
                return;

            if (root.children != null)
            {
                for (int i = 0; i < root.children.Count; i++)
                {
                    Postorder(root.children[i]);
                }
            }

            myList2.Add(root.val);
        }
        //Iterative
        public IList<int> Postorder2(Node root)
        {
            List<int> myList = new();
            Stack<Node> myStack = new();
            Stack<Node> reverseStack = new();

            if (root == null)
                return myList;

            myStack.Push(root);
            while (myStack.Count > 0)
            {
                Node currNode = myStack.Pop();
                reverseStack.Push(currNode);
                for (int i = 0; i < currNode.children.Count; i++)
                {
                    myStack.Push(currNode.children[i]);
                }
            }

            while (reverseStack.Count > 0)
            {
                Node currNode = reverseStack.Pop();
                myList.Add(currNode.val);
            }

            return myList;
        }


        #endregion
        #endregion
    }
}