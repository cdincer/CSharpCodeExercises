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
            //left:0///right 5
            //mid first run 2.5 == 2
            //left = 2
            //second run  3+2 
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
        [[1]]  2
        [[1,1]] 2
        matrix = [[1]] target = 0 2 / 133 testcases passed
        matrix = [[1,1]] target = 0   5 / 133 testcases passed
        matrix = [[1],[3],[5]] target = 3
        matrix = [[1, 3]] target = 3
        matrix = [[1, 3]] target = 2
        matrix = [[1]] target = 1
        matrix = [[1,3]] target = 1 114 / 133 testcases passed
        matrix = [[1],[3]] target = 2 15 / 133 testcases passed
        matrix = [[1],[3]] target = 3 115 / 133 testcases passed
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
        [3,1,2] 58 / 150 testcases
        [2,1] 108 / 150 testcases
        https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
        */
        public int FindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int minValue = nums[0];

            if (nums[left] < nums[right])
                return nums[left];

            while (left <= right)
            {
                int mid = left + ((right - left) / 2);
                if (nums[mid] < minValue)
                {
                    right = mid - 1;
                    minValue = nums[mid];
                }
                else
                {
                    left = mid + 1;
                }
            }

            return minValue;
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
        There is an integer array nums sorted in ascending order (with distinct values).
        Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed).
        For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].
        Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.
        You must write an algorithm with O(log n) runtime complexity.

        Example 1:
        Input: nums = [4,5,6,7,0,1,2], target = 0
        Output: 4

        Example 2:
        Input: nums = [4,5,6,7,0,1,2], target = 3
        Output: -1

        Example 3:
        Input: nums = [1], target = 0
        Output: -1

        Constraints:

            1 <= nums.length <= 5000
            -104 <= nums[i] <= 104
            All values of nums are unique.
            nums is an ascending array that is possibly rotated.
            -104 <= target <= 104

        Extra Test Cases:

        [3,5,1] 125 / 195
        3
        [4,5,6,7,8,1,2,3] 165 / 195
        8
        [3,5,1] 170 / 195
        1
        [3,4,5,6,7,1,2] 174 / 195
        4
        [4,5,6,7,0,1,2] 181 / 195
        0
        [8,1,2,3,4,5,6,7] 182 / 195
        6
        [3,1] 192 / 195 
        1
        */
        public int SearchNeet(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                var mid = left + ((right - left) / 2);

                if (nums[mid] == target)
                    return mid;

                if (nums[left] <= nums[mid]) // left sorted solution
                {
                    if (target > nums[mid] || target < nums[left])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
                else
                {
                    if (target < nums[mid] || target > nums[right])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
            }
            return -1;
        }
        #endregion
        #region Time Based Key Value Store 
        /*
        https://leetcode.com/problems/time-based-key-value-store/
        Extra Test Cases: 
        ["TimeMap","set","set","get","get","get","get","get"] 45 / 51 testcases passed
        [[],["love","high",10],["love","low",20],["love",5],["love",10],["love",15],["love",20],["love",25]]
        ["TimeMap","set","set","get","set","get","get"] 46 / 51 testcases passed
        [[],["a","bar",1],["x","b",3],["b",3],["foo","bar2",4],["foo",4],["foo",5]]
        */
        public class TimeMap
        {

            public Dictionary<string, List<IRow>> list;

            public TimeMap()
            {
                list = new();
            }

            public void Set(string key, string value, int timestamp)
            {

                if (!list.ContainsKey(key))
                    list[key] = new List<IRow>();

                IRow NewRow = new();
                NewRow.value = value;
                NewRow.timestamp = timestamp;
                list[key].Add(NewRow);
            }

            public string Get(string key, int timestamp)
            {

                if (!list.ContainsKey(key))
                    return "";

                List<IRow> forl = new List<IRow>();
                string maxValue = "";
                forl = list[key];
                int target = timestamp;

                int left = 0;
                int right = forl.Count - 1;

                while (left <= right)
                {
                    int mid = left + ((right - left) / 2);

                    if (forl[mid].timestamp == target)
                        return forl[mid].value;

                    if (forl[mid].timestamp < target)
                    {
                        maxValue = forl[mid].value;
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                if (maxValue != "")
                    return maxValue;

                return "";
            }
        }
        public class IRow
        {
            public string value;
            public int timestamp;
        }
        #endregion
        #region Median of Two Sorted Arrays  
        /*
        Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
        The overall run time complexity should be O(log (m+n)).

        Example 1:
        Input: nums1 = [1,3], nums2 = [2]
        Output: 2.00000
        Explanation: merged array = [1,2,3] and median is 2.

        Example 2:
        Input: nums1 = [1,2], nums2 = [3,4]
        Output: 2.50000
        Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

        Constraints:

            nums1.length == m
            nums2.length == n
            0 <= m <= 1000
            0 <= n <= 1000
            1 <= m + n <= 2000
            -106 <= nums1[i], nums2[i] <= 106

        Exta Test Cases:
        [1,3] 2057 / 2094 testcases passed
        [2,7]
        [] 1418 / 2094 testcases passed
        [1,2,3,4,5]
        https://leetcode.com/problems/median-of-two-sorted-arrays/
        */

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                int[] temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }

            int n1l = nums1.Length;
            int n2l = nums2.Length;
            int left = 0, right = n1l;

            while (left <= right)
            {
                int partition1 = (left + right) / 2;
                int partition2 = (n1l + n2l + 1) / 2 - partition1;

                int left1 = (partition1 == 0) ? int.MinValue : nums1[partition1 - 1];
                int left2 = (partition2 == 0) ? int.MinValue : nums2[partition2 - 1];

                int right1 = (partition1 == n1l) ? int.MaxValue : nums1[partition1];
                int right2 = (partition2 == n2l) ? int.MaxValue : nums2[partition2];

                if (left1 <= right2 && left2 <= right1)
                {
                    if ((n1l + n2l) % 2 == 0)
                        return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
                    else
                        return Math.Max(left1, left2);
                }
                else if (left1 > right2)
                    right = partition1 - 1;
                else
                    left = partition1 + 1;
            }

            throw new ArgumentException("Input arrays are not sorted.");
        }
        public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                 int[] temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }

            int n1l = nums1.Length;
            int n2l = nums2.Length;
            int left = 0;
            int right = n1l;

            while (left <= right)
            {
                int Partition1 = (left + right) / 2;
                int Partition2 = (n1l + n2l + 1) / 2 - Partition1;

                int left1 = Partition1 == 0 ? int.MinValue : nums1[Partition1 - 1];
                int left2 = Partition2 == 0 ? int.MinValue : nums2[Partition2 - 1];

                int right1 = Partition1 == n1l ? int.MaxValue : nums1[Partition1];
                int right2 = Partition2 == n2l ? int.MaxValue : nums2[Partition2];

                if (left1 <= right2 && left2 <= right1)
                {
                    if ((n1l + n2l) % 2 == 0)
                        return (Math.Max(left1, left2) + Math.Min(right2, right1)) / 2.0;
                    else
                    {
                        return Math.Max(left1, left2);
                    }
                }
                else if (left1 > right2)
                {
                    right = Partition1 - 1;
                }
                else
                {
                    left = Partition1 + 1;
                }
            }

            return -1;
        }

        #endregion
    }
}