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
        #region Neighboring Bitwise XOR
        /*
        A 0-indexed array derived with length n is derived by computing the bitwise XOR (⊕) of
        adjacent values in a binary array original of length n.
        Specifically, for each index i in the range [0, n - 1]:

            If i = n - 1, then derived[i] = original[i] ⊕ original[0].
            Otherwise, derived[i] = original[i] ⊕ original[i + 1].

        Given an array derived, your task is to determine whether there exists a 
        valid binary array original that could have formed derived.
        Return true if such an array exists or false otherwise.

            A binary array is an array containing only 0's and 1's

        Example 1:
        Input: derived = [1,1,0]
        Output: true
        Explanation: A valid original array that gives derived is [0,1,0].
        derived[0] = original[0] ⊕ original[1] = 0 ⊕ 1 = 1 
        derived[1] = original[1] ⊕ original[2] = 1 ⊕ 0 = 1
        derived[2] = original[2] ⊕ original[0] = 0 ⊕ 0 = 0

        Example 2:
        Input: derived = [1,1]
        Output: true
        Explanation: A valid original array that gives derived is [0,1].
        derived[0] = original[0] ⊕ original[1] = 1
        derived[1] = original[1] ⊕ original[0] = 1

        Example 3:
        Input: derived = [1,0]
        Output: false
        Explanation: There is no valid original array that gives derived.

    
        Constraints:

            n == derived.length
            1 <= n <= 105
            The values in derived are either 0's or 1's

        Extra Test Cases:
        derived = [0] Expected Output:True
        derived = [1] Expected Output:False
        https://leetcode.com/problems/neighboring-bitwise-xor/

        Explanation:
        derived[0] = original[0] XOR original[1]
        derived[1] = original[1] XOR original[2]
        derived[2] = original[2] XOR original[3]
        derived[3] = original[3] XOR original[4]
        ...
        derived[n-1] = original[n-1] XOR original[0]

        XOR's Commutativity,Associativity, Self-inverse nature is the key to this question.
        By doing a cumulative XOR we strike out all of the elements of the original array(Self-inverse).
        It can be only zero if there is one unique original array that is the basis for 
        derived one we are getting(Commutativity). If there is a change to "original" one that causes one of the
        other derived elements (Associativity) to change that means that are two "original"s so there is no valid single one.

        */
        public bool DoesValidArrayExist(int[] derived)
        {
            int XOR = 0;
            foreach (int element in derived)
            {
                XOR = XOR ^ element;
            }
            return XOR == 0;
        }
        #endregion

    }
}