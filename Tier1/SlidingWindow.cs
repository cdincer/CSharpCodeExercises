using System;

namespace Tier1
{
    public class SlidingWindow
    {

        /*
        Questions related to Sliding Window:
        https://leetcode.com/problems/count-complete-subarrays-in-an-array/description/
        */

        /*
        Given a string s, find the length of the longest substring without repeating characters.
        *Example 1
        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3.
        *Example 2
        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.
        *Example 3:
        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
        https://leetcode.com/problems/longest-substring-without-repeating-characters/
        */
        public int SlidingWindowOriginal(string s)
        {
            int beginWindow = 0;
            int endWindow = 0;
            int length = 1;

            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            if (s.Length > 1)
            {
                int currentLength = 1;
                while (endWindow < s.Length)
                {
                    for (int currentIndex = beginWindow; currentIndex < endWindow; currentIndex++)
                    {
                        if (s[currentIndex] == s[endWindow])
                        {
                            beginWindow = currentIndex + 1;
                            currentLength = 1;
                            break;
                        }
                        else
                        {
                            currentLength++;
                        }
                    }
                    if (currentLength > length)
                    {
                        length = currentLength;
                    }
                    endWindow++;
                    currentLength = 1;
                }
            }

            return length;
        }
    }
}