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
        Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
        In other words, return true if one of s1's permutations is the substring of s2.

        Example 1:

        Input: s1 = "ab", s2 = "eidbaooo"
        Output: true
        Explanation: s2 contains one permutation of s1 ("ba").

        Example 2:
        Input: s1 = "ab", s2 = "eidboaoo"
        Output: false

        Constraints:
            1 <= s1.length, s2.length <= 104
            s1 and s2 consist of lowercase English letters.

        https://leetcode.com/problems/permutation-in-string/
        Extra Test Case:
        s1:"zxcvzxcvzxcvzxcvmraodapsadf"
        s2:"roadmap"
        s1:"hello"
        s2:"ooolleoooleh"
        s1:"ab"
        s2:"a"
        */

        public bool CheckInclusion(string s1, string s2)
        {
            int[] keep1 = new int[26];
            int[] keep2 = new int[26];
            if (s1.Length > s2.Length) return false;
            for (int i = 0; i < s1.Length; i++)
            {
                keep1[s1[i] - 'a']++;
                keep2[s2[i] - 'a']++;
            }

            int matches = 0;

            for (int i = 0; i < keep1.Length; i++)
            {
                if (keep1[i] == keep2[i])
                {
                    matches++;
                }
            }

            int left = 0;
            for (int right = s1.Length; right < s2.Length; right++)
            {
                int arrc = s2[right] - 'a';
                if (matches == 26)
                    return true;

                keep2[arrc]++;

                if (keep1[arrc] == keep2[arrc])
                {
                    matches++;
                }
                else if (keep1[arrc] + 1 == keep2[arrc])
                {
                    matches--;
                }
                arrc = s2[left] - 'a';
                keep2[arrc]--;
                if (keep1[arrc] == keep2[arrc])
                {
                    matches++;
                }
                else if (keep1[arrc] - 1 == keep2[arrc])
                {
                    matches--;
                }
                left++;
            }
            return matches == 26;
        }


        #endregion
        #region Minimum Window Substring
        /*
        Given two strings s and t of lengths m and n respectively, return the minimum window
        substring of s such that every character in t (including duplicates) is included in the window. 
        If there is no such substring, return the empty string "".

        The testcases will be generated such that the answer is unique.

        Example 1:
        Input: s = "ADOBECODEBANC", t = "ABC"
        Output: "BANC"
        Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.

        Example 2:
        Input: s = "a", t = "a"
        Output: "a"
        Explanation: The entire string s is the minimum window.

        Example 3:
        Input: s = "a", t = "aa"
        Output: ""
        Explanation: Both 'a's from t must be included in the window.
        Since the largest window of s only has one 'a', return empty string.

        Constraints:
            m == s.length
            n == t.length
            1 <= m, n <= 105
            s and t consist of uppercase and lowercase English letters.

        Follow up: Could you find an algorithm that runs in O(m + n) time?
        Extra Test Cases:
        s="aaaaaaaaaaaabbbbbcdd" 187 / 267 testcases passed
        t="abcdd"
        https://leetcode.com/problems/minimum-window-substring
        */
        public string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(t)) return string.Empty;

            var countT = new Dictionary<char, int>();
            var window = new Dictionary<char, int>();

            foreach (var c in t)
            {
                AddCharToDictionary(c, countT);
            }

            var have = 0;
            var need = countT.Count;
            var left = 0;
            var res = new[] { -1, -1 };
            var resultLength = int.MaxValue;
            for (var right = 0; right < s.Length; right++)
            {
                var c = s[right];
                AddCharToDictionary(c, window);

                if (countT.ContainsKey(c) && window[c] == countT[c]) have++;

                while (have == need)
                {
                    // update our result
                    var windowSize = right - left + 1;
                    if (windowSize < resultLength)
                    {
                        res = new[] { left, right };
                        resultLength = windowSize;
                    }

                    // pop from the left of our window
                    window[s[left]]--;
                    if (countT.ContainsKey(s[left]) && window[s[left]] < countT[s[left]])
                    {
                        have--;
                    }

                    left++;
                }
            }

            return resultLength == int.MaxValue
               ? string.Empty
               : s.Substring(res[0], res[1] - res[0] + 1);
        }

        private void AddCharToDictionary(char c, IDictionary<char, int> dict)
        {
            if (dict.ContainsKey(c)) dict[c]++;
            else dict.Add(c, 1);
        }
        #endregion
    }

}
