using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Neetcode150
{
    public class TwoPointers
    {
        #region Valid Palindrome
        /*
        A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
        Given a string s, return true if it is a palindrome, or false otherwise.

        Example 1:
        Input: s = "A man, a plan, a canal: Panama"
        Output: true
        Explanation: "amanaplanacanalpanama" is a palindrome.

        Example 2:
        Input: s = "race a car"
        Output: false
        Explanation: "raceacar" is not a palindrome.

        Example 3:
        Input: s = " "
        Output: true
        Explanation: s is an empty string "" after removing non-alphanumeric characters.
        Since an empty string reads the same forward and backward, it is a palindrome.

        Constraints:

            1 <= s.length <= 2 * 105
            s consists only of printable ASCII characters.

        https://leetcode.com/problems/valid-palindrome/
        */
        //Extra Test Case
        //"0P" 462/485
        //On average my code and neetcode's are equal in runtime, same with memory.
        public bool IsPalindrome(string s)
        {
            StringBuilder myreader = new();

            for (int i = 0; i < s.Length; i++)
            {
                char converted = Char.ToLower(s[i]);
                if (Char.IsLetter(converted) || Char.IsNumber(converted))
                {
                    myreader.Append(converted);
                }
            }

            string myprocessed = myreader.ToString();
            int end = myprocessed.Length - 1;

            for (int i = 0; i < myprocessed.Length; i++)
            {
                if (myprocessed[i] != myprocessed[end - i])
                    return false;
            }

            return true;
        }

        public bool IsPalindromeNeet(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (!char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                else if (!char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                else
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }
                    left++;
                    right--;
                }
            }
            return true;
        }
        #endregion
        #region Two Sum II - Input Array Is Sorted
        /**/
        #endregion
    }
}