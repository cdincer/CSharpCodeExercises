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
        #region Binary Tree Inorder Traversal
        /*
        Given the root of a binary tree, return the inorder traversal of its nodes' values.

        Example 1:

        Input: root = [1,null,2,3]
        Output: [1,3,2]

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
        https://leetcode.com/problems/binary-tree-inorder-traversal/description/
        */
        public List<int> InorderTraversal(TreeNode root)
        {
            List<int> res = new();
            helper(root, res);
            return res;
        }

        public void helper(TreeNode root, List<int> res)
        {
            if (root != null)
            {
                helper(root.left, res);
                res.Add(root.val);
                helper(root.right, res);
            }
        }

        public List<int> InorderTraversal2(TreeNode root)
        {
            List<int> res = new();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curr = root;
            while (curr != null || stack.Count != 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                curr = stack.Pop();
                res.Add(curr.val);
                curr = curr.right;
            }
            return res;
        }
        #endregion
        #region Binary Tree Postorder Traversal
        /*
        Given the root of a binary tree, return the postorder traversal of its nodes' values.

        Example 1:

        Input: root = [1,null,2,3]
        Output: [3,2,1]

        Example 2:

        Input: root = []
        Output: []

        Example 3:

        Input: root = [1]
        Output: [1]

        

        Constraints:

            The number of the nodes in the tree is in the range [0, 100].
            -100 <= Node.val <= 100

        
        Follow up: Recursive solution is trivial, could you do it iteratively?
        https://leetcode.com/problems/binary-tree-postorder-traversal/
        */
        private IList<int> pot = new List<int>();

        public IList<int> PostorderTraversal(TreeNode root)
        {
            helper(root);
            return pot;
        }

        public void helper(TreeNode root)
        {
            if (root != null)
            {
                helper(root.left);
                helper(root.right);
                pot.Add(root.val);
            }
        }
        //Iterative
        public IList<int> PostorderTraversal2(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            stack.Push(root);

            var resultStack = new Stack<int>();

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current != null)
                {
                    resultStack.Push(current.val);
                    stack.Push(current.left);
                    stack.Push(current.right);
                }
            }

            return resultStack.ToList();
        }
        #endregion
        #endregion
    }
}