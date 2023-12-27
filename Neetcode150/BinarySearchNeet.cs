using System;
using System.Collections.Generic;
using System.Collections.Immutable;

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
        https://leetcode.com/problems/koko-eating-bananas/
        */
        #endregion
    }
}