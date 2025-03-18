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
        C# Sample Test Cases:
               int[][] RotateArr1 = new int[][]
            {
                new int[] {1,2,3},
                new int[] {4,5,6},
                new int[] {7,8,9}
             };

             int[][] RotateArr2 = new int[][]
            {
                new int[] {5,1,9,11},
                new int[] {2,4,8,10},
                new int[] {13,3,6,7},
                new int[] {15,14,12,16}
             };
        */
        public void Rotate(int[][] matrix)
        {
            int left = 0;
            int right = matrix.Length - 1;
            
            while (left < right)
            {
                int limit = right - left;
                for (int i = 0; i < limit; i++)
                {
                    int top = left;
                    int bottom = right;

                    int topLeft = matrix[top][left + i];
                    // to Top Left from Bottom Left
                    matrix[top][left + i] = matrix[bottom - i][left]; 
                    //to Bottom Left from Bottom Right
                    matrix[bottom - i][left] = matrix[bottom][right - i];
                    //to Bottom Right from Top Right
                    matrix[bottom][right - i] = matrix[top + i][right];
                    //to Top Right from Top Left
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
       
       #region Alternative
        public IList<int> SpiralOrder2(int[][] matrix)
        {
            List<int> result = new List<int>();
            if (matrix == null || matrix.Length == 0) return result;

            int startRow = 0, endRow = matrix.Length - 1;
            int startCol = 0, endCol = matrix[0].Length - 1;
            int dir = 0;

            while (startRow <= endRow && startCol <= endCol)
            {
                switch (dir)
                {
                    case 0: //MOVE RIGHT
                        for (int col = startCol; col <= endCol; col++)
                            result.Add(matrix[startRow][col]);
                        startRow++;
                        break;
                    case 1: //MOVE DOWN
                        for (int row = startRow; row <= endRow; row++)
                            result.Add(matrix[row][endCol]);
                        endCol--;
                        break;
                    case 2://MOVE LEFT
                        for (int col = endCol; col >= startCol; col--)
                            result.Add(matrix[endRow][col]);
                        endRow--;
                        break;
                    case 3://MOVE UP
                        for (int row = endRow; row >= startRow; row--)
                            result.Add(matrix[row][startCol]);
                        startCol++;
                        break;
                }
                dir = (dir + 1) % 4;
            }
            return result;
        }
       #endregion
       
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
        #region Detect Squares
        /*
        You are given a stream of points on the X-Y plane. Design an algorithm that:
        Adds new points from the stream into a data structure. Duplicate points are allowed and should be treated as different points.
        Given a query point, counts the number of ways to choose three points from the data structure such that the three points and the query point form an axis-aligned square with positive area.

        An axis-aligned square is a square whose edges are all the same length and are either parallel or perpendicular to the x-axis and y-axis.

        Implement the DetectSquares class:

            DetectSquares() Initializes the object with an empty data structure.
            void add(int[] point) Adds a new point point = [x, y] to the data structure.
            int count(int[] point) Counts the number of ways to form axis-aligned squares with point point = [x, y] as described above.

        Example 1:
        Input
        ["DetectSquares", "add", "add", "add", "count", "count", "add", "count"]
        [[], [[3, 10]], [[11, 2]], [[3, 2]], [[11, 10]], [[14, 8]], [[11, 2]], [[11, 10]]]
        Output
        [null, null, null, null, 1, 0, null, 2]

        Explanation
        DetectSquares detectSquares = new DetectSquares();
        detectSquares.add([3, 10]);
        detectSquares.add([11, 2]);
        detectSquares.add([3, 2]);
        detectSquares.count([11, 10]); // return 1. You can choose:
                                    //   - The first, second, and third points
        detectSquares.count([14, 8]);  // return 0. The query point cannot form a square with any points in the data structure.
        detectSquares.add([11, 2]);    // Adding duplicate points is allowed.
        detectSquares.count([11, 10]); // return 2. You can choose:
                                    //   - The first, second, and third points
                                    //   - The first, third, and fourth points

        Constraints:

            point.length == 2
            0 <= x, y <= 1000
            At most 3000 calls in total will be made to add and count.
        
        Extra Test Cases:
        23 / 54 testcases passed
        ["DetectSquares","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count","add","add","add","count"]
        [[],[[5,10]],[[10,5]],[[10,10]],[[5,5]],[[3,0]],[[8,0]],[[8,5]],[[3,5]],[[9,0]],[[9,8]],[[1,8]],[[1,0]],[[0,0]],[[8,0]],[[8,8]],[[0,8]],[[1,9]],[[2,9]],[[2,10]],[[1,10]],[[7,8]],[[2,3]],[[2,8]],[[7,3]],[[9,10]],[[9,5]],[[4,5]],[[4,10]],[[0,9]],[[4,5]],[[4,9]],[[0,5]],[[1,10]],[[10,1]],[[10,10]],[[1,1]],[[10,0]],[[2,0]],[[2,8]],[[10,8]],[[7,6]],[[4,6]],[[4,9]],[[7,9]],[[10,9]],[[10,0]],[[1,0]],[[1,9]],[[0,9]],[[8,1]],[[0,1]],[[8,9]],[[3,9]],[[10,9]],[[3,2]],[[10,2]],[[3,8]],[[9,2]],[[3,2]],[[9,8]],[[0,9]],[[7,9]],[[0,2]],[[7,2]],[[10,1]],[[1,10]],[[10,10]],[[1,1]],[[6,10]],[[2,6]],[[6,6]],[[2,10]],[[6,0]],[[6,2]],[[8,2]],[[8,0]],[[6,5]],[[7,4]],[[6,4]],[[7,5]],[[2,10]],[[8,4]],[[2,4]],[[8,10]],[[2,6]],[[2,5]],[[1,5]],[[1,6]],[[10,9]],[[10,0]],[[1,9]],[[1,0]],[[0,9]],[[5,9]],[[0,4]],[[5,4]],[[3,6]],[[9,0]],[[3,0]],[[9,6]],[[0,2]],[[1,1]],[[0,1]],[[1,2]],[[1,7]],[[8,0]],[[8,7]],[[1,0]],[[2,7]],[[4,5]],[[2,5]],[[4,7]],[[6,7]],[[3,7]],[[6,4]],[[3,4]],[[10,2]],[[2,10]],[[2,2]],[[10,10]],[[10,1]],[[1,10]],[[1,1]],[[10,10]],[[2,10]],[[2,9]],[[3,9]],[[3,10]],[[10,1]],[[1,10]],[[1,1]],[[10,10]],[[10,4]],[[10,3]],[[9,4]],[[9,3]],[[6,6]],[[6,10]],[[10,6]],[[10,10]],[[9,7]],[[4,7]],[[9,2]],[[4,2]],[[2,3]],[[2,1]],[[0,3]],[[0,1]],[[2,8]],[[10,8]],[[2,0]],[[10,0]],[[8,4]],[[2,10]],[[8,10]],[[2,4]],[[0,0]],[[9,9]],[[0,9]],[[9,0]],[[5,7]],[[5,8]],[[4,7]],[[4,8]],[[10,10]],[[10,1]],[[1,1]],[[1,10]],[[6,8]],[[7,8]],[[6,9]],[[7,9]],[[4,6]],[[1,6]],[[4,3]],[[1,3]],[[10,1]],[[1,10]],[[10,10]],[[1,1]],[[7,7]],[[7,10]],[[4,7]],[[4,10]],[[0,0]],[[8,0]],[[0,8]],[[8,8]],[[3,5]],[[2,4]],[[3,4]],[[2,5]],[[0,6]],[[0,2]],[[4,2]],[[4,6]],[[5,2]],[[9,6]],[[9,2]],[[5,6]],[[1,1]],[[1,10]],[[10,10]],[[10,1]],[[7,5]],[[2,0]],[[2,5]],[[7,0]],[[1,9]],[[1,2]],[[8,2]],[[8,9]],[[3,8]],[[3,3]],[[8,3]],[[8,8]],[[3,10]],[[9,10]],[[3,4]],[[9,4]],[[0,2]],[[0,10]],[[8,10]],[[8,2]],[[9,4]],[[8,4]],[[8,5]],[[9,5]],[[9,8]],[[4,3]],[[4,8]],[[9,3]],[[4,9]],[[0,5]],[[0,9]],[[4,5]],[[1,3]],[[3,5]],[[1,5]],[[3,3]],[[0,0]],[[0,8]],[[8,0]],[[8,8]],[[2,8]],[[10,0]],[[10,8]],[[2,0]],[[8,1]],[[0,9]],[[8,9]],[[0,1]],[[4,9]],[[4,6]],[[1,9]],[[1,6]],[[0,9]],[[0,8]],[[1,9]],[[1,8]],[[5,1]],[[5,6]],[[10,1]],[[10,6]],[[9,2]],[[2,2]],[[2,9]],[[9,9]],[[5,5]],[[8,5]],[[5,8]],[[8,8]],[[8,0]],[[1,0]],[[8,7]],[[1,7]],[[8,2]],[[5,5]],[[5,2]],[[8,5]],[[6,6]],[[6,8]],[[8,6]],[[8,8]],[[2,10]],[[10,2]],[[2,2]],[[10,10]],[[1,9]],[[8,2]],[[1,2]],[[8,9]],[[7,4]],[[7,2]],[[9,4]],[[9,2]],[[1,9]],[[1,0]],[[10,0]],[[10,9]],[[2,10]],[[2,3]],[[9,10]],[[9,3]],[[10,0]],[[1,0]],[[1,9]],[[10,9]],[[8,10]],[[1,10]],[[1,3]],[[8,3]],[[0,9]],[[9,9]],[[0,0]],[[9,0]],[[7,9]],[[8,9]],[[7,8]],[[8,8]],[[3,1]],[[9,7]],[[9,1]],[[3,7]],[[5,9]],[[6,9]],[[5,8]],[[6,8]],[[0,1]],[[0,10]],[[9,10]],[[9,1]],[[8,0]],[[8,2]],[[10,2]],[[10,0]],[[8,0]],[[0,8]],[[8,8]],[[0,0]],[[6,7]],[[5,8]],[[5,7]],[[6,8]],[[0,9]],[[0,2]],[[7,9]],[[7,2]],[[5,0]],[[5,5]],[[10,0]],[[10,5]],[[1,10]],[[10,10]],[[10,1]],[[1,1]],[[9,2]],[[9,10]],[[1,2]],[[1,10]],[[1,10]],[[10,1]],[[10,10]],[[1,1]],[[9,9]],[[0,9]],[[0,0]],[[9,0]],[[9,6]],[[9,3]],[[6,3]],[[6,6]],[[10,4]],[[6,0]],[[10,0]],[[6,4]],[[6,8]],[[0,2]],[[0,8]],[[6,2]],[[7,9]],[[0,9]],[[7,2]],[[0,2]],[[9,1]],[[9,10]],[[0,10]],[[0,1]],[[10,0]],[[10,9]],[[1,9]],[[1,0]],[[1,6]],[[1,9]],[[4,9]],[[4,6]],[[0,8]],[[1,9]],[[0,9]],[[1,8]],[[1,1]],[[9,1]],[[1,9]],[[9,9]],[[2,5]],[[2,9]],[[6,5]],[[6,9]],[[7,3]],[[2,3]],[[2,8]],[[7,8]],[[9,4]],[[4,4]],[[9,9]],[[4,9]],[[4,4]],[[2,4]],[[4,2]],[[2,2]],[[0,3]],[[0,2]],[[1,3]],[[1,2]],[[10,9]],[[10,2]],[[3,2]],[[3,9]],[[5,6]],[[10,6]],[[10,1]],[[5,1]],[[9,0]],[[0,9]],[[9,9]],[[0,0]],[[5,6]],[[9,2]],[[9,6]],[[5,2]],[[3,3]],[[10,3]],[[10,10]],[[3,10]],[[2,4]],[[2,10]],[[8,4]],[[8,10]],[[4,9]],[[1,9]],[[4,6]],[[1,6]],[[1,8]],[[9,0]],[[1,0]],[[9,8]],[[10,3]],[[5,8]],[[5,3]],[[10,8]],[[8,2]],[[0,10]],[[8,10]],[[0,2]],[[9,0]],[[2,7]],[[9,7]],[[2,0]],[[0,4]],[[5,9]],[[0,9]],[[5,4]],[[5,3]],[[10,3]],[[5,8]],[[10,8]],[[6,4]],[[7,4]],[[6,5]],[[7,5]],[[9,1]],[[0,1]],[[9,10]],[[0,10]],[[5,10]],[[5,7]],[[8,7]],[[8,10]],[[8,0]],[[8,7]],[[1,7]],[[1,0]],[[1,1]],[[9,9]],[[1,9]],[[9,1]],[[3,1]],[[3,5]],[[7,5]],[[7,1]],[[5,8]],[[5,3]],[[10,8]],[[10,3]],[[0,9]],[[2,7]],[[2,9]],[[0,7]],[[9,3]],[[9,7]],[[5,3]],[[5,7]],[[0,0]],[[9,0]],[[9,9]],[[0,9]],[[6,4]],[[4,2]],[[4,4]],[[6,2]],[[1,9]],[[1,5]],[[5,5]],[[5,9]],[[7,7]],[[0,7]],[[0,0]],[[7,0]],[[1,3]],[[1,9]],[[7,3]],[[7,9]],[[0,9]],[[9,9]],[[9,0]],[[0,0]],[[1,8]],[[3,6]],[[3,8]],[[1,6]]]
        https://leetcode.com/problems/detect-squares/
        */
        public class DetectSquares
        {

            private Dictionary<(int x, int y), int> _pointsCounter = new();
            private List<(int x, int y)> _points = new();

            public DetectSquares() { }

            public void Add(int[] point)
            {
                var p = (point[0], point[1]);
                _points.Add(p);
                _pointsCounter[p] = 1 + _pointsCounter.GetValueOrDefault(p, 0);
            }

            public int Count(int[] point)
            {
                int px = point[0], py = point[1];
                int result = 0;

                foreach (var (x, y) in _points)
                {

                    if (Math.Abs(px - x) != Math.Abs(py - y)
                        || x == px || y == py)
                    {
                        continue;
                    }
                    result += _pointsCounter.GetValueOrDefault((px, y), 0) * _pointsCounter.GetValueOrDefault((x, py), 0);
                }
                return result;
            }
        }
        #endregion Detect Squares
    }
}