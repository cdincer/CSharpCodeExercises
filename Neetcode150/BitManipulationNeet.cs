
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neetcode150
{
    public class BitManipulatiuonNeet
    {
        #region Single Number
        /*
        Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
        You must implement a solution with a linear runtime complexity and use only constant extra space.

        Example 1:
        Input: nums = [2,2,1]
        Output: 1

        Example 2:
        Input: nums = [4,1,2,1,2]
        Output: 4

        Example 3:
        Input: nums = [1]
        Output: 1

        Constraints:

            1 <= nums.length <= 3 * 104
            -3 * 104 <= nums[i] <= 3 * 104
            Each element in the array appears twice except for one element which appears only once.

        https://leetcode.com/problems/single-number/description/
        */
        public int SingleNumber(int[] nums)
        {
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                result ^= nums[i];
            }
            return result;
        }
        #endregion
        #region Number Of 1 Bits
        /*
        Write a function that takes the binary representation of a positive integer and returns the number of
        set bits it has (also known as the Hamming weight).

        Example 1:
        Input: n = 11
        Output: 3
        Explanation:
        The input binary string 1011 has a total of three set bits.

        Example 2:
        Input: n = 128
        Output: 1
        Explanation:
        The input binary string 10000000 has a total of one set bit.

        Example 3:
        Input: n = 2147483645
        Output: 30
        Explanation:
        The input binary string 1111111111111111111111111111101 has a total of thirty set bits.

        Constraints:
            1 <= n <= 231 - 1
        Follow up: If this function is called many times, how would you optimize it?
        https://leetcode.com/problems/number-of-1-bits/
        */
        public int HammingWeight(int n)
        {
            int result = 0;
            string rlength = Convert.ToString(n, 2);

            for (int i = 0; i < rlength.Length; i++)
            {

                int temp = n & 1;
                n >>= 1;

                if (temp == 1)
                    result++;
            }

            return result;
        }
        #endregion
        #region Counting Bits
        /*
        Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n), ans[i] is the number of 1's in the binary representation of i.

        Example 1:

        Input: n = 2
        Output: [0,1,1]
        Explanation:
        0 --> 0
        1 --> 1
        2 --> 10

        Example 2:
        Input: n = 5
        Output: [0,1,1,2,1,2]
        Explanation:
        0 --> 0
        1 --> 1
        2 --> 10
        3 --> 11
        4 --> 100
        5 --> 101

        Constraints:

            0 <= n <= 105

        Follow up:

            It is very easy to come up with a solution with a runtime of O(n log n). Can you do it in linear time O(n) and possibly in a single pass?
            Can you do it without using any built-in function (i.e., like __builtin_popcount in C++)?

        https://leetcode.com/problems/counting-bits/
        */
        #endregion
        #region Reverse Bits
        /*
        Reverse bits of a given 32 bits unsigned integer.

        Note:
            Note that in some languages, such as Java, there is no unsigned integer type. In this case, both input and output will be given as a signed integer type. They should not affect your implementation, as the integer's internal binary representation is the same, whether it is signed or unsigned.
            In Java, the compziler represents the signed integers using 2's complement notation. Therefore, in Example 2 above, the input represents the signed integer -3 and the output represents the signed integer -1073741825.

        Example 1:
        Input: n = 00000010100101000001111010011100
        Output:    964176192 (00111001011110000010100101000000)
        Explanation: The input binary string 00000010100101000001111010011100 represents the unsigned integer 43261596, so return 964176192 which its binary representation is 00111001011110000010100101000000.

        Example 2:
        Input: n = 11111111111111111111111111111101
        Output:   3221225471 (10111111111111111111111111111111)
        Explanation: The input binary string 11111111111111111111111111111101 represents the unsigned integer 4294967293, so return 3221225471 which its binary representation is 10111111111111111111111111111111.

        Constraints:

            The input must be a binary string of length 32

        Follow up: If this function is called many times, how would you optimize it?

        Extra Test Cases:
        00000000000000000000000000000100
        00000000000000000000000000000001
        00000000000000000000000000000110
        10000000000000000000000000000001
        00000010100101000001111010011100
        https://leetcode.com/problems/reverse-bits/
        */
        public uint reverseBits(uint n)
        {
            uint result = 0;
            for (int i = 0; i < 32; i++)
            {
                uint temp = (n & 1);
                result = (result << 1) + temp;
                n >>= 1;
            }
            return result;
        }
        #endregion
        #region Missing Number
        /*
        Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.

        Example 1:
        Input: nums = [3,0,1]
        Output: 2
        Explanation: n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number in the range since it does not appear in nums.

        Example 2:
        Input: nums = [0,1]
        Output: 2
        Explanation: n = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 2 is the missing number in the range since it does not appear in nums.

        Example 3:
        Input: nums = [9,6,4,2,3,5,7,0,1]
        Output: 8
        Explanation: n = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 8 is the missing number in the range since it does not appear in nums.

        Constraints:

            n == nums.length
            1 <= n <= 104
            0 <= nums[i] <= n
            All the numbers of nums are unique.

        Follow up: Could you implement a solution using only O(1) extra space complexity and O(n) runtime complexity?
        Extra Test Cases:
        [9,6,4,2,3,5,7,0,1] 98 / 122 testcases passed
        [1]                 111 / 122 testcases passed
        https://leetcode.com/problems/missing-number/
        */
        //Notes about the solution below: Barely any difference in runtime and memory usage with this solution and neetcode's one.
        public int MissingNumber(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length + 1; i++)
                result = result ^ i;

            for (int i = 0; i < nums.Length; i++)
                result = result ^ nums[i];

            return result;
        }
        #endregion
        #region Reverse Integer
        /*
        Extra Test Cases:
        1534236469 1036 / 1045 testcases passed
        */
          public int Reverse(int x) {
        int result = 0;

        if(x > int.MaxValue || x < int.MinValue)
        return 0;

        while( x != 0)
        {
            if(x * 10 > int.MaxValue || x * 10 < int.MinValue)
            return 0;

            if(x / 10 > int.MaxValue || x / 10 < int.MinValue)
            return 0;
            int remain = x % 10;
            x = x / 10;
            
            result = (result * 10) + remain;
        }
//2147483648
//1534236469
//9646324351

            if(result > int.MaxValue ||result < int.MinValue)
            return 0;

           
        Console.WriteLine("hit");
        return result;
    }
        #endregion
    }
}