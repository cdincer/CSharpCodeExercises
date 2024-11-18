using System;
using System.Collections.Generic;
namespace Tier2
{
    public class Recursion1
    {   //Recursion 1 Card 
        //https://leetcode.com/explore/learn/card/recursion-i/


        //For using with the Swamp Nodes In Pairs
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        //For using with Search In A Binary Tree
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
        #region Recursion 1
        #region Recurrence Relation
        #region Reverse String
        /*
        Write a function that reverses a string. The input string is given as an array of characters s.

        You must do this by modifying the input array in-place with O(1) extra memory.

        Example 1:

        Input: s = ["h","e","l","l","o"]
        Output: ["o","l","l","e","h"]

        Example 2:

        Input: s = ["H","a","n","n","a","h"]
        Output: ["h","a","n","n","a","H"]

        Constraints:

            1 <= s.length <= 105
            s[i] is a printable ascii character.

        Extra Test Case:
        ["A"," ","m","a","n",","," ","a"," ","p","l","a","n",","," ","a"," ","c","a","n","a","l",":"," ","P","a","n","a","m","a"]
        */

        //Official solution locked behind a paywall.
        public void ReverseString(char[] s)
        {
            SwapChar(s, 0);
        }

        private void SwapChar(char[] s, int index)
        {
            if (index >= s.Length)
                return;
            var temp = s[index];
            SwapChar(s, index + 1);
            s[s.Length - 1 - index] = temp;
        }
        #endregion
        #region Swap Nodes In Pairs
        /*
        Given a linked list, swap every two adjacent nodes and return its head.
         You must solve the problem without modifying the values in the list's nodes 
         (i.e., only nodes themselves may be changed.)
        Example 1:

        Input: head = [1,2,3,4]
        Output: [2,1,4,3]

        Example 2:

        Input: head = []
        Output: []

        Example 3:

        Input: head = [1]
        Output: [1]

        Constraints:

            The number of nodes in the list is in the range [0, 100].
            0 <= Node.val <= 100

        https://leetcode.com/problems/swap-nodes-in-pairs/description/
        */
        public ListNode SwapPairs(ListNode first)
        {

            if (first == null || first.next == null) return first;

            var second = first.next;
            first.next = SwapPairs(first.next.next);
            second.next = first;
            return second;

        }
        #endregion
        #region Reverse Linked List
        /*
        Given the head of a singly linked list, reverse the list, and return the reversed list.

        Example 1:

        Input: head = [1,2,3,4,5]
        Output: [5,4,3,2,1]

        Example 2:

        Input: head = [1,2]
        Output: [2,1]

        Example 3:

        Input: head = []
        Output: []

        Constraints:

            The number of nodes in the list is the range [0, 5000].
            -5000 <= Node.val <= 5000

    
        Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?
        https://leetcode.com/problems/reverse-linked-list/
        */

        //Official solution behind paywall
        public ListNode ReverseList(ListNode head)
        {
            return recReverseList(head, null);
        }

        public ListNode recReverseList(ListNode oldhead, ListNode newhead)
        {
            if (oldhead == null)
                return newhead;

            ListNode newNode = new();
            newNode.val = oldhead.val;
            newNode.next = newhead;
            oldhead = oldhead.next;
            return recReverseList(oldhead, newNode);
        }
        #endregion
        #region Search In A Binary Tree
        /*
        You are given the root of a binary search tree (BST) and an integer val.

        Find the node in the BST that the node's value equals val and return the subtree rooted with that node. If such a node does not exist, return null.

        Example 1:

        Input: root = [4,2,7,1,3], val = 2
        Output: [2,1,3]

        Example 2:

        Input: root = [4,2,7,1,3], val = 5
        Output: []

        Constraints:

            The number of nodes in the tree is in the range [1, 5000].
            1 <= Node.val <= 107
            root is a binary search tree.
            1 <= val <= 107

        https://leetcode.com/problems/search-in-a-binary-search-tree/
        */
        //Same as Binary Tree solution no official solution for this one.
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val)
                return root;

            if (root.val < val)
            {
                root = SearchBST(root.right, val);
            }
            else
            {
                root = SearchBST(root.left, val);
            }

            return root;
        }
        #endregion
        #region Pascal's Triangle II
        /*
        Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.
        In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

        Example 1:

        Input: rowIndex = 3
        Output: [1,3,3,1]

        Example 2:

        Input: rowIndex = 0
        Output: [1]

        Example 3:

        Input: rowIndex = 1
        Output: [1,1]


        Constraints:

            0 <= rowIndex <= 33

        Follow up: Could you optimize your algorithm to use only O(rowIndex) extra space?
        https://leetcode.com/problems/pascals-triangle-ii/description/
        */
        //Official solution locked behind a paywall so this will do.
        public IList<int> GetRow(int rowIndex)
        {
            // base case 
            if (rowIndex == 0)
                return new List<int>() { 1 };

            if (rowIndex == 1)
                return new List<int>() { 1, 1 };

            var lastRow = GetRow(rowIndex - 1);

            // current row starts with 1
            List<int> res = new List<int>() { 1 };

            // current row should have 1+lastRow.count
            for (int i = 1; i < lastRow.Count; i++)
            {
                res.Add(lastRow[i - 1] + lastRow[i]);
            }

            // current row ends with 1
            res.Add(1);

            return res;
        }
        #endregion
        #endregion
        #region Memoization 
        #region Fibonacci Number
        /*
        The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such that each number is the sum of the two preceding ones, starting from 0 and 1. That is,
        F(0) = 0, F(1) = 1
        F(n) = F(n - 1) + F(n - 2), for n > 1.

        Given n, calculate F(n).

        Example 1:
        Input: n = 2
        Output: 1
        Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.

        Example 2:
        Input: n = 3
        Output: 2
        Explanation: F(3) = F(2) + F(1) = 1 + 1 = 2.

        Example 3:
        Input: n = 4
        Output: 3
        Explanation: F(4) = F(3) + F(2) = 2 + 1 = 3.

        Constraints:
            0 <= n <= 30

        https://leetcode.com/problems/fibonacci-number/
        */
        //Official solution locked behind a paywall.
        public Dictionary<int, int> memValue = new();
        public int totalAmount = 0;
        public int Fib(int n)
        {
            if (memValue.ContainsKey(n))
            {
                return memValue[n];
            }
            int result = 0;
            if (n < 2)
            {
                result = n;
            }
            else
            {
                result = Fib(n - 1) + Fib(n - 2);
            }

            memValue.Add(n, result);

            return result;
        }
        #endregion
        #region Climbing Stairs
        /*
        You are climbing a staircase. It takes n steps to reach the top.

        Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

        Example 1:

        Input: n = 2
        Output: 2
        Explanation: There are two ways to climb to the top.
        1. 1 step + 1 step
        2. 2 steps

        Example 2:

        Input: n = 3
        Output: 3
        Explanation: There are three ways to climb to the top.
        1. 1 step + 1 step + 1 step
        2. 1 step + 2 steps
        3. 2 steps + 1 step

        Constraints:
            1 <= n <= 45

        https://leetcode.com/problems/climbing-stairs/description/
        
        Hint: Even with recursive/memoization solution TLE.
        Extra Test Case:
        n = 44 21 / 45 testcases passed 
        */

        //Bottom up DP
        public int ClimbStairs(int n)
        {
            if (n <= 2)
            {
                return n;
            }
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        #endregion
        #endregion
        #region Complexity Analysis
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
        int megadepth = 0;
        public int MaxDepth(TreeNode root)
        {
            int depth = 1;

            dfs(root, depth);
            return megadepth;
        }

        public void dfs(TreeNode root, int depth)
        {
            if (root == null)
                return;

            if (depth > megadepth)
                megadepth = depth;

            dfs(root.left, depth + 1);
            dfs(root.right, depth + 1);
        }
        #endregion
        #region Pow(x,n)
        /*
        Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

        Example 1:
        Input: x = 2.00000, n = 10
        Output: 1024.00000

        Example 2:
        Input: x = 2.10000, n = 3
        Output: 9.26100

        Example 3:
        Input: x = 2.00000, n = -2
        Output: 0.25000
        Explanation: 2-2 = 1/22 = 1/4 = 0.25

        Constraints:

            -100.0 < x < 100.0
            -231 <= n <= 231-1
            n is an integer.
            Either x is not zero or n > 0.
            -104 <= xn <= 104


        https://leetcode.com/problems/powx-n/
        Extra test case:
        291th out of 306 test case
        0.00001
        2147483647
        1.00000
        -2147483648
        0.44528
        0
        */
        //No official solution as a result no way to see how Tail Recursion would effect this.
        public double MyPow(double x, int n)
        {
            long N = n;
            if (N == 0) return 1;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }
            return CalculatePow(x, N);
        }
        private double CalculatePow(double x, long n)
        {
            if (n == 1) return x;
            double halfPow = CalculatePow(x, n / 2);
            return n % 2 == 0 ? halfPow * halfPow : halfPow * halfPow * x;
        }
        #endregion
        #endregion
        #region Conclusion
        #region  Merge Two Sorted Lists
        /*
        You are given the heads of two sorted linked lists list1 and list2.
        Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.
        Return the head of the merged linked list.
  
        Example 1:
        Input: list1 = [1,2,4], list2 = [1,3,4]
        Output: [1,1,2,3,4,4]

        Example 2:
        Input: list1 = [], list2 = []
        Output: []

        Example 3:
        Input: list1 = [], list2 = [0]
        Output: [0]

        Constraints:

            The number of nodes in both lists is in the range [0, 50].
            -100 <= Node.val <= 100
            Both list1 and list2 are sorted in non-decreasing order.

        https://leetcode.com/problems/merge-two-sorted-lists/
        */
        //No official solution so stuck with the one below.
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {

            if (list1 == null)
                return list2;

            if (list2 == null)
                return list1;

            ListNode mergehead;

            if (list1.val < list2.val)
            {
                mergehead = list1;
                mergehead.next = MergeTwoLists(list1.next, list2);
            }
            else
            {
                mergehead = list2;
                mergehead.next = MergeTwoLists(list1, list2.next);
            }

            return mergehead;
        }
        #endregion
        #region K-th Symbol in Grammar
        /*
        We build a table of n rows (1-indexed). We start by writing 0 in the 1st row.
        Now in every subsequent row, we look at the previous row and replace each occurrence of 0 with 01, and each occurrence of 1 with 10.
        For example, for n = 3, the 1st row is 0, the 2nd row is 01, and the 3rd row is 0110.
        Given two integer n and k, return the kth (1-indexed) symbol in the nth row of a table of n rows.

        Example 1:

        Input: n = 1, k = 1
        Output: 0
        Explanation: row 1: 0

        Example 2:
        Input: n = 2, k = 1
        Output: 0
        Explanation: 
        row 1: 0
        row 2: 01

        Example 3:
        Input: n = 2, k = 2
        Output: 1
        Explanation: 
        row 1: 0
        row 2: 01

        Constraints:

            1 <= n <= 30
            1 <= k <= 2n - 1

        Extra Test Case:
        30
        434991989
        
        https://leetcode.com/problems/k-th-symbol-in-grammar/
        */
        public int depthFirstSearch(int n, int k, int rootVal)
        {
            if (n == 1)
            {
                return rootVal;
            }

            int totalNodes = (int)Math.Pow(2, n - 1);

            // Target node will be present in the right half sub-tree of the current root node.
            if (k > (totalNodes / 2))
            {
                int nextRootVal = (rootVal == 0) ? 1 : 0;
                return depthFirstSearch(n - 1, k - (totalNodes / 2), nextRootVal);
            }
            // Otherwise, the target node is in the left sub-tree of the current root node.
            else
            {
                int nextRootVal = (rootVal == 0) ? 0 : 1;
                return depthFirstSearch(n - 1, k, nextRootVal);
            }
        }

        public int KthGrammar(int n, int k)
        {
            return depthFirstSearch(n, k, 0);
        }
        #endregion
        #region Unique Binary Search Trees II
        /*
        Given an integer n, return all the structurally unique BST's (binary search trees), which has exactly n nodes of unique values from 1 to n. Return the answer in any order.

        Example 1:
        Input: n = 3
        Output: [[1,null,2,null,3],[1,null,3,2],[2,1,3],[3,1,null,null,2],[3,2,null,1]]

        Example 2:
        Input: n = 1
        Output: [[1]]

        Constraints:

            1 <= n <= 8

        https://leetcode.com/problems/unique-binary-search-trees-ii/description/
        */
        //Official solution below converted from Java.
        public List<TreeNode> allPossibleBST(int start, int end,Dictionary<KeyValuePair<int, int>, List<TreeNode>> memo)
        {
            List<TreeNode> res = new();
            if (start > end)
            {
                res.Add(null);
                return res;
            }
            if (memo.ContainsKey(new KeyValuePair<int, int>(start, end)))
            {
                return memo[new KeyValuePair<int, int>(start, end)];
            }
            // Iterate through all values from start to end to construct left and right subtree recursively.
            for (int i = start; i <= end; ++i)
            {
                List<TreeNode> leftSubTrees = allPossibleBST(start, i - 1, memo);
                List<TreeNode> rightSubTrees = allPossibleBST(i + 1, end, memo);

                // Loop through all left and right subtrees and connect them to ith root.
                foreach (TreeNode left in leftSubTrees)
                {
                    foreach (TreeNode right in rightSubTrees)
                    {
                        TreeNode root = new TreeNode(i, left, right);
                        res.Add(root);
                    }
                }
            }
            memo.Add(new KeyValuePair<int, int>(start, end), res);
            return res;
        }

        public List<TreeNode> GenerateTrees(int n)
        {
            Dictionary<KeyValuePair<int, int>, List<TreeNode>> memo = new();
            return allPossibleBST(1, n, memo);
        }
        #endregion
        #endregion
        #endregion
    }
}
