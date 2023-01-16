using System;
using System.Collections.Generic;
namespace Tier1
{
    public class Recursion1
    {   //Recursion 1 Card 
        //https://leetcode.com/explore/learn/card/recursion-i/

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


        */
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
    }
}
