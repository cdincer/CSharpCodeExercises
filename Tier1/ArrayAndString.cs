using System;
using System.Collections.Generic;

namespace Tier1
{
    //https://leetcode.com/explore/learn/card/array-and-string/
    public class ArrayAndString
    {
        #region Introduction to  Array
        #region Find Pivot Index
        /*
             Find Pivot Index

            Given an array of integers nums, calculate the pivot index of this array.
            The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers strictly to the index's right.
            If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
            Return the leftmost pivot index. If no such index exists, return -1.
         
            Example 1:

            Input: nums = [1,7,3,6,5,6]
            Output: 3
            Explanation:
            The pivot index is 3.
            Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
            Right sum = nums[4] + nums[5] = 5 + 6 = 11

            Example 2:

            Input: nums = [1,2,3]
            Output: -1
            Explanation:
            There is no index that satisfies the conditions in the problem statement.

            Example 3:

            Input: nums = [2,1,-1]
            Output: 0
            Explanation:
            The pivot index is 0.
            Left sum = 0 (no elements to the left of index 0)
            Right sum = nums[1] + nums[2] = 1 + -1 = 0
           
            Constraints:

                1 <= nums.length <= 104
                -1000 <= nums[i] <= 1000     
                https://leetcode.com/problems/find-pivot-index/solution/       
        */
        public int PivotIndex(int[] nums)
        {
            int sum = 0, leftsum = 0;
            foreach (int x in nums) sum += x;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (leftsum == sum - leftsum - nums[i]) return i;
                leftsum += nums[i];
            }
            return -1;
        }

        #endregion
        #region Largest Number At Least Twice of Others
        /*
        You are given an integer array nums where the largest integer is unique.

        Determine whether the largest element in the array is at least twice as much as every other number in the array. 
        If it is, return the index of the largest element, or return -1 otherwise.     
        Example 1:

        Input: nums = [3,6,1,0]
        Output: 1
        Explanation: 6 is the largest integer.
        For every other number in the array x, 6 is at least twice as big as x.
        The index of value 6 is 1, so we return 1.

        Example 2:

        Input: nums = [1,2,3,4]
        Output: -1
        Explanation: 4 is less than twice the value of 3, so we return -1.
     
        Constraints:

            2 <= nums.length <= 50
            0 <= nums[i] <= 100
            The largest element in nums is unique.

        https://leetcode.com/problems/largest-number-at-least-twice-of-others/
        */
        public int DominantIndex(int[] nums)
        {
            int location = -1;
            int biggest = -1;


            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > biggest)
                {
                    biggest = nums[i];
                    location = i;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (biggest < nums[i] * 2 && nums[i] != nums[location])
                {
                    return -1;
                }
            }
            return location;
        }
        #endregion
        #region Plus One
        /*
        Plus One

        You are given a large integer represented as an integer array digits,
         where each digits[i] is the ith digit of the integer. 
         The digits are ordered from most significant to least significant in left-to-right order. 
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

        https://leetcode.com/problems/plus-one/
        */
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 9)
                {
                    digits[i]++;
                    break;
                }
                else
                {
                    digits[i] = 0;
                }
            }
            if (digits[0] == 0)
            {
                int[] res = new int[digits.Length + 1];
                res[0] = 1;
                return res;
            }
            return digits;
        }
        #endregion
        #endregion
        #region 2D Arrays
        #region Diagonal Traverse
        /*
            Given an m x n matrix mat, return an array of all the elements of the array in a diagonal order.
         
            Example 1:

            Input: mat = [[1,2,3],[4,5,6],[7,8,9]]
            Output: [1,2,4,7,5,3,6,8,9]

            Example 2:

            Input: mat = [[1,2],[3,4]]
            Output: [1,2,3,4]
           
            Constraints:

                m == mat.length
                n == mat[i].length
                1 <= m, n <= 104
                1 <= m * n <= 104
                -105 <= mat[i][j] <= 105

        https://leetcode.com/problems/diagonal-traverse/

        Test cases for VSCode:
         int[][] twoDArray = new int[][]
            {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
            };
         int[][] twoDArray = new int[][]
            {
            new int[] {1,2,3,4,5},
            new int[] {6,7,8,9,10},
            new int[] {11,12,13,14,15},
            new int[] {16,17,18,19,20},
            };
        */
        public int[] FindDiagonalOrder(int[][] mat)
        {
            // Check for empty matrices
            if (mat == null || mat.Length == 0)
            {
                return new int[0];
            }

            // Variables to track the size of the matrix
            int rowLength = mat.Length;
            int columnLength = mat[0].Length;

            // The two arrays as explained in the algorithm
            int[] result = new int[rowLength * columnLength];
            int resultLocationCounter = 0;
            List<int> intermediate = new List<int>();

            // We have to go over all the elements in the first
            // row and the last column to cover all possible diagonals
            for (int mover = 0; mover < rowLength + columnLength - 1; mover++)
            {

                // Clear the intermediate array every time we start
                // to process another diagonal
                intermediate.Clear();

                // We need to figure out the "head" of this diagonal
                // The elements in the first row and the last column
                // are the respective heads.
                int rowHead = mover < columnLength ? 0 : mover - columnLength + 1;
                int columnHead = mover < columnLength ? mover : columnLength - 1;

                // Iterate until one of the indices goes out of scope
                // Take note of the index math to go down the diagonal
                while (rowHead < rowLength && columnHead > -1)
                {

                    intermediate.Add(mat[rowHead][columnHead]);
                    ++rowHead;
                    --columnHead;
                }

                // Reverse even numbered diagonals. The
                // article says we have to reverse odd 
                // numbered articles but here, the numbering
                // is starting from 0 :P
                if (mover % 2 == 0)
                {
                    intermediate.Reverse();
                }

                for (int i = 0; i < intermediate.Count; i++)
                {
                    result[resultLocationCounter++] = intermediate[i];
                }
            }
            return result;

        }
        #endregion
        #region Spiral Matrix 1
        /*
        Given an m x n matrix, return all elements of the matrix in spiral order.
        https://leetcode.com/problems/spiral-matrix/description/

             Test cases for VSCode:
         int[][] twoDArray = new int[][]
            {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9 }
            };
         int[][] twoDArray = new int[][]
            {
            new int[] {1,2,3,4,5},
            new int[] {6,7,8,9,10},
            new int[] {11,12,13,14,15},
            new int[] {16,17,18,19,20},
            };
        */
        public IList<int> SpiralOrder(int[][] matrix)
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
        #region Pascal's Triangle
        /*
        Given an integer numRows, return the first numRows of Pascal's triangle.

        In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
        https://leetcode.com/problems/pascals-triangle/description/
        */
        public IList<IList<int>> Generate(int numRows)
        {

            int[][] answer = new int[numRows][];

            for (int i = 0; i < numRows; i++)
            {
                answer[i] = new int[i + 1];
                answer[i][0] = answer[i][i] = 1;
                for (int j = 1; j < i; j++)
                {
                    answer[i][j] = answer[i - 1][j] + answer[i - 1][j - 1];
                }
            }

            return answer;
        }
        #endregion

        #endregion



    }
}