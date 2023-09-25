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

    }
}
