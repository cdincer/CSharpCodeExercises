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
        You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.
        Return true if you can reach the last index, or false otherwise.

        Example 1:
        Input: nums = [2,3,1,1,4]
        Output: true
        Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

        Example 2:
        Input: nums = [3,2,1,0,4]
        Output: false
        Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.

        Constraints:

            1 <= nums.length <= 104
            0 <= nums[i] <= 105

        https://leetcode.com/problems/jump-game/
        */
        public bool CanJump(int[] nums)
        {
            int goal = nums.Length - 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= goal)
                    goal = i;
            }

            return goal == 0;
        }
        #endregion
        #region Jump Game II
        /*
        You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].

        Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at nums[i], you can jump to any nums[i + j] where:

            0 <= j <= nums[i] and
            i + j < n

        Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].

        Example 1:
        Input: nums = [2,3,1,1,4]
        Output: 2
        Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.

        Example 2:
        Input: nums = [2,3,0,1,4]
        Output: 2

        Constraints:

            1 <= nums.length <= 104
            0 <= nums[i] <= 1000
            It's guaranteed that you can reach nums[n - 1].

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
        #region Gas Station
        /*
        Extra Test Cases:
        gas=[2,0,0]
        cost=[0,1,0]
        https://leetcode.com/problems/gas-station/
        */
        #endregion
        #region Hand Of Straights
        /*
        Hand Of Straights 
        [2,3,4,5,6,7,8,9] 8 
        [8,8,9,7,7,7,6,7,10,6] 2 
        [1,1,2,2,3,3] 2 
        [8,10,12] 3 = false
        [66,75,4,37,92,87,68,65,58,100,97,42,19,66,73,1,5,44,30,29,76,31,12,35,26,93,9,36,90,16,86,15,4,9,13,98,10,14,18,90,89,3,10,65,24,31,43,25,54,55,54,81,10,80,31,12,15,14,59,27,64,93,32,26,69,79,13,32,29,24,27,91,92,82,37,101,100,61,74,30,91,62,36,92,28,23,4,63,55,3,11,11,101,22,34,25,2,75,43,72] 2 
        */
        #endregion
    }

}