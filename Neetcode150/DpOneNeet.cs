using System;
using System.Collections.Generic;

namespace Neetcode150
{
    public class DpOneNeet
    {
        #region House Robber
        /*
        You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, 
        the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected 
        and it will automatically contact the police if two adjacent houses were broken into on the same night.
        Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

        Example 1:
        Input: nums = [1,2,3,1]
        Output: 4
        Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
        Total amount you can rob = 1 + 3 = 4.

        Example 2:
        Input: nums = [2,7,9,3,1]
        Output: 12
        Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
        Total amount you can rob = 2 + 9 + 1 = 12.

        Constraints:

            1 <= nums.length <= 100
            0 <= nums[i] <= 400

        https://leetcode.com/problems/house-robber/
        Test Cases:
        [2,1,1,2] 40 / 70 testcases passed
        */
        //For around 400 variables. The memory usage difference between these two are as follows: DP array store: 40.09MB Neetcode 2 variable store : 39.99MB
        public int Rob(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            if (nums.Length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }

            var dp = new Dictionary<int, int>();
            dp[0] = nums[0];
            dp[1] = nums[1];
            dp[2] = nums[2] + nums[0];

            for (int i = 3; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 2], dp[i - 3]) + nums[i];
            }

            return Math.Max(dp[nums.Length - 1], dp[nums.Length - 2]);
        }
        public int RobNeet(int[] nums)
        {
            int rob1 = 0;
            int rob2 = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int temp = Math.Max(rob1 + nums[i], rob2);
                rob1 = rob2;
                rob2 = temp;
            }
            return rob2;
        }
        #endregion
        #region House Robber 2
        /*
        You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent houses have a security system connected, and it will automatically 
        contact the police if two adjacent houses were broken into on the same night.
        Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

        Example 1:
        Input: nums = [2,3,2]
        Output: 3
        Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2), because they are adjacent houses.

        Example 2:
        Input: nums = [1,2,3,1]
        Output: 4
        Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
        Total amount you can rob = 1 + 3 = 4.

        Example 3:
        Input: nums = [1,2,3]
        Output: 3

        Constraints:

            1 <= nums.length <= 100
            0 <= nums[i] <= 1000

        Test Cases:
        nums= [2,7,9,3,1] 48 / 75 test cases passed
        nums = [1] 73/75 test cases passed

        https://leetcode.com/problems/house-robber-ii/
        */
        //52 ms on March 04th 2024
        public int Rob2(int[] nums)
        {

            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            return Math.Max(cycles(nums, 0, nums.Length - 1), cycles(nums, 1, nums.Length));
        }
        public int cycles(int[] nums, int begin, int end)
        {
            int rob1 = 0;
            int rob2 = 0;

            for (int i = begin; i < end; i++)
            {
                int temp = Math.Max(rob1 + nums[i], rob2);
                rob1 = rob2;
                rob2 = temp;
            }

            return rob2;
        }

        #endregion
        #region Longest Palindromic Substring
        /*
        Given a string s, return the longest palindromic substring in s.
                
        Example 1:
        Input: s = "babad"
        Output: "bab"
        Explanation: "aba" is also a valid answer.

        Example 2:
        Input: s = "cbbd"
        Output: "bb"

        Constraints:
        1 <= s.length <= 1000
        s consist of only digits and English letters.
       
        */
        public string LongestPalindrome(string s)
        {
            int len1 = 0;
            int l = 0;
            int h = 0;

            for (int i = 0; i < s.Length; i++)
            {
                len1 = Math.Max(cycles(s, i, i), cycles(s, i, i + 1));

                if (len1 > h - l)
                {
                    l = i - (len1 - 1) / 2;
                    h = i + len1 / 2;
                }
            }
            return s.Substring(l, h - l + 1);
        }

        public int cycles(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }


            return right - left - 1;
        }
        #endregion
    }

}