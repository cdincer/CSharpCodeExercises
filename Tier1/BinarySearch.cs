using System;

namespace Tier1
{
    public class BinarySearch
    {

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
        //Binary Search Template 1

        #region question1
        /*
        Given a non-negative integer x, compute and return the square root of x.
        Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.
        Note: You are not allowed to use any built-in exponent function or operator, such as pow(x, 0.5) or x ** 0.5.
        https://leetcode.com/problems/sqrtx/
        */
        #endregion
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

        #region question2
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
        #endregion
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

        //Search rotated Array      
        #region question3
        /*
        There is an integer array nums sorted in ascending order (with distinct values).
        Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is:
        [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). 
        For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].
        Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.
        You must write an algorithm with O(log n) runtime complexity.
        https://leetcode.com/problems/search-in-rotated-sorted-array/
        */
        #endregion
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

        //Tier 2

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

    }
}
