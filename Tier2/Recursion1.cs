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
        */
        //No official solution but even the question hint was basically fibonacci number so adapted that.
        Dictionary<int, int> memValue2 = new();
        public int ClimbStairs(int n)
        {

            if (memValue2.ContainsKey(n))
            {
                return memValue2[n];
            }
            int result = 0;

            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                result = ClimbStairs(n - 1) + ClimbStairs(n - 2);
            }

            memValue2.Add(n, result);
            return memValue2[n];
        }
        #endregion
        #endregion
        #endregion
    }
}
