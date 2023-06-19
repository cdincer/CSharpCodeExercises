using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tier2
{   //https://leetcode.com/explore/learn/card/data-structure-tree/
    public class BinaryTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        #region Traverse A Tree
        #region Binary Tree Preorder Traversal
        /* 
        Given the root of a binary tree, return the preorder traversal of its nodes' values.

        Example 1:

        Input: root = [1,null,2,3]
        Output: [1,2,3]

        Example 2:

        Input: root = []
        Output: []

        Example 3:

        Input: root = [1]
        Output: [1]

        Constraints:

            The number of nodes in the tree is in the range [0, 100].
            -100 <= Node.val <= 100

        Follow up: Recursive solution is trivial, could you do it iteratively?

        https://leetcode.com/problems/binary-tree-preorder-traversal/description/
        */
        private List<int> answer = new();

        private void dfs(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            // Visit the root first, then the left subtree, then the right subtree.
            answer.Add(node.val);
            dfs(node.left);
            dfs(node.right);
        }

        public List<int> PreorderTraversal(TreeNode root)
        {
            dfs(root);
            return answer;
        }
        //Iterative Approach
        public IList<int> PreorderTraversal2(TreeNode root)
        {
            List<int> answer = new();
            Stack<TreeNode> stack = new();
            stack.Push(root);

            // Note that we add currNode's right child to the stack first.
            while (stack.Count != 0)
            {
                TreeNode currNode = stack.Peek();
                stack.Pop();
                if (currNode != null)
                {
                    answer.Add(currNode.val);
                    stack.Push(currNode.right);
                    stack.Push(currNode.left);
                }
            }

            return answer;
        }
        #endregion
        #endregion 
    }
}