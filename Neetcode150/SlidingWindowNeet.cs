using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Neetcode150
{
    public class SlidingWindowNeet
    {
        #region Best Time to Buy and Sell Stock
        /*
        You are given an array prices where prices[i] is the price of a given stock on the ith day.
        You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
        Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.

        Constraints:

            1 <= prices.length <= 105
            0 <= prices[i] <= 104

        https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        Extra Test Cases:
        [2,1,2,1,0,1,2]
        */
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            int minPrice = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                int currPrice = prices[i];
                minPrice = Math.Min(minPrice, currPrice);
                maxProfit = Math.Max(maxProfit, currPrice - minPrice);
            }
            return maxProfit;
        }

        #endregion
        #region Longest Substring Without Repeating Characters
        /*
        Given a string s, find the length of the longest
        substring
        without repeating characters.

    
        Example 1:
        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3.

        Example 2:
        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.

        Example 3:
        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

        Constraints:

            0 <= s.length <= 5 * 104
            s consists of English letters, digits, symbols and spaces.

        https://leetcode.com/problems/longest-substring-without-repeating-characters/
        */
        public int LengthOfLongestSubstring(string s)
        {
            int start = 0;
            int end = 0;
            int longest = 0;
            int currlength = 0;

            if (s.Length == 0 || s.Length == 1)
                return s.Length;

            while (end < s.Length)
            {
                currlength = 1;

                for (int i = start; i < end; i++)
                {
                    if (s[i] == s[end])
                    {
                        start = i + 1;
                        longest = Math.Max(longest, currlength);
                        currlength = 1;
                        break;
                    }
                    else
                    {
                        currlength++;
                    }
                }
                end++;
                longest = Math.Max(longest, currlength);
            }
            return longest;
        }
        #endregion
        #region Longest Repeating Character Replacement
        /*
        https://leetcode.com/problems/longest-repeating-character-replacement/
        Extra Test Cases:
        "BAAA"  10 / 41 testcases passed
        0
        "BAAAB" 18 / 41 testcases passed
        2
        "AABA" 19 / 41 testcase passed
        0
        "AAAA" 20 / 41 testcases passed
        2
        */
        public int CharacterReplacement(string s, int k)
        {
            int left = 0, maxLength = 0;
            int mostFrequentLetterCount = 0; // Count of most frequent letter in the window
            int[] charCounts = new int[26]; // Counts per letter

            for (int right = 0; right < s.Length; right++)
            {
                charCounts[s[right] - 'A']++;
                mostFrequentLetterCount = Math.Max(mostFrequentLetterCount, charCounts[s[right] - 'A']);

                int lettersToChange = (right - left + 1) - mostFrequentLetterCount;
                if (lettersToChange > k)
                { // Window is invalid, decrease char count and move left pointer
                    charCounts[s[left] - 'A']--;
                    left++;
                }

                maxLength = Math.Max(maxLength, (right - left + 1));
            }
            return maxLength;
        }
        #endregion
        #region Permutation in String
        /*
        https://leetcode.com/problems/permutation-in-string/
        */
        public bool CheckInclusion(string s1, string s2)
        {
            int start = 0;
            int end = 0;
            if (s1.Length > s2.Length)
            {
                string temp = s1;
                s1 = s2;
                s2 = temp;
            }
            char[] ts = s1.ToCharArray();

            while (end < s2.Length)
            {
                int letcounter = 0;
                for (int i = start; i < end; i++)
                {
                    if (comparer(s2[i], ts))
                    {
                        letcounter++;
                        if (letcounter == ts.Length)
                            return true;
                    }
                    else
                    {
                        start++;
                    }
                }
                end++;
            }
            return false;
        }


        public bool comparer(char cheked, char[] chekee)
        {
            for (int j = 0; j < chekee.Length; j++)
            {
                if (cheked == chekee[j])
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

    }

}
