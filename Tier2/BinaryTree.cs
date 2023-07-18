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
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {//numbers[^1] is the same with numbers[length-1]
         //https://learn.microsoft.com/en-us/dotnet/api/system.span-1?view=net-7.0
            TreeNode? Build(Span<int> inorder, Span<int> postorder)
            {
                if (postorder.IsEmpty || inorder.IsEmpty)
                {
                    return null;
                }

                var pos = inorder.IndexOf(postorder[^1]);
                return new TreeNode(postorder[^1])
                {
                    left = Build(inorder[..pos], postorder[..pos]),
                    right = Build(inorder[(pos + 1)..], postorder[pos..^1])
                };
            }

            return Build(inorder, postorder);
        }
        #endregion
        #region Construct Binary Tree from Preorder and Inorder Traversal
        /*
        Given two integer arrays preorder and inorder where preorder is the preorder traversal of a binary tree and inorder is the inorder traversal of the same tree, construct and return the binary tree.

        Example 1:

        Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
        Output: [3,9,20,null,null,15,7]

        Example 2:

        Input: preorder = [-1], inorder = [-1]
        Output: [-1]

        Constraints:

            1 <= preorder.length <= 3000
            inorder.length == preorder.length
            -3000 <= preorder[i], inorder[i] <= 3000
            preorder and inorder consist of unique values.
            Each value of inorder also appears in preorder.
            preorder is guaranteed to be the preorder traversal of the tree.
            inorder is guaranteed to be the inorder traversal of the tree.


        https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/description/
        Influenced by Inorder and Postorder binary tree build code changing execution order and limit spans.
        */

        public TreeNode BuildTree2(int[] preorder, int[] inorder)
        {

            TreeNode? Build(Span<int> preorder, Span<int> inorder)
            {
                if (preorder.IsEmpty || inorder.IsEmpty)
                {
                    return null;
                }

                var pos = inorder.IndexOf(preorder[0]);
                return new TreeNode(preorder[0])
                {
                    left = Build(preorder[1..(pos + 1)], inorder[..(pos)]),
                    right = Build(preorder[(pos + 1)..], inorder[(pos + 1)..])
                };
            }

            return Build(preorder, inorder);
        }
        #endregion
        #region Populating Next Right Pointers in Each Node
        /*
        You are given a perfect binary tree where all leaves are on the same level, and every parent has two children. The binary tree has the following definition:

        struct Node {
        int val;
        Node *left;
        Node *right;
        Node *next;
        }

        Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

        Initially, all next pointers are set to NULL.

        

        Example 1:

        Input: root = [1,2,3,4,5,6,7]
        Output: [1,#,2,3,#,4,5,6,7,#]
        Explanation: Given the above perfect binary tree (Figure A), your function should populate each next pointer to point to its next right node, just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.

        Example 2:

        Input: root = []
        Output: []

        

        Constraints:

        The number of nodes in the tree is in the range [0, 212 - 1].
        -1000 <= Node.val <= 1000
        https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
        */

        /*
        You are given a perfect binary tree where all leaves are on the same level, and every parent has two children. The binary tree has the following definition:

        struct Node {
        int val;
        Node *left;
        Node *right;
        Node *next;
        }

        Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

        Initially, all next pointers are set to NULL.

        

        Example 1:

        Input: root = [1,2,3,4,5,6,7]
        Output: [1,#,2,3,#,4,5,6,7,#]
        Explanation: Given the above perfect binary tree (Figure A), your function should populate each next pointer to point to its next right node, just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.

        Example 2:

        Input: root = []
        Output: []

        https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
        */
        public class Node2
        {
            public int val;
            public Node2 left;
            public Node2 right;
            public Node2 next;

            public Node2() { }

            public Node2(int _val)
            {
                val = _val;
            }

            public Node2(int _val, Node2 _left, Node2 _right, Node2 _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
        //Custom solution
        public Node2 Connect(Node2 root)
        {
            IList<IList<Node2>> results = new List<IList<Node2>>();
            if (root == null)
                return root;


            Queue<Node2> mes = new Queue<Node2>();
            mes.Enqueue(root);


            while (mes.Count > 0)
            {
                List<Node2> res = new List<Node2>();
                int counter = mes.Count();
                for (int i = 0; i < counter; i++)
                {
                    Node2 curr = mes.Peek();
                    mes.Dequeue();

                    if (curr.left != null)
                        mes.Enqueue(curr.left);

                    if (curr.right != null)
                        mes.Enqueue(curr.right);

                    res.Add(curr);
                }
                results.Add(res);
            }


            foreach (List<Node2> item in results)
            {
                Node2 connect = item.First();
                item.Remove(connect);
                foreach (Node2 link in item)
                {
                    connect.next = link;
                    connect = link;
                }

            }

            Node2 member = root;

            return member;
        }

        //Simplified version of my traversal solution.
        public Node2 Connect2(Node2 root)
        {
            if (root == null)
                return null;

            Queue<Node2> q = new Queue<Node2>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                int count = q.Count;
                Node2 prev = null;

                for (int i = 0; i < count; i++)
                {
                    Node2 node = q.Dequeue();

                    if (prev != null)
                        prev.next = node;

                    prev = node;

                    if (node.left != null)
                        q.Enqueue(node.left);

                    if (node.right != null)
                        q.Enqueue(node.right);
                }
            }

            return root;

        }

        #endregion
        #region Populating Next Right Pointers in Each Node II
        /*
        Given a binary tree

        struct Node {
        int val;
        Node *left;
        Node *right;
        Node *next;
        }

        Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

        Initially, all next pointers are set to NULL.

        

        Example 1:

        Input: root = [1,2,3,4,5,null,7]
        Output: [1,#,2,3,#,4,5,7,#]
        Explanation: Given the above binary tree (Figure A), your function should populate each next pointer to point to its next right node, just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.

        Example 2:

        Input: root = []
        Output: []

        

        Constraints:

            The number of nodes in the tree is in the range [0, 6000].
            -100 <= Node.val <= 100

        

        Follow-up:

            You may only use constant extra space.
            The recursive approach is fine. You may assume implicit stack space does not count as extra space for this problem.


        https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/description/
        
        Same solution as above,just with non-perfect binary tree.
        */
        public Node2 Connect3(Node2 root)
        {
            IList<IList<Node2>> results = new List<IList<Node2>>();
            if (root == null)
                return root;


            Queue<Node2> mes = new Queue<Node2>();
            mes.Enqueue(root);


            while (mes.Count > 0)
            {
                List<Node2> res = new List<Node2>();
                int counter = mes.Count();
                for (int i = 0; i < counter; i++)
                {
                    Node2 curr = mes.Peek();
                    mes.Dequeue();

                    if (curr.left != null)
                        mes.Enqueue(curr.left);

                    if (curr.right != null)
                        mes.Enqueue(curr.right);

                    res.Add(curr);
                }
                results.Add(res);
            }


            foreach (List<Node2> item in results)
            {
                Node2 connect = item.First();
                item.Remove(connect);
                foreach (Node2 link in item)
                {
                    connect.next = link;
                    connect = link;
                }

            }

            Node2 member = root;

            return member;
        }
        #endregion
        #region Lowest Common Ancestor of a Binary Tree
        /*
        Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

        According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”


        Example 1:

        Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
        Output: 3
        Explanation: The LCA of nodes 5 and 1 is 3.

        Example 2:

        Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
        Output: 5
        Explanation: The LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.

        Example 3:

        Input: root = [1,2], p = 1, q = 2
        Output: 1

        

        Constraints:

            The number of nodes in the tree is in the range [2, 105].
            -109 <= Node.val <= 109
            All Node.val are unique.
            p != q
            p and q will exist in the tree.


        https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
        Test Case:
        [3,5,1,6,2,0,8,null,null,7,4]
        5
        4
        */
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
            {
                return root;
            }
            else if (left != null)
            {
                return left;
            }
            else
            {
                return right;
            }
        }
        #endregion
        #region Serialize and Deserialize Binary Tree
        /*
        Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

        Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

        Clarification: The input/output format is the same as how LeetCode serializes a binary tree(*). You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.
        *https://support.leetcode.com/hc/en-us/articles/360011883654-What-does-1-null-2-3-mean-in-binary-tree-representation-
        

        Example 1:

        Input: root = [1,2,3,null,null,4,5]
        Output: [1,2,3,null,null,4,5]

        Example 2:

        Input: root = []
        Output: []

        

        Constraints:

            The number of nodes in the tree is in the range [0, 104].
            -1000 <= Node.val <= 1000


        https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
        */
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return "null";
            return root.val + " " + serialize(root.left) + " " + serialize(root.right);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            List<TreeNode> list = new List<TreeNode>();

            if (data == "null") return null;

            string[] words = data.Split(' ');
            TreeNode root = new TreeNode(Convert.ToInt32(words[0]));
            list.Add(root);

            bool goLeft = true;
            for (int i = 1; i < words.Count(); ++i)
            {
                if (words[i] == "null")
                {
                    if (goLeft) goLeft = false;
                    else list.RemoveAt(list.Count() - 1);
                }
                else
                {
                    TreeNode node = new TreeNode(Convert.ToInt32(words[i]));
                    if (goLeft)
                    {
                        list[list.Count() - 1].left = node;
                    }
                    else
                    {
                        list[list.Count() - 1].right = node;
                        list.RemoveAt(list.Count() - 1);
                    }
                    list.Add(node);
                    goLeft = true;
                }
            }

            return root;
        }
        #endregion
        #endregion

    }
}