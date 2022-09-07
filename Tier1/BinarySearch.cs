using System;
using System.Collections.Generic;

namespace Tier1
{
    public class BinarySearch
    {
        /*
        Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. 
        If target exists, then return its index. Otherwise, return -1.
        You must write an algorithm with O(log n) runtime complexity.
        https://leetcode.com/problems/binary-search/
        */
        public int BinarySearchOriginal(int[] nums, int target)
        {
            int pivot, left = 0, right = nums.Length;

            while (left <= right)
            {
                pivot = left + (right - left) / 2;

                if (nums[pivot] == target) return pivot;
                if (nums[pivot] > target) right = pivot - 1;
                else { left = pivot + 1; }
            }

            return 0;
        }
        #region Template 1
        //Tier 1
        #region Find Square Root
        /*
        Given a non-negative integer x, compute and return the square root of x.
        Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.
        Note: You are not allowed to use any built-in exponent function or operator, such as pow(x, 0.5) or x ** 0.5.
        https://leetcode.com/problems/sqrtx/
        */
        public int MySqrt(int x)
        {
            if (x <= 1) return x;
            int start = 1;
            int end = x / 2;

            while (start < end)
            {
                // start is not always moving and hence we can get stuck in infinite loop with mid calculation
                // Adding 1 to mid everytime to ensure we always move the mid
                int mid = (start + (end - start) / 2) + 1;

                // use division instead of multiplication to avoid overflow
                int div = x / mid;
                if (div == mid) return mid;
                if (div > mid) start = mid;
                else end = mid - 1;
            }

            return start;
        }
        #endregion
        #region Guess Number
        /*
        We are playing the Guess Game. The game is as follows:
        I pick a number from 1 to n. You have to guess which number I picked.
        Every time you guess wrong, I will tell you whether the number I picked is higher or lower than your guess.
        You call a pre-defined API int guess(int num), which returns three possible results:

        -1: Your guess is higher than the number I picked (i.e. num > pick).
         1: Your guess is lower than the number I picked (i.e. num < pick).
         0: your guess is equal to the number I picked (i.e. num == pick).

         Return the number that I picked.
         Math.abs spots below replaced a special API on leetcode,it returns a guess that I can't replicate here.
         https://leetcode.com/problems/guess-number-higher-or-lower/solution/
        */
        public int GuessNumber(int n)
        {
            int left = 0;
            int right = n;
            while (left <= right)
            {
                int pivot = left + (right - left) / 2;
                if (Math.Abs(pivot) == 0) return pivot;
                if (Math.Abs(pivot) == -1) right = pivot - 1;
                else { left = pivot + 1; }
            }
            return 0;
        }
        #endregion
        #region Search rotated Array      
        /*
        There is an integer array nums sorted in ascending order (with distinct values).
        Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is:
        [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). 
        For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].
        Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.
        You must write an algorithm with O(log n) runtime complexity.
        https://leetcode.com/problems/search-in-rotated-sorted-array/
        */
        public int SearchRotatedArray(int[] nums, int target)
        {
            int lo = 0, hi = nums.Length - 1;
            // find the index of the smallest value using binary search.
            // Loop will terminate since mid < hi, and lo or hi will shrink by at least 1.
            // Proof by contradiction that mid < hi: if mid==hi, then lo==hi and loop would have been terminated.
            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                if (nums[mid] > nums[hi]) lo = mid + 1;
                else hi = mid;
            }
            // lo==hi is the index of the smallest value and also the number of places rotated.
            int rot = lo;
            lo = 0; hi = nums.Length - 1;
            // The usual binary search and accounting for rotation.
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                int realmid = (mid + rot) % nums.Length;
                if (nums[realmid] == target) return realmid;
                if (nums[realmid] < target) lo = mid + 1;
                else hi = mid - 1;
            }
            return -1;
        }
        #endregion
        #endregion Template 1
        #region Template 2
        //Tier 2
        #region First Bad Version
        /*
        You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. 
        Since each version is developed based on the previous version, all the versions after a bad version are also bad.
        Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
        You are given an API bool isBadVersion(version) which returns whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.
        https://leetcode.com/problems/first-bad-version/solution/
        Math.abs spots below replaced a special API on leetcode,it returns a guess that I can't replicate here.
        */
        public int FirstBadVersion(int n)
        {
            int start = 1;
            int end = n;

            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (Math.Abs(mid) == 0)
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return start;
        }
        #endregion
        #region  Find Peak Element
        /*
        A peak element is an element that is strictly greater than its neighbors.
        Given a 0-indexed integer array nums, find a peak element, and return its index. If the array contains multiple peaks, return the index to any of the peaks.
        You may imagine that nums[-1] = nums[n] = -∞. In other words, an element is always considered to be strictly greater than a neighbor that is outside the array.
        You must write an algorithm that runs in O(log n) time.
        Example 1:
        Input: nums = [1,2,3,1]
        Output: 2
        Explanation: 3 is a peak element and your function should return the index number 2.
        Example 2:
        Input: nums = [1,2,1,3,5,6,4]
        Output: 5
        Explanation: Your function can return either index number 1 where the peak element is 2, or index number 5 where the peak element is 6. 
        https://leetcode.com/problems/find-peak-element/solution/
        */
        public int FindPeakElement(int[] nums)
        {
            int l = 0, r = nums.Length - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (nums[mid] > nums[mid + 1])
                    r = mid;
                else
                    l = mid + 1;
            }
            return l;
        }
        #endregion
        #region FindMinInASortedArray
        /*
         Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:

        [4,5,6,7,0,1,2] if it was rotated 4 times.
        [0,1,2,4,5,6,7] if it was rotated 7 times.

        Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

        Given the sorted rotated array nums of unique elements, return the minimum element of this array.

        You must write an algorithm that runs in O(log n) time.
            https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
        */
        public int FindMin(int[] nums)
        {
            // If the list has just one element then return that element.
            if (nums.Length == 1)
            {
                return nums[0];
            }

            // initializing left and right pointers.
            int left = 0, right = nums.Length - 1;

            // if the last element is greater than the first element then there is no
            // rotation.
            // e.g. 1 < 2 < 3 < 4 < 5 < 7. Already sorted array.
            // Hence the smallest element is first element. A[0]
            if (nums[right] > nums[0])
            {
                return nums[0];
            }

            // Binary search way
            while (right >= left)
            {
                // Find the mid element
                int mid = left + (right - left) / 2;

                // if the mid element is greater than its next element then mid+1 element is the
                // smallest
                // This point would be the point of change. From higher to lower value.
                if (nums[mid] > nums[mid + 1])
                {
                    return nums[mid + 1];
                }

                // if the mid element is lesser than its previous element then mid element is
                // the smallest
                if (nums[mid - 1] > nums[mid])
                {
                    return nums[mid];
                }

                // if the mid elements value is greater than the 0th element this means
                // the least value is still somewhere to the right as we are still dealing with
                // elements
                // greater than nums[0]
                if (nums[mid] > nums[0])
                {
                    left = mid + 1;
                }
                else
                {
                    // if nums[0] is greater than the mid value then this means the smallest value
                    // is somewhere to
                    // the left
                    right = mid - 1;
                }
            }
            return Int32.MaxValue;

        }
        #endregion
        #endregion Template 2
        #region Template 3
        //Tier 3
        #region Search for a Range
        /*
        Given an array of integers nums sorted in non-decreasing order, 
        find the starting and ending position of a given target value.
        If target is not found in the array, return [-1, -1].
        You must write an algorithm with O(log n) runtime complexity.
        Example 1:
        Input: nums = [5,7,7,8,8,10], target = 8
        Output: [3,4]
        Example 2:
        Input: nums = [5,7,7,8,8,10], target = 6
        Output: [-1,-1]
        Example 3:
        Input: nums = [], target = 0
        Output: [-1,-1]
        https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        Extra test cases:
        [5,7,7,8,8,10]
        8
        []
        0
        [5,7,7,8,8,10]
        6      
        */
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[2];
            result[0] = SearchFirst(nums, target);
            result[1] = SearchLast(nums, target);
            return result;
        }

        private int SearchFirst(int[] nums, int target)
        {
            int idx = -1;
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] >= target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
                if (nums[mid] == target) idx = mid;
            }
            return idx;
        }

        private int SearchLast(int[] nums, int target)
        {
            int idx = -1;
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] <= target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
                if (nums[mid] == target) idx = mid;
            }
            return idx;
        }
        #endregion
        #region  Find K Closest Elements
        /*
        Given a sorted integer array arr, two integers k and x, return the k closest integers to x in the array. The result should also be sorted in ascending order.
        An integer a is closer to x than an integer b if:

            |a - x| < |b - x|, or
            |a - x| == |b - x| and a < b

        Example 1:

        Input: arr = [1,2,3,4,5], k = 4, x = 3
        Output: [1,2,3,4]

        Example 2:

        Input: arr = [1,2,3,4,5], k = 4, x = -1
        Output: [1,2,3,4]

        https://leetcode.com/problems/find-k-closest-elements/
        */
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            return FindClosestElementsSlidingWindow(arr, k, x);
        }

        //200ms,374ms,385ms submissions 
        private IList<int> FindClosestElementsBinarySearch(int[] arr, int k, int x)
        {
            var left = 0;
            var right = arr.Length - k;

            while (left < right)
            {
                var median = left + (right - left) / 2;

                var distanceFromFirstToTarget = x - arr[median];
                var distanceFromLiastToTarget = arr[median + k] - x;

                if (distanceFromFirstToTarget > distanceFromLiastToTarget)
                    left = median + 1;
                else
                    right = median;
            }

            var result = new List<int>(k);

            for (var i = left; i < left + k; i++)
                result.Add(arr[i]);

            return result;
        }
        //200ms,347ms,341ms submissions
        private IList<int> FindClosestElementsSlidingWindow(int[] arr, int k, int x)
        {
            var left = 0;
            var right = arr.Length - 1;

            while (right - left >= k)
            {
                if (Math.Abs(arr[left] - x) > Math.Abs(arr[right] - x))
                    left++;
                else
                    right--;
            }

            var result = new List<int>(k);

            for (var i = left; i < left + k; i++)
                result.Add(arr[i]);

            return result;
        }

        #endregion
        #endregion Template 3 
    }
}
