using System;
using System.Collections.Generic;
using System.Text;

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
        #region Strings

        #region AddBinary
        /*
        Given two binary strings a and b, return their sum as a binary string.
        Example 1:
        Input: a = "11", b = "1"
        Output: "100"
        Example 2:
        Input: a = "1010", b = "1011"
        Output: "10101"

        Constraints:

        1 <= a.length, b.length <= 104
        a and b consist only of '0' or '1' characters.
        Each string does not contain leading zeros except for the zero itself.
        Extra Test Case:
        "10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101"
        "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011"

        */
        public string AddBinary(string a, string b)
        {
            StringBuilder result = new(); //C# has immutability string builder goes.
            //two pointers starting from the back, just think of adding two regular ints from you add from back
            int i = a.Length - 1;
            int j = b.Length - 1;
            int carry = 0;

            while (i >= 0 || j >= 0 || carry > 0) //Carry check here instead of at the end
            {
                int sum = carry; //if there is a carry from the last addition, add it to carry 
                int aValue = i >= 0 ? a[i--] - '0' : 0;  //we subtract '0' to get the int value of the char from the ascii
                int bValue = j >= 0 ? b[j--] - '0' : 0;

                sum += aValue + bValue;
                result.Insert(0, sum % 2);  //if sum==2 or sum==0 append 0 cause 1+1=0 in this case as this is base 2 (just like 1+9 is 0 if adding ints in columns)
                carry = sum / 2; //if sum==2 we have a carry, else no carry 1/2 rounds down to 0 in integer arithematic
            }

            return result.ToString();

        }
        #endregion

        #region Implement strStr()
        /*
        Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
   
        Example 1:

        Input: haystack = "sadbutsad", needle = "sad"
        Output: 0
        Explanation: "sad" occurs at index 0 and 6.
        The first occurrence is at index 0, so we return 0.

        Example 2:

        Input: haystack = "leetcode", needle = "leeto"
        Output: -1
        Explanation: "leeto" did not occur in "leetcode", so we return -1.
       
        Constraints:

            1 <= haystack.length, needle.length <= 104
            haystack and needle consist of only lowercase English characters.

        https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/solutions/
        Leetcode test cases
        "sadbutsad"
        "sad"
        "leetcodesadbutleetomeeto"
        "leeto"
        "a"
        "a"
        "abc"
        "c"
        "leetcode"
        "leeto"
        */
        public int StrStr(string haystack, string needle)
        {
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                if (haystack.Substring(i, needle.Length) == needle)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region Longest Common Prefix
        /*
        Write a function to find the longest common prefix string amongst an array of strings.

        If there is no common prefix, return an empty string "".

        Example 1:

        Input: strs = ["flower","flow","flight"]
        Output: "fl"

        Example 2:

        Input: strs = ["dog","racecar","car"]
        Output: ""
        Explanation: There is no common prefix among the input strings.

        Constraints:

            1 <= strs.length <= 200
            0 <= strs[i].length <= 200
            strs[i] consists of only lowercase English letters.


        https://leetcode.com/problems/longest-common-prefix/description/
        Test Cases: "ab", "a" 
                    "a"
        */
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return string.Empty;

            int maxLength = 0;

            for (var i = 0; i < strs[0].Length; i++)
            {
                for (var j = 1; j < strs.Length; j++)
                {
                    if (i == strs[j].Length || strs[0][i] != strs[j][i])
                        return strs[0].Substring(0, maxLength);
                }

                maxLength++;
            }

            return strs[0];
        }
        #endregion
        #endregion
        #region Two-pointer Technique
        #region Reverse String
        /*
        Write a function that reverses a string. The input string is given as an array of characters s.

        You must do this by modifying the input array in-place with O(1) extra memory.

        

        Example 1:

        Input: s = ["h","e","l","l","o"]
        Output: ["o","l","l","e","h"]

        Example 2:

        Input: s = ["H","a","n","n","a","h"]
        Output: ["h","a","n","n","a","H"]

        

        Constraints:

            1 <= s.length <= 105
            s[i] is a printable ascii character.


        */
        public void ReverseString(char[] s)
        {

            int e = s.Length - 1;
            for (int b = 0; b < s.Length / 2; b++)
            {
                char temp = s[b];
                s[b] = s[e];
                s[e] = temp;
                e--;
            }
        }
        #endregion
        #region Array Partition I
        /*
        Given an integer array nums of 2n integers, group these integers into n pairs (a1, b1), (a2, b2), ..., (an, bn) such that the sum of min(ai, bi) for all i is maximized. Return the maximized sum.
      
        Example 1:

        Input: nums = [1,4,3,2]
        Output: 4
        Explanation: All possible pairings (ignoring the ordering of elements) are:
        1. (1, 4), (2, 3) -> min(1, 4) + min(2, 3) = 1 + 2 = 3
        2. (1, 3), (2, 4) -> min(1, 3) + min(2, 4) = 1 + 2 = 3
        3. (1, 2), (3, 4) -> min(1, 2) + min(3, 4) = 1 + 3 = 4
        So the maximum possible sum is 4.

        Example 2:

        Input: nums = [6,2,6,5,1,2]
        Output: 9
        Explanation: The optimal pairing is (2, 1), (2, 5), (6, 6). min(2, 1) + min(2, 5) + min(6, 6) = 1 + 2 + 6 = 9.
    
        Constraints:

            1 <= n <= 104
            nums.length == 2 * n
            -104 <= nums[i] <= 104

        https://leetcode.com/problems/array-partition/description/
        */
        public int ArrayPairSum(int[] nums)
        {

            int minimumPossible = 0;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; i += 2)
            {
                minimumPossible += Math.Min(nums[i], nums[i + 1]);
            }
            return minimumPossible;
        }
        #endregion

        #region Two Sum II - Input array is sorted
        /*
        Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.

        Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.

        The tests are generated such that there is exactly one solution. You may not use the same element twice.

        Your solution must use only constant extra space.
  
        Example 1:

        Input: numbers = [2,7,11,15], target = 9
        Output: [1,2]
        Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].

        Example 2:

        Input: numbers = [2,3,4], target = 6
        Output: [1,3]
        Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].

        Example 3:

        Input: numbers = [-1,0], target = -1
        Output: [1,2]
        Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].

        Constraints:

            2 <= numbers.length <= 3 * 104
            -1000 <= numbers[i] <= 1000
            numbers is sorted in non-decreasing order.
            -1000 <= target <= 1000
            The tests are generated such that there is exactly one solution.

        https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
        */
        public int[] TwoSum(int[] numbers, int target)
        {
            int i = 0;
            int j = numbers.Length - 1;

            while (i <= j)
            {
                if (numbers[i] + numbers[j] == target)
                    return new int[] { i + 1, j + 1 };

                if (numbers[i] + numbers[j] < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return new int[] { i + 1, j + 1 };
        }
        #endregion
        #region Remove Element
        /*
        [2,2,3]
        2
        */
        public int RemoveElement(int[] nums, int val)
        {
            int k = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != val)
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;
        }

        #endregion
        #endregion
    }
}