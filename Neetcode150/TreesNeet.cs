using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neetcode150
{
    public class TreeNeet
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

        #region Invert Binary Tree
        /*
        Given the root of a binary tree, invert the tree, and return its root.

        Example 1:
        Input: root = [4,2,7,1,3,6,9]
        Output: [4,7,2,9,6,3,1]

        Example 2:
        Input: root = [2,1,3]
        Output: [2,3,1]

        Example 3:
        Input: root = []
        Output: []

        Constraints:

            The number of nodes in the tree is in the range [0, 100].
            -100 <= Node.val <= 100

        https://leetcode.com/problems/invert-binary-tree/
        */
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;

            var tmp = root.left;
            root.left = root.right;
            root.right = tmp;

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }
        #endregion
        #region Maximum Depth Of Binary Tree
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

        https://leetcode.com/problems/maximum-depth-of-binary-tree/description/
        */
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
        #endregion
        #region Diameter of Binary Tree
        /*
        Given the root of a binary tree, return the length of the diameter of the tree.
        The diameter of a binary tree is the length of the longest path between any two nodes in a tree. 
        This path may or may not pass through the root.
        The length of a path between two nodes is represented by the number of edges between them.

        Example 1:
        Input: root = [1,2,3,4,5]
        Output: 3
        Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].

        Example 2:
        Input: root = [1,2]
        Output: 1

        Constraints:

            The number of nodes in the tree is in the range [1, 104].
            -100 <= Node.val <= 100

        https://leetcode.com/problems/diameter-of-binary-tree/
        Extra Test Cases: 100 / 105 testcases passed
        [4,-7,-3,null,null,-9,-3,9,-7,-4,null,6,null,-6,-6,null,null,0,6,5,null,9,null,null,-1,-4,null,null,null,-2]
        */
        int _result = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {

            int res = diameter(root);
            return Math.Max(_result, res);
        }
        public int diameter(TreeNode head)
        {
            if (head == null)
                return -1;

            int left = 1 + diameter(head.left);
            int right = 1 + diameter(head.right);
            _result = Math.Max(_result, (left + right));

            return Math.Max(left, right);
        }
        #endregion
        #region Balanced Binary Tree
        /*
        Given a binary tree, determine if it is height-balanced 

        Example 1:
        Input: root = [3,9,20,null,null,15,7]
        Output: true

        Example 2:
        Input: root = [1,2,2,3,3,null,null,4,4]
        Output: false

        Example 3:
        Input: root = []
        Output: true

        Constraints:

            The number of nodes in the tree is in the range [0, 5000].
            -104 <= Node.val <= 104

        https://leetcode.com/problems/balanced-binary-tree/
        */
        bool ultimate = true;
        public bool IsBalanced(TreeNode root)
        {
            tbalance(root);
            return ultimate;
        }

        public int tbalance(TreeNode root)
        {
            if (root == null)
                return -1;

            int left = 1 + tbalance(root.left);
            int right = 1 + tbalance(root.right);

            if (Math.Abs(right - left) > 1)
            {
                ultimate = false;
            }
            return Math.Max(left, right);
        }
        #endregion
        #region Same Tree
        /*
        Given the roots of two binary trees p and q, write a function to check if they are the same or not.
        Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
      
        Example 1:
        Input: p = [1,2,3], q = [1,2,3]
        Output: true

        Example 2:
        Input: p = [1,2], q = [1,null,2]
        Output: false

        Example 3:
        Input: p = [1,2,1], q = [1,1,2]
        Output: false

        Constraints:
            The number of nodes in both trees is in the range [0, 100].
            -104 <= Node.val <= 104

        https://leetcode.com/problems/same-tree/
        */
        bool _result2 = true;
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            issame(p, q);
            return _result2;
        }
        public void issame(TreeNode node1, TreeNode node2)
        {

            if (node1 == null && node2 == null)
            {
                return;
            }
            else if (node1 == null || node2 == null)
            {
                _result2 = false;
                return;
            }

            if (node1.val != node2.val)
            {
                _result2 = false;
                return;
            }

            issame(node1.left, node2.left);
            issame(node1.right, node2.right);
        }
        #endregion
        #region Subtree of Another Tree
        /*
        Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.
        A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.

        Example 1:
        Input: root = [3,4,5,1,2], subRoot = [4,1,2]
        Output: true

        Example 2:
        Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
        Output: false

        Constraints:
            The number of nodes in the root tree is in the range [1, 2000].
            The number of nodes in the subRoot tree is in the range [1, 1000].

        https://leetcode.com/problems/subtree-of-another-tree/
        Extra Test Cases: 110 / 182 testcases passed
        root =[1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,2]
        subRoot= [1,null,1,null,1,null,1,null,1,null,1,2]
        */
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null) return root == subRoot;
            if (root.val == subRoot?.val && IsSameTree2(root, subRoot)) return true;

            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }

        public bool IsSameTree2(TreeNode p, TreeNode q)
        {
            if (p == null || q == null) return p == q;

            return p.val == q.val
                && IsSameTree2(p.left, q.left)
                && IsSameTree2(p.right, q.right);
        }
        #endregion
        #region Lowest Common Ancestor of a Binary Search Tree
        /*
        Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST.
        According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”

        Example 1:
        Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
        Output: 6
        Explanation: The LCA of nodes 2 and 8 is 6.

        Example 2:
        Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
        Output: 2
        Explanation: The LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.

        Example 3:
        Input: root = [2,1], p = 2, q = 1
        Output: 2

        Constraints:

            The number of nodes in the tree is in the range [2, 105].
            -109 <= Node.val <= 109
            All Node.val are unique.
            p != q
            p and q will exist in the BST.

        https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
        */
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // Traverse Right child
            if (p.val > root.val && q.val > root.val)
            {
                return LowestCommonAncestor(root.right, p, q);
            }

            // Traverse Left Child
            if (p.val < root.val && q.val < root.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }

            return root;
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

            Queue<TreeNode> myq = new();
            List<IList<int>> results = new();

            if (root == null)
                return results;

            myq.Enqueue(root);

            while (myq.Count > 0)
            {

                int Set = myq.Count;
                List<int> fresh = new();
                while (Set > 0)
                {
                    TreeNode start = myq.Dequeue();

                    if (start.left != null)
                        myq.Enqueue(start.left);

                    if (start.right != null)
                        myq.Enqueue(start.right);

                    fresh.Add(start.val);
                    Set--;
                }
                results.Add(fresh);
            }

            return results;

        }
        #endregion
        #region Binary Tree Right Side View
        /*
        Given the root of a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.

        Example 1:
        Input: root = [1,2,3,null,5,null,4]
        Output: [1,3,4]

        Example 2:
        Input: root = [1,null,3]
        Output: [1,3]

        Example 3:
        Input: root = []
        Output: []

        Constraints:

            The number of nodes in the tree is in the range [0, 100].
            -100 <= Node.val <= 100

        https://leetcode.com/problems/binary-tree-right-side-view/
        */
        //Both solutions run times are really close same with memory.
        List<int> results = new();
        Dictionary<int, int> answer = new();

        public IList<int> RightSideView(TreeNode root)
        {
            Dictionary<int, int> depth = new();

            int counter = 1;
            TreeNode copy = root;

            if (root == null)
                return results;

            while (root != null)
            {
                depth.Add(counter, root.val);
                root = root.right;
                counter++;
            }

            dfs(0, copy);

            for (int i = 1; i <= depth.Count; i++)
            {
                results.Add(depth[i]);
            }

            for (int j = depth.Count; j < answer.Count; j++)
            {
                results.Add(answer[j]);
            }
            return results;
        }

        public void dfs(int dc, TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            // Visit the root first, then the left subtree, then the right subtree.
            dfs(dc + 1, node.left);
            answer[dc] = node.val;
            dfs(dc + 1, node.right);
        }


        private List<int> _result3 = new();

        public IList<int> RightSideViewNeet(TreeNode root)
        {
            DfsNeet(root, 0);
            return _result3;
        }

        private void DfsNeet(TreeNode root, int level)
        {
            if (root == null) return;
            if (level >= _result3.Count) _result3.Add(root.val);

            // At first visit right node
            DfsNeet(root.right, level + 1);
            DfsNeet(root.left, level + 1);
        }
        #endregion
        #region Count Good Nodes in Binary Tree
        /*
        Given a binary tree root, a node X in the tree is named good if in the path from root to X there are no nodes with a value greater than X.
        Return the number of good nodes in the binary tree.

        Example 1:
        Input: root = [3,1,4,3,null,1,5]
        Output: 4
        Explanation: Nodes in blue are good.
        Root Node (3) is always a good node.
        Node 4 -> (3,4) is the maximum value in the path starting from the root.
        Node 5 -> (3,4,5) is the maximum value in the path
        Node 3 -> (3,1,3) is the maximum value in the path.

        Example 2:
        Input: root = [3,3,null,4,2]
        Output: 3
        Explanation: Node 2 -> (3, 3, 2) is not good, because "3" is higher than it.

        Example 3:
        Input: root = [1]
        Output: 1
        Explanation: Root is considered as good.

        Constraints:

            The number of nodes in the binary tree is in the range [1, 10^5].
            Each node's value is between [-10^4, 10^4].

        https://leetcode.com/problems/count-good-nodes-in-binary-tree/
        Extra Test Case: 10 / 63 testcases passed
        [9,null,3,6]
        */
        int answer2 = 0;
        public int GoodNodes(TreeNode root)
        {

            if (root.left == null && root.right == null)
                return 1;

            counter(root, root.val);

            return answer2;
        }

        public int counter(TreeNode head, int max)
        {
            if (head == null)
                return 0;


            if (head.val >= max)
            {
                answer2++;
                max = head.val;
            }
            counter(head.left, max);
            counter(head.right, max);

            return 0;
        }
        #endregion
        #region Validate Binary Search Tree
        /*

        https://leetcode.com/problems/validate-binary-search-tree/

        Extra Test Cases:(All real test cases)
        [2,1,3]
        [5,1,4,null,null,3,6]
        [2,2,2]
        [0]
        [1,null,1]
        [5,4,6,null,null,3,7]
        [0,null,1]
        [3,1,5,0,2,4,6,null,null,null,3]
        [3,1,5,0,2,4,6]
        [24,-60,null,-60,-6]
        [-2147483648,null,2147483647,-2147483648]
        [5,4,6,null,null,3,7] 76 / 84 test cases passed 
        */
        public bool IsValidBST(TreeNode root)
        {
            return splitter(root.left, null, root.val) && splitter(root.right, root.val, null);
        }
        public bool splitter(TreeNode root, int? left, int? right)
        {
            if (root == null) return true;

            if ((left != null && root.val <= left) ||
               (right != null && root.val >= right))
                return false;

            return splitter(root.left, left, root.val) &&
                splitter(root.right, root.val, right);
        }
        #endregion
    }
}