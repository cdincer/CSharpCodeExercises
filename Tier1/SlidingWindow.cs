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


        #region Maximum Subarray
        /*
        Given an integer array nums, find the
        subarray
        with the largest sum, and return its sum.

        Example 1:
        Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        Output: 6
        Explanation: The subarray [4,-1,2,1] has the largest sum 6.

        Example 2:
        Input: nums = [1]
        Output: 1
        Explanation: The subarray [1] has the largest sum 1.

        Example 3:
        Input: nums = [5,4,-1,7,8]
        Output: 23
        Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.

        Constraints:

            1 <= nums.length <= 105
            -104 <= nums[i] <= 104

        

        Follow up: If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.

        https://leetcode.com/problems/maximum-subarray/
        Extra Test Case:
        [-1]
        205th case is in submission to big to copy here.
        */
        public int MaxSubArray(int[] nums)
        {
            int currMax = 0;
            int ourMax = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                currMax = currMax + nums[i];
                if (currMax > ourMax)
                {
                    ourMax = currMax;
                }

                if (currMax < 0)
                {
                    currMax = 0;
                }
            }

            return ourMax;
        }
        #endregion

    }
}