using System;
using System.Collections.Generic;

namespace Neetcode150
{
    public class DpOneNeet
    {
        #region House Robber
        /*
        
        https://leetcode.com/problems/house-robber/
        */
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
        #endregion
    }

}