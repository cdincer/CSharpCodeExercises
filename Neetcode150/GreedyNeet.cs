using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neetcode150
{
    public class GreedyNeet
    {
        #region Maximum Subarray
        /*
        Given an integer array nums, find the subarray
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
        Extra Test Cases:
        [-2,1] 172 / 210 testcases passed
        [-1] 195 / 210 testcases passed
        */
        public int MaxSubArray(int[] nums)
        {
            int maxSub = nums[0];
            int curSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (curSum < 0)
                {
                    curSum = 0;
                }
                curSum += nums[i];
                maxSub = Math.Max(maxSub, curSum);
            }
            return maxSub;
        }
        #endregion
        #region Jump Game
        /*
        https://leetcode.com/problems/jump-game/
        */
        #endregion
        #region Jump Game II
        /*
        Extra Test Cases: 
        [2,1,1,5,2] Output:3 
        [2,1] Output:1 
        [1] Output:0 
        [2,1,2,1,0] Output:2 
        [3,4,3,2,5,4,3] 
        [4,1,1,3,1,1,1] 
        [10,9,8,7,6,5,4,3,2,1,1,0]
        */
        #endregion
    }

}