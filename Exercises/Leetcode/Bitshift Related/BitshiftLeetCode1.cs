using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Leetcode.BitshiftRelated
{
    public class BitshiftLeetcode1
    {
        #region Count Complete Subarrays in an Array
        /*
        You are given two 0-indexed arrays, nums1 and nums2, consisting of non-negative integers. 
        There exists another array, nums3, which contains the bitwise XOR of all pairings of 
        integers between nums1 and nums2 (every integer in nums1 is paired with every integer in nums2 exactly once).
        Return the bitwise XOR of all integers in nums3.

        Example 1:
        Input: nums1 = [2,1,3], nums2 = [10,2,5,0]
        Output: 13
        Explanation:
        A possible nums3 array is [8,0,7,2,11,3,4,1,9,1,6,3].
        The bitwise XOR of all these numbers is 13, so we return 13.

        Example 2:
        Input: nums1 = [1,2], nums2 = [3,4]
        Output: 0
        Explanation:
        All possible pairs of bitwise XORs are nums1[0] ^ nums2[0], nums1[0] ^ nums2[1], nums1[1] ^ nums2[0],
        and nums1[1] ^ nums2[1].
        Thus, one possible nums3 array is [2,5,1,6].
        2 ^ 5 ^ 1 ^ 6 = 0, so we return 0.

        Constraints:

            1 <= nums1.length, nums2.length <= 105
            0 <= nums1[i], nums2[j] <= 109

        https://leetcode.com/problems/bitwise-xor-of-all-pairings

        Explanation and the author:
        https://leetcode.com/problems/bitwise-xor-of-all-pairings/solutions/2646552/java-c-python-easy-and-concise
        Summary: Because of XOR's nature array's length is determining factor here of kind result we are getting
        and we can calculate that without resorting to O(n^2) solutions.
        */
        public int XorAllNums(int[] nums1, int[] nums2)
        {

            int x = 0, y = 0;
            foreach (int a in nums1)
                x ^= a;

            foreach (int b in nums2)
                y ^= b;

            return (nums1.Length % 2 * y) ^ (nums2.Length % 2 * x);
        }
        #endregion
    }
}