using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Neetcode150
{
    public class MathAndGeometryNeet
    {
        #region Rotate Image
        /*
        You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
        You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

    
        Example 1:
        Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
        Output: [[7,4,1],[8,5,2],[9,6,3]]

        Example 2:
        Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
        Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]

        Constraints:

            n == matrix.length == matrix[i].length
            1 <= n <= 20
            -1000 <= matrix[i][j] <= 1000

        https://leetcode.com/problems/rotate-image/
        */
        public void Rotate(int[][] matrix)
        {
            (int left, int right) = (0, matrix.Length - 1);

            while (left < right)
            {
                var limit = right - left;
                for (var i = 0; i < limit; i++)
                {
                    (int top, int bottom) = (left, right);

                    var topLeft = matrix[top][left + i];
                    matrix[top][left + i] = matrix[bottom - i][left];
                    matrix[bottom - i][left] = matrix[bottom][right - i];
                    matrix[bottom][right - i] = matrix[top + i][right];
                    matrix[top + i][right] = topLeft;
                }

                left++;
                right--;
            }
            return;
        }
        #endregion
        #region Spiral Matrix
        /*
        Given an m x n matrix, return all elements of the matrix in spiral order.

        Example 1:
        Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
        Output: [1,2,3,6,9,8,7,4,5]

        Example 2:
        Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
        Output: [1,2,3,4,8,12,11,10,9,5,6,7]

        Constraints:

            m == matrix.length
            n == matrix[i].length
            1 <= m, n <= 10
            -100 <= matrix[i][j] <= 100


        Extra Test Cases: 
        [[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]] 15 / 25 testcases passed
        https://leetcode.com/problems/spiral-matrix/
        */
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> result = new List<int>();
            int top = 0;
            int left = 0;
            int right = matrix[0].Length - 1;
            int bottom = matrix.Length - 1;

            while (true)
            {
                //Left to Right
                for (int i = left; i <= right; i++)
                {
                    result.Add(matrix[top][i]);
                }
                top++;
                if (left > right || top > bottom) break;

                //Top to Bottom
                for (int i = top; i <= bottom; i++)
                {
                    result.Add(matrix[i][right]);
                }
                right--;
                if (left > right || top > bottom) break;

                //Right to Left
                for (int i = right; i >= left; i--)
                {
                    result.Add(matrix[bottom][i]);
                }
                bottom--;
                if (left > right || top > bottom) break;

                //Bottom to Top
                for (int i = bottom; i >= top; i--)
                {
                    result.Add(matrix[i][left]);
                }
                left++;
                if (left > right || top > bottom) break;
            }//Repeat
            return result;
        }
        #endregion
        #region Set Matrix Zeroes
        /*
        Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.
        You must do it in place.

        Example 1:
        Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
        Output: [[1,0,1],[0,0,0],[1,0,1]]

        Example 2:
        Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
        Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]

        Constraints:

            m == matrix.length
            n == matrix[0].length
            1 <= m, n <= 200
            -2^31 <= matrix[i][j] <= 2^31 - 1

        Follow up:

            A straightforward solution using O(mn) space is probably a bad idea.
            A simple improvement uses O(m + n) space, but still not the best solution.
            Could you devise a constant space solution?

        https://leetcode.com/problems/set-matrix-zeroes/
        Extra Test Cases:
        [[1],[0]] 136 / 193 testcases passed
        [[-4,-2147483648,6,-7,0],[-8,6,-8,-6,0],[2147483647,2,-9,-6,-10]] 163 / 193 testcases passed
        */
        public void SetZeroes(int[][] matrix)
        {
            int rl = matrix.Length, cl = matrix[0].Length;
            bool firstRowHasZeros = matrix[0].Contains(0);

            for (int r = 1; r < rl; r++)
                for (int c = 0; c < cl; c++)
                    if (matrix[r][c] == 0)
                        matrix[r][0] = matrix[0][c] = 0;

            for (int r = 1; r < rl; r++)
                if (matrix[r][0] == 0)
                    Array.Fill(matrix[r], 0);

            for (int c = 0; c < cl; c++)
                if (matrix[0][c] == 0)
                    for (int r = 0; r < rl; r++)
                        matrix[r][c] = 0;

            if (firstRowHasZeros)
                Array.Fill(matrix[0], 0);
        }
        #endregion Set Matrix Zeroes
        #region Happy Number
        /*
        Write an algorithm to determine if a number n is happy.
        A happy number is a number defined by the following process:

            Starting with any positive integer, replace the number by the sum of the squares of its digits.
            Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
            Those numbers for which this process ends in 1 are happy.

        Return true if n is a happy number, and false if not.

        Example 1:

        Input: n = 19
        Output: true
        Explanation:
        12 + 92 = 82
        82 + 22 = 68
        62 + 82 = 100
        12 + 02 + 02 = 1

        Example 2:

        Input: n = 2
        Output: false

        Constraints:

            1 <= n <= 231 - 1

        https://leetcode.com/problems/happy-number/
        n = 4   4 / 420 testcases passed
        n = 1   9 / 420 testcases passed
        n = 7   10 / 420 testcases passed
        */
        public class Solution
        {
            public bool IsHappy(int n)
            {
                HashSet<int> orgs = new HashSet<int>();

                while (n != 1)
                {
                    int tResult = 0;
                    while (n != 0)
                    {
                        tResult += (n % 10) * (n % 10);
                        n = n / 10;
                    }

                    if (tResult == 1)
                        return true;

                    n = tResult;

                    if (orgs.Contains(n))
                        return false;

                    orgs.Add(n);
                }

                if (n == 1)
                    return true;

                return false;
            }
        }
        #endregion Happy Number
        #region Plus One
        /*
        You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. The digits are ordered from most significant to least significant in left-to-right order. 
        The large integer does not contain any leading 0's.
        Increment the large integer by one and return the resulting array of digits.

        Example 1:
        Input: digits = [1,2,3]
        Output: [1,2,4]
        Explanation: The array represents the integer 123.
        Incrementing by one gives 123 + 1 = 124.
        Thus, the result should be [1,2,4].

        Example 2:
        Input: digits = [4,3,2,1]
        Output: [4,3,2,2]
        Explanation: The array represents the integer 4321.
        Incrementing by one gives 4321 + 1 = 4322.
        Thus, the result should be [4,3,2,2].

        Example 3:

        Input: digits = [9]
        Output: [1,0]
        Explanation: The array represents the integer 9.
        Incrementing by one gives 9 + 1 = 10.
        Thus, the result should be [1,0].

        Constraints:

            1 <= digits.length <= 100
            0 <= digits[i] <= 9
            digits does not contain any leading 0's.


        digits = [1,2,3] 4 / 111 testcases passed
        digits = [1,0,0,0,0] 50 / 111 testcases passed
        digits = [9] 100 / 111 testcases passed
        digits = [8,9,9,9] 108 / 111 testcases passed Sep 16th 2022
        digits = [1] 101 / 109 testcases passed
        digits = [9,9] 108 / 111 testcases passed May 27th 2024
        */
        public int[] PlusOne(int[] digits)
        {
            int carry = 1;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] = digits[i] + carry;
                carry = 0;
                if (digits[i] == 10)
                {
                    digits[i] = 0;
                    carry = 1;
                }

            }

            if (carry == 1)
            {
                List<int> temp = digits.ToList();
                temp.Insert(0, 1);
                return temp.ToArray();
            }
            return digits;
        }
        #endregion Plus One
        #region Pow(x, n)
        /*
        Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

        Example 1:
        Input: x = 2.00000, n = 10
        Output: 1024.00000

        Example 2:
        Input: x = 2.10000, n = 3
        Output: 9.26100

        Example 3:
        Input: x = 2.00000, n = -2
        Output: 0.25000
        Explanation: 2-2 = 1/22 = 1/4 = 0.25

        Constraints:
            -100.0 < x < 100.0
            -231 <= n <= 231-1
            n is an integer.
            Either x is not zero or n > 0.
            -104 <= xn <= 104

        x = 0.44528 n =  0 285 / 307 testcases passed
        x = 1.00000 n = -2147483648 291 / 306 testcases passed
        x = 0.00001 n = 2147483647 300 / 307 testcases passed
        x= -1.00000 n = 2147483647
        https://leetcode.com/problems/powx-n/
        */
        public double MyPow(double x, long n)
        {
            x = helper(x, Math.Abs(n));
            return n > 0 ? x : 1 / x;
        }

        public double helper(double x, long n)
        {
            if (n == 0)
                return 1;

            if (x == 0)
                return 0;

            double result = helper(x, n / 2);
            result = result * result;
            return n % 2 == 1 ? result * x : result;
        }
        #endregion Pow(x, n)
        #region Multiply Strings
        /*
        Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.
        Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.

        Example 1:
        Input: num1 = "2", num2 = "3"
        Output: "6"

        Example 2:
        Input: num1 = "123", num2 = "456"
        Output: "56088"

        Constraints:

            1 <= num1.length, num2.length <= 200
            num1 and num2 consist of digits only.
            Both num1 and num2 do not contain any leading zero, except the number 0 itself.
        
        https://leetcode.com/problems/multiply-strings/
        */
        public string Multiply(string num1, string num2)
        {

            if (string.Equals(num1, "0") || string.Equals(num2, "0"))
                return "0";

            char[] n1ar = num1.ToArray();
            char[] n2ar = num2.ToArray();
            int[] resultarr = new int[n1ar.Length + n2ar.Length];
            //reverse it and go from left to right
            Array.Reverse(n1ar);
            Array.Reverse(n2ar);
            for (int ar1 = 0; ar1 < n1ar.Length; ar1++)
            {
                for (int ar2 = 0; ar2 < n2ar.Length; ar2++)
                {
                    int n1num = n1ar[ar1] - '0';
                    int n2num = n2ar[ar2] - '0';
                    var digit = (n1num * n2num);
                    resultarr[ar1 + ar2] += digit;
                    resultarr[ar1 + ar2 + 1] += (resultarr[ar1 + ar2]) / 10;
                    resultarr[ar1 + ar2] = (resultarr[ar1 + ar2]) % 10;

                }
            }

            Array.Reverse(resultarr);
            StringBuilder results = new();
            int startPoint = 0;

            for (int i = 0; i < resultarr.Length; i++)
            {
                if (resultarr[i] != 0)
                    break;
                startPoint++;


            }

         resultarr = resultarr.Reverse().ToArray();

            return results.ToString();
        }
        #endregion Multiply Strings

    }
}