using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Xml.Linq;

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
            int maxP = 0;
            int minBuy = prices[0];

            foreach (int sell in prices)
            {
                maxP = Math.Max(maxP, sell - minBuy);
                minBuy = Math.Min(minBuy, sell);
            }
            return maxP;
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
        Extra Test Cases:
        "dvdf"
        "aab"
        "jbpnbwwd"
        " "
        "  "
        https://leetcode.com/problems/longest-substring-without-repeating-characters/
        */
        public int LengthOfLongestSubstring(string s)
        {
            int start = 0;
            int end = 0;
            int longest = 0;
            int currLength = 0;

            if (s.Length == 0 || s.Length == 1)
                return s.Length;

            while (end < s.Length)
            {
                currLength = 1;

                for (int i = start; i < end; i++)
                {
                    if (s[i] == s[end])
                    {
                        start = i + 1;
                        longest = Math.Max(longest, currLength);
                        currLength = 1;
                        break;
                    }
                    else
                    {
                        currLength++;
                    }
                }
                end++;
                longest = Math.Max(longest, currLength);
            }
            return longest;
        }
        public int LengthOfLongestSubstringNeet(string s)
        {
            int leftPointer = 0, rightPointer = 0, maxLength = 0;
            HashSet<int> chars = new HashSet<int>();

            while (rightPointer < s.Length)
            {
                char currChar = s[rightPointer];
                if (chars.Contains(currChar))
                { // Move left pointer until all duplicate chars removed
                    chars.Remove(s[leftPointer]);
                    leftPointer++;
                }
                else
                {
                    chars.Add(currChar);
                    maxLength = Math.Max(maxLength, rightPointer - leftPointer + 1);
                    rightPointer++;
                }
            }
            return maxLength;
        }
        #endregion
        #region Longest Repeating Character Replacement
        /*
        https://leetcode.com/problems/longest-repeating-character-replacement/
        Extra Test Cases:
        "BAAA" k = 0 10 / 41 testcases passed
        "BAAAB" k = 2 18 / 41 testcases passed
        "AABA" k = 0 19 / 41 testcase passed
        "AAAA" k = 2 20 / 41 testcases passed
        "IMNJJTRMJEGMSOLSCCQICIHLQIOGBJAEHQOCRAJQMBIBATGLJDTBNCPIFRDLRIJHRABBJGQAOLIKRLHDRIGERENNMJSDSSMESSTR" k = 2 25 / 41 testcases passed
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
        s1:"adc"
        s2:"dcda"
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
        s="a" 163 / 267 testcases passed
        t="b"
        https://leetcode.com/problems/minimum-window-substring
        */

        public string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(t)) return string.Empty;

            Dictionary<char, int> countT = new();
            Dictionary<char, int> window = new();

            foreach (char c in t)
            {
                countT.TryAdd(c, 0);
                countT[c] += 1;
            }

            int have = 0;
            int need = countT.Count;
            int left = 0;
            int[] res = new int[] { -1, 1 };
            int resultLength = int.MaxValue;
            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];
                window.TryAdd(c, 0);
                window[c] += 1;

                if (countT.TryGetValue(c, out _) && window[c] == countT[c]) have++;

                while (have == need)
                {
                    // update our result
                    int windowSize = right - left + 1;
                    if (windowSize < resultLength)
                    {
                        res = new[] { left, right };
                        resultLength = windowSize;
                    }

                    // pop from the left of our window
                    window[s[left]]--;
                    if (countT.TryGetValue(s[left], out _) && window[s[left]] < countT[s[left]])
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

        #endregion
        #region Sliding Window Maximum
        /*
        You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right.
        You can only see the k numbers in the window. Each time the sliding window moves right by one position.Return the max sliding window.

        Example 1:

        Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
        Output: [3,3,5,5,6,7]
        Explanation: 
        Window position                Max
        ---------------               -----
        [1  3  -1] -3  5  3  6  7       3
        1 [3  -1  -3] 5  3  6  7       3
        1  3 [-1  -3  5] 3  6  7       5
        1  3  -1 [-3  5  3] 6  7       5
        1  3  -1  -3 [5  3  6] 7       6
        1  3  -1  -3  5 [3  6  7]      7

        Example 2:
        Input: nums = [1], k = 1
        Output: [1]

        Constraints:

        1 <= nums.length <= 105
        -104 <= nums[i] <= 104
        1 <= k <= nums.length
        Extra Random Test Cases:
        [41,8467,6334,6500,9169,5724,1478,9358,6962,4464,5705,8145,3281,6827,9961,491,2995,1942,4827,5436,2391,4604,3902,153,292,2382,7421,8716,9718,9895,5447,1726,4771,1538,1869,9912,5667,6299,7035,9894,8703,3811,1322,333,7673,4664,5141,7711,8253,686]
        4
        [8,5547,7644,2662,2757,37,2859,8723,9741,7529,778,2316,3035,2190,1842,288,106,9040,8942,9264,2648,7446,3805,5890,6729,4370,5350,5006,1101,4393,3548,9629,2623,4084,9954,8756,1840,4966,7376,3931,6308,6944,2439,4626,1323,5537,1538,6118,2082,2929,6541,4833,1115,4639,9658,2704,9930,3977,2306,1673,2386,5021,8745,6924,9072,6270,5829,6777,5573,5097,6512,3986,3290,9161,8636,2355,4767,3655,5574,4031,2052]
        10
        nums = [7,2,4]  k = 2 Expected = [7,4] 21 / 51 testcase
        46 / 51 testcase requires more optimization than 37th. Both of them can show if your code is fast enough.
        Together they cause a TLE,20th Of September 2024
        
        These two cases can be found in submissions tab, they are both TLE
        */
        public int[] MaxSlidingWindow(int[] nums, int k)
        {

            var output = new List<int>();
            LinkedList<int> queue = new();
            int left = 0, right = 0;

            while (right < nums.Length)
            {
                // pop smaller values from queue
                while (queue.Count > 0 && nums[queue.Last.Value] < nums[right])
                    queue.RemoveLast();
                queue.AddLast(right);

                // remove left val from the window
                if (left > queue.First.Value)
                    queue.RemoveFirst();

                if (right + 1 >= k)
                {
                    output.Add(nums[queue.First.Value]);
                    left++;
                }

                right++;
            }

            return output.ToArray();
        }
        #endregion
    }
}
