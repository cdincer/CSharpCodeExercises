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
        #region Binary Tree Level Order Traversal
        /*
        Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

        Example 1:

        Input: root = [3,9,20,null,null,15,7]
        Output: [[3],[9,20],[15,7]]

        Example 2:

        Input: root = [1]
        Output: [[1]]

        Example 3:

        Input: root = []
        Output: []

        Constraints:

            The number of nodes in the tree is in the range [0, 2000].
            -1000 <= Node.val <= 1000


        https://leetcode.com/problems/binary-tree-level-order-traversal/
        */
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int count = queue.Count;
                List<int> level = new List<int>();

                for (int i = 0; i < count; i++)
                {
                    TreeNode cur = queue.Dequeue();
                    level.Add(cur.val);

                    if (cur.left != null)
                    {
                        queue.Enqueue(cur.left);
                    }
                    if (cur.right != null)
                    {
                        queue.Enqueue(cur.right);
                    }
                }

                result.Add(level);
            }

            return result;
        }
        #endregion
        #endregion
        #region Solve Problems Recursively
        #region Maximum Depth of Binary Tree
        /*
        Given the root of a binary tree, return its maximum depth.

        A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

        

        Example 1:

        Input: root = [3,9,20,null,null,15,7]
        Output: 3

        Example 2:

        Input: root = [1,null,2]
        Output: 2

        

        Constraints:

            The number of nodes in the tree is in the range [0, 104].
            -100 <= Node.val <= 100


        https://leetcode.com/problems/maximum-depth-of-binary-tree/
        */
        int maxDepth = 0;
        public int MaxDepth(TreeNode root)
        {
            GetMaxDepth(root, 1);
            return maxDepth;
        }
        private void GetMaxDepth(TreeNode root, int depth)
        {
            if (root == null) return;

            if (maxDepth < depth)
                maxDepth = depth;
            GetMaxDepth(root.left, depth + 1);
            GetMaxDepth(root.right, depth + 1);
        }
        #endregion
        #region Symmetric Tree
        /*
        Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
        Example 1:

        Input: root = [1,2,2,3,4,4,3]
        Output: true

        Example 2:

        Input: root = [1,2,2,null,3,null,3]
        Output: false

        Constraints:

            The number of nodes in the tree is in the range [1, 1000].
            -100 <= Node.val <= 100

        
        Follow up: Could you solve it both recursively and iteratively?
        https://leetcode.com/problems/symmetric-tree/
        Test Case:Use leetcode tree visualizer to see the differences between trees below.
        [2,3,3,4,5,5,4,null,null,8,9,null,null,9,8]
        [2,3,3,5,5,5,5,null,null,8,9,null,null,9,8]
        [1,2,2,null,3,3]
        Custom Solution Below:
        Runtime: 86 ms Beats 99.4% Memory: 42 MB Beats 7.39%
        */
        #region  My Solution
        public class MyNode
        {
            public int val;
            public int left;
            public int right;
            public int currdepth;
            public int nextdepth;
            public string location;
            public MyNode(int val = 0, int left = 0, int right = 0, int currdepth = 0, int nextdepth = 0, string location = "")
            {
                this.val = val;
                this.left = left;
                this.right = right;
                this.currdepth = currdepth;
                this.nextdepth = nextdepth;
                this.location = location;
            }
        }
        List<MyNode> items = new List<MyNode>();
        public bool IsSymmetric(TreeNode root)
        {
            dfs(root, "root", 1);
            foreach (MyNode item in items)
            {
                Console.WriteLine(" main value " + item.val +
                    " left value " + item.left +
                    " right value " + item.right +
                    " currentdepth " + item.currdepth +
                    " nextdepth " + item.nextdepth
                );
                if (item.currdepth != 1)
                {
                    string direction = item.location == "left" ? "right" : "left";
                    MyNode searchResults = items.Find(x => x.left == item.right
                             && x.right == item.left
                             && x.currdepth == item.currdepth
                             && x.nextdepth == item.nextdepth
                             && x.val == item.val
                             && x.location == direction);
                    if (searchResults == null)
                    {
                        return false;
                    }
                }

            }
            //put the depth,branch,value
            //find the opposite depth,branch,value.
            //erase both.
            //at the end if count is more than 0 cut its false.
            return true;
        }

        public void dfs(TreeNode root, string location, int depth)
        {
            if (root == null) return;
            dfs(root.left, "left", depth + 1);
            dfs(root.right, "right", depth + 1);

            int branch1 = root.left != null ? root.left.val : 0;
            int branch2 = root.right != null ? root.right.val : 0;

            items.Add(new MyNode(root.val, branch1, branch2, depth, depth + 1, location));
        }
        #endregion
        #region  Optimum Short Solution
        public bool IsSymmetric2(TreeNode root) => CheckSymetry(root?.left, root?.right);

        private bool CheckSymetry(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
                return left?.val == right?.val;
            if (left.val != right.val)
                return false;

            return CheckSymetry(left.left, right.right) && CheckSymetry(left.right, right.left);
        }

        #endregion

        #endregion
        #region Path Sum
        /*
        Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.

        A leaf is a node with no children.

        Example 1:

        Input: root = [5,4,8,11,null,13,4,7,2,null,null,null,1], targetSum = 22
        Output: true
        Explanation: The root-to-leaf path with the target sum is shown.

        Example 2:

        Input: root = [1,2,3], targetSum = 5
        Output: false
        Explanation: There two root-to-leaf paths in the tree:
        (1 --> 2): The sum is 3.
        (1 --> 3): The sum is 4.
        There is no root-to-leaf path with sum = 5.

        Example 3:

        Input: root = [], targetSum = 0
        Output: false
        Explanation: Since the tree is empty, there are no root-to-leaf paths.

        

        Constraints:

            The number of nodes in the tree is in the range [0, 5000].
            -1000 <= Node.val <= 1000
            -1000 <= targetSum <= 1000


        https://leetcode.com/problems/path-sum/
        Test Cases:
        [1,-2,-3,1,3,-2,null,-1]
        3
        []
        0
        Custom solution below:
        Runtime:105 ms Beats:68.75%
        Memory:42.6 MB Beats:18.90%
        */
        private int target = 0;
        private bool aresult = false;
        private void pathHelper(TreeNode node, int seperateAmount)
        {
            if (node == null)
            {
                return;
            }
            seperateAmount += node.val;
            if (node.left == null && node.right == null)
            {
                if (target == seperateAmount)
                {
                    aresult = true;
                    return;
                }
            }
            // Visit the root first, then the left subtree, then the right subtree.
            pathHelper(node.left, seperateAmount);
            pathHelper(node.right, seperateAmount);
        }
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            target = targetSum;
            int random = 0;
            pathHelper(root, random);
            return aresult;
        }
        #endregion
        #endregion
        #region Conclusion
        #region Construct Binary Tree from Inorder and Postorder Traversal
        /*
        Given two integer arrays inorder and postorder where inorder is the inorder traversal of a binary tree and postorder is the postorder traversal of the same tree, construct and return the binary tree.        

            Example 1:

            Input: inorder = [9,3,15,20,7], postorder = [9,15,7,20,3]
            Output: [3,9,20,null,null,15,7]

            Example 2:

            Input: inorder = [-1], postorder = [-1]
            Output: [-1]

            

            Constraints:

            1 <= inorder.length <= 3000
            postorder.length == inorder.length
            -3000 <= inorder[i], postorder[i] <= 3000
            inorder and postorder consist of unique values.
            Each value of postorder also appears in inorder.
            inorder is guaranteed to be the inorder traversal of the tree.
            postorder is guaranteed to be the postorder traversal of the tree.
            Test Cases:
            [9,3,15,20,7]
            [9,15,7,20,3]
            https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
        */
        // public TreeNode BuildTree(int[] inorder, int[] postorder)
        // {
        
        // }
        #endregion

        #endregion

    }
}