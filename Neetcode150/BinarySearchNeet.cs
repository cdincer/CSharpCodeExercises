using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Neetcode150
{
    public class BinarySearchNeet
    {
        #region Binary Search
        /*
        Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.
        You must write an algorithm with O(log n) runtime complexity.

        Example 1:
        Input: nums = [-1,0,3,5,9,12], target = 9
        Output: 4
        Explanation: 9 exists in nums and its index is 4

        Example 2:
        Input: nums = [-1,0,3,5,9,12], target = 2
        Output: -1
        Explanation: 2 does not exist in nums so return -1

        Constraints:
            1 <= nums.length <= 104
            -104 < nums[i], target < 104
            All the integers in nums are unique.
            nums is sorted in ascending order.

        https://leetcode.com/problems/binary-search/description/
        */
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + ((right - left) / 2); // (left + right) / 2 can lead to overflow
                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                { // Found the value
                    return mid;
                }
            }
            return -1;
        }
        #endregion
        #region Search a 2D Matrix
        /*
        You are given an m x n integer matrix matrix with the following two properties:
        Each row is sorted in non-decreasing order.
        The first integer of each row is greater than the last integer of the previous row.
        Given an integer target, return true if target is in matrix or false otherwise.
        You must write a solution in O(log(m * n)) time complexity.

        Example 1:
        Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
        Output: true

        Example 2:
        Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
        Output: false

        Constraints:
            m == matrix.length
            n == matrix[i].length
            1 <= m, n <= 100
            -104 <= matrix[i][j], target <= 104


        https://leetcode.com/problems/search-a-2d-matrix/description/
        Extra Test Case:
        [[1]]
        2
        [[1,1]]
        2
        */
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            int top = 0;
            int bottom = rows - 1;
            int pivot = 0;
            while (top <= bottom)
            {
                pivot = top + ((bottom - top) / 2);
                if (target > matrix[pivot][cols - 1]) top = pivot + 1;
                else if (target < matrix[pivot][0]) bottom = pivot - 1;
                else break;
            }


            int left = 0;
            int right = cols - 1;

            while (left <= right)
            {
                int pivot2 = left + ((right - left) / 2);
                if (target < matrix[pivot][pivot2]) right = pivot2 - 1;
                else if (target > matrix[pivot][pivot2]) left = pivot2 + 1;
                else if (target == matrix[pivot][pivot2]) return true;
            }

            return false;
        }
        #endregion
        #region Koko Eating Bananas
        /*
        Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.
        Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. 
        If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.
        Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.
        Return the minimum integer k such that she can eat all the bananas within h hours.

        Example 1:
        Input: piles = [3,6,7,11], h = 8
        Output: 4

        Example 2:
        Input: piles = [30,11,23,4,20], h = 5
        Output: 30

        Example 3:
        Input: piles = [30,11,23,4,20], h = 6
        Output: 23

        Constraints:

            1 <= piles.length <= 104
            piles.length <= h <= 109
            1 <= piles[i] <= 109

        https://leetcode.com/problems/koko-eating-bananas/
        Extra Test Cases:
        [312884470] 123th testcase out of 126
        968709470
        */
        public int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1, right = piles.Max();
            var result = right;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                long hours = 0;
                foreach (var pile in piles)
                {
                    hours += (int)Math.Ceiling(pile / (double)mid);
                }

                if (hours <= h)
                {
                    result = Math.Min(result, mid);
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }
        #endregion
        #region Find Minimum in Rotated Sorted Array
        /*
        Extra Test Case:
        [2,1] 108 / 150 testcase
        https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
        */
        //Custom solution and neetcode's solution are quite similar in runtime,memory usage numbers.
        //After adding the additional conditional for comparing 0th index and Length-1 Index, when this added
        //Runtime significantly gets better than neetcodes.
        public int FindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int resultMin = int.MaxValue;

            if (nums.Length == 1 && nums[left] <= nums[right])
                return nums[0];

            while (left <= right)
            {
                int mid = left + ((right - left) / 2);
                resultMin = Math.Min(resultMin, nums[right]);

                if (nums[mid] > nums[left])
                {
                    resultMin = Math.Min(resultMin, nums[left]);
                    left = mid + 1;
                }
                else if (nums[mid] < nums[right])
                {
                    resultMin = Math.Min(resultMin, nums[mid]);
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return resultMin;
        }
        public int FindMinNeet(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                if (nums[left] <= nums[right])
                {
                    return nums[left];
                }
                int mid = (left + right) / 2;
                if (nums[mid] >= nums[left])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return 0;
        }
        #endregion
        #region Search in Rotated Sorted Array
        /*
        
        Extra Test Cases:
        [1]
        2
        [1]
        -1
        [1,2]
        1
        [2,1]
        1
        [3,5,1] 125 / 195
        3
        [4,5,6,7,8,1,2,3] 165 / 195
        8
        [3,4,5,6,7,1,2] 174 / 195
        4
        */
        public int Search2(int[] nums, int target)
        {

            if (nums.Length == 1 && nums[0] == target)
                return 0;
            else if (nums.Length == 1 && nums[0] != target)
                return -1;

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + ((right - left) / 2);
                if (nums[mid] == target)
                    return mid;

            }
            return -1;
        }
        #endregion
    }
}