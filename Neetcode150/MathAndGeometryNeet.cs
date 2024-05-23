using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

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
            -231 <= matrix[i][j] <= 231 - 1

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

    }
}