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
        There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i].
        You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next (i + 1)th station. 
        You begin the journey with an empty tank at one of the gas stations. Given two integer arrays gas and cost, 
        return the starting gas station's index if you can travel around the circuit once in the clockwise direction,
         otherwise return -1. If there exists a solution, it is guaranteed to be unique

        Example 1:
        Input: gas = [1,2,3,4,5], cost = [3,4,5,1,2]
        Output: 3
        Explanation:
        Start at station 3 (index 3) and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
        Travel to station 4. Your tank = 4 - 1 + 5 = 8
        Travel to station 0. Your tank = 8 - 2 + 1 = 7
        Travel to station 1. Your tank = 7 - 3 + 2 = 6
        Travel to station 2. Your tank = 6 - 4 + 3 = 5
        Travel to station 3. The cost is 5. Your gas is just enough to travel back to station 3.
        Therefore, return 3 as the starting index.

        Example 2:
        Input: gas = [2,3,4], cost = [3,4,3]
        Output: -1
        Explanation:
        You can't start at station 0 or 1, as there is not enough gas to travel to the next station.
        Let's start at station 2 and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
        Travel to station 0. Your tank = 4 - 3 + 2 = 3
        Travel to station 1. Your tank = 3 - 3 + 3 = 3
        You cannot travel back to station 2, as it requires 4 unit of gas but you only have 3.
        Therefore, you can't travel around the circuit once no matter where you start.

        Constraints:
            n == gas.length == cost.length
            1 <= n <= 105
            0 <= gas[i], cost[i] <= 104

        Extra Test Cases:
        gas=[2,0,0]
        cost=[0,1,0]
        https://leetcode.com/problems/gas-station/
        */
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int total = 0;
            int loc = 0;

            if (cost.Sum() > gas.Sum())
                return -1;

            for (int i = 0; i < gas.Length; i++)
            {
                total += gas[i] - cost[i];

                if (0 > total)
                {
                    loc = i + 1;
                    total = 0;
                }
            }

            return loc;
        }
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