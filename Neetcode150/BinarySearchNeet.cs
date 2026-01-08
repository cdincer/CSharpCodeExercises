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
        piles = [312884470] h = 968709470  123th testcase out of 126
        piles = 
        [873375536,395271806,617254718,970525912,634754347,824202576,694181619,20191396,
        886462834,442389139,572655464,438946009,791566709,776244944,694340852,419438893,
        784015530,588954527,282060288,269101141,499386849,846936808,92389214,385055341,
        56742915,803341674,837907634,728867715,20958651,167651719,345626668,701905050,
        932332403,572486583,603363649,967330688,484233747,859566856,446838995,375409782,
        220949961,72860128,998899684,615754807,383344277,36322529,154308670,335291837,
        927055440,28020467,558059248,999492426,991026255,30205761,884639109,61689648,
        742973721,395173120,38459914,705636911,30019578,968014413,126489328,738983100,
        793184186,871576545,768870427,955396670,328003949,786890382,450361695,994581348,
        158169007,309034664,388541713,142633427,390169457,161995664,906356894,379954831,
        448138536] h = 943223529 80 / 126 testcases passed
        piles = [805306368,805306368,805306368]  h = 1000000000 125 / 126 testcases passed
        */
        public int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1; int right = piles.Max();
            int result = right;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                long hours = 0;

                foreach (int pile in piles)
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
        You are given an array of length n which was originally sorted in ascending order. It has now been rotated between 1 and n times. For example, the array nums = [1,2,3,4,5,6] might become:

            [3,4,5,6,1,2] if it was rotated 4 times.
            [1,2,3,4,5,6] if it was rotated 6 times.

        Notice that rotating the array 4 times moves the last four elements of the array to the beginning. Rotating the array 6 times produces the original array.

        Assuming all elements in the rotated sorted array nums are unique, return the minimum element of this array.

        A solution that runs in O(n) time is trivial, can you write an algorithm that runs in O(log n) time?

        Example 1:

        Input: nums = [3,4,5,6,1,2]

        Output: 1

        Example 2:

        Input: nums = [4,5,0,1,2,3]

        Output: 0

        Example 3:

        Input: nums = [4,5,6,7]

        Output: 4

        Constraints:

            1 <= nums.length <= 1000
            -1000 <= nums[i] <= 1000

        Extra Test Case:
        [3,1,2] 58 / 150 testcases
        [2,1] 108 / 150 testcases
        https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
        */

        /*
        Complete explanation
        
        At each step, check if the middle element is greater than the rightmost element.
        If so, the minimum must be to the right.
        Otherwise, the minimum is at mid or to the left.
        */
        public int FindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                //If mid element is greater than the rightmost,min is in right half
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    //Min is at the mid or to the left
                    right = mid;
                }
            }
            //left == right is the index of the minimum
            return nums[left];
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

        [3,5,1] target = 3 125 / 195
        [4,5,6,7,8,1,2,3] target = 8 165 / 195
        [3,5,1] target = 1 170 / 195
        [3,4,5,6,7,1,2] target = 4 174 / 195
        [4,5,6,7,0,1,2] target = 0 181 / 195
        [8,1,2,3,4,5,6,7] target = 6 182 / 195
        [3,1] target = 1 192 / 195 

        https://leetcode.com/problems/search-in-rotated-sorted-array/
        https://youtu.be/U8XENwh8Oy8
        */
        public int SearchInRotatedSortedArray(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (right + left) / 2;

                if (nums[mid] == target)
                    return mid;

                //Decide which half is sorted

                if (nums[left] <= nums[mid])//Left half is sorted
                {
                    if (nums[left] <= target && target < nums[mid])//If Between this range search left range
                        right = mid - 1;
                    else
                        left = mid + 1; //Search right range
                }
                else//Right half is sorted
                {
                    if (nums[mid] < target && target <= nums[right])//If Between this range search right range
                        left = mid + 1;
                    else
                        right = mid - 1;//Search left range
                }
            }
            return -1;
        }
        #endregion
        #region Time Based Key Value Store 
        /*
        Design a time-based key-value data structure that can store multiple values for 
        the same key at different time stamps and retrieve the key's value at a certain timestamp.
        Implement the TimeMap class:

            TimeMap() Initializes the object of the data structure.
            void set(String key, String value, int timestamp) Stores the key key with the value value at the given time timestamp.
            String get(String key, int timestamp) Returns a value such that set was called previously, with timestamp_prev <= timestamp. If there are multiple such values, it returns the value associated with the largest timestamp_prev. If there are no values, it returns "".

        Example 1:
        Input
        ["TimeMap", "set", "get", "get", "set", "get", "get"]
        [[], ["foo", "bar", 1], ["foo", 1], ["foo", 3], ["foo", "bar2", 4], ["foo", 4], ["foo", 5]]
        Output
        [null, null, "bar", "bar", null, "bar2", "bar2"]

        Explanation
        TimeMap timeMap = new TimeMap();
        timeMap.set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
        timeMap.get("foo", 1);         // return "bar"
        timeMap.get("foo", 3);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
        timeMap.set("foo", "bar2", 4); // store the key "foo" and value "bar2" along with timestamp = 4.
        timeMap.get("foo", 4);         // return "bar2"
        timeMap.get("foo", 5);         // return "bar2"

        Constraints:

            1 <= key.length, value.length <= 100
            key and value consist of lowercase English letters and digits.
            1 <= timestamp <= 107
            All the timestamps timestamp of set are strictly increasing.
            At most 2 * 105 calls will be made to set and get.

        https://leetcode.com/problems/time-based-key-value-store/
        Extra Test Cases: 
        ["TimeMap","set","set","get","get","get","get","get"] 45 / 51 testcases passed
        [[],["love","high",10],["love","low",20],["love",5],["love",10],["love",15],["love",20],["love",25]]
        ["TimeMap","set","set","get","set","get","get"] 46 / 51 testcases passed
        [[],["a","bar",1],["x","b",3],["b",3],["foo","bar2",4],["foo",4],["foo",5]]
        */
        //Previous solution removed for inadequate run and high code complexity - time,memory consumption was acceptable.
        //Sep 17, 2024 19:11 Passes at Runtime : 937 ms and Memory: 232.82 MB 
        public class TimeMap
        {
            private Dictionary<string, List<(int timestamp, string value1)>> _dict;
            public TimeMap()
            {
                _dict = new Dictionary<string, List<(int, string)>>();
            }

            public void Set(string key, string value, int timestamp)
            {
                var value1 = new List<(int, string)>();
                if (!_dict.ContainsKey(key))
                {
                    _dict.Add(key, value1);
                }
                _dict[key].Add((timestamp, value));

            }

            public string Get(string key, int timestamp)
            {
                if (!_dict.ContainsKey(key))
                {
                    return "";
                }
                List<(int timestamp,string value1)> timeStampList = _dict[key];

                int left = 0;
                int right = timeStampList.Count;
                string result = "";

                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (timeStampList[mid].timestamp == timestamp)
                    {
                        result = timeStampList[mid].value1;
                        return result;
                    }
                    else if (timeStampList[mid].timestamp < timestamp)
                    {
                        left = mid + 1;
                        result = timeStampList[mid].value1;
                    }
                    else
                    {
                        right = mid;
                    }

                }

                return result;
            }
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
        nums1 = [] nums2 = [1,2,3,4,5] 1418 / 2094 testcases passed
        nums1 = [1,3] nums2 = [2,7] 2057 / 2094 testcases passed
       nums1 = [100000] nums2 = [100001] 2088 / 2096 testcases passed
        https://leetcode.com/problems/median-of-two-sorted-arrays/
        https://leetcode.com/problems/median-of-two-sorted-arrays/editorial/#approach-3-a-better-binary-search
        */

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length <= 0 && nums2.Length == 1)
                return nums2[0];

            if (nums2.Length <= 0 && nums1.Length == 1)
                return nums1[0];

            int n1l = nums1.Length;
            int n2l = nums2.Length;
            
            if (n1l > n2l)
                return FindMedianSortedArrays(nums2, nums1);

            int total = n1l + n2l;
            int half = (total + 1) / 2;
            int n1left = 0;
            int n1right = n1l;
            double result = 0.0;

            while (n1left <= n1right)
            {
                int n1i = n1left + (n1right - n1left) / 2;
                int n2i = half - n1i;

                int left1 = (n1i > 0) ? nums1[n1i - 1] : int.MinValue;
                int left2 = (n2i > 0) ? nums2[n2i - 1] : int.MinValue;

                int right1 = (n1l > n1i) ? nums1[n1i] : int.MaxValue;
                int right2 = (n2l > n2i) ? nums2[n2i] : int.MaxValue;

                if (left1 <= right2 && left2 <= right1)
                {
                    if (total % 2 == 0)
                        return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.00;
                    else
                        return Math.Max(left1, left2);
                }
                else if (left1 > right2)
                    n1right = n1i - 1;
                else
                    n1left = n1i + 1;
            }
            return result;
        }
        #endregion
    }
}