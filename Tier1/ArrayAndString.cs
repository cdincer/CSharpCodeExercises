using System;
using System.Collections.Generic;

namespace Tier1
{
    //https://leetcode.com/explore/learn/card/array-and-string/
    public class ArrayAndString
    {
        #region Dynamic Array
        #region Find Pivot Index
        /*
             Find Pivot Index

            Given an array of integers nums, calculate the pivot index of this array.
            The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers strictly to the index's right.
            If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
            Return the leftmost pivot index. If no such index exists, return -1.
         
            Example 1:

            Input: nums = [1,7,3,6,5,6]
            Output: 3
            Explanation:
            The pivot index is 3.
            Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
            Right sum = nums[4] + nums[5] = 5 + 6 = 11

            Example 2:

            Input: nums = [1,2,3]
            Output: -1
            Explanation:
            There is no index that satisfies the conditions in the problem statement.

            Example 3:

            Input: nums = [2,1,-1]
            Output: 0
            Explanation:
            The pivot index is 0.
            Left sum = 0 (no elements to the left of index 0)
            Right sum = nums[1] + nums[2] = 1 + -1 = 0
           
            Constraints:

                1 <= nums.length <= 104
                -1000 <= nums[i] <= 1000     
                https://leetcode.com/problems/find-pivot-index/solution/       
        */
        public int PivotIndex(int[] nums)
        {
            int sum = 0, leftsum = 0;
            foreach (int x in nums) sum += x;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (leftsum == sum - leftsum - nums[i]) return i;
                leftsum += nums[i];
            }
            return -1;
        }

        #endregion
        #region Largest Number At Least Twice of Others
        /*
        You are given an integer array nums where the largest integer is unique.

        Determine whether the largest element in the array is at least twice as much as every other number in the array. 
        If it is, return the index of the largest element, or return -1 otherwise.     
        Example 1:

        Input: nums = [3,6,1,0]
        Output: 1
        Explanation: 6 is the largest integer.
        For every other number in the array x, 6 is at least twice as big as x.
        The index of value 6 is 1, so we return 1.

        Example 2:

        Input: nums = [1,2,3,4]
        Output: -1
        Explanation: 4 is less than twice the value of 3, so we return -1.
     
        Constraints:

            2 <= nums.length <= 50
            0 <= nums[i] <= 100
            The largest element in nums is unique.

        https://leetcode.com/problems/largest-number-at-least-twice-of-others/
        */
        public int DominantIndex(int[] nums)
        {
            int location = -1;
            int biggest = -1;


            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > biggest)
                {
                    biggest = nums[i];
                    location = i;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (biggest < nums[i] * 2 && nums[i] != nums[location])
                {
                    return -1;
                }
            }
            return location;
        }
        #endregion
        #endregion

    }
}