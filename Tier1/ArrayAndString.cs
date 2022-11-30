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
        Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The relative order of the elements may be changed.

        Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.

        Return k after placing the final result in the first k slots of nums.

        Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.

        Custom Judge:

        The judge will test your solution with the following code:

        int[] nums = [...]; // Input array
        int val = ...; // Value to remove
        int[] expectedNums = [...]; // The expected answer with correct length.
                                    // It is sorted with no values equaling val.

        int k = removeElement(nums, val); // Calls your implementation

        assert k == expectedNums.length;
        sort(nums, 0, k); // Sort the first k elements of nums
        for (int i = 0; i < actualLength; i++) {
            assert nums[i] == expectedNums[i];
        }

        If all assertions pass, then your solution will be accepted.

        

        Example 1:

        Input: nums = [3,2,2,3], val = 3
        Output: 2, nums = [2,2,_,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 2.
        It does not matter what you leave beyond the returned k (hence they are underscores).

        Example 2:

        Input: nums = [0,1,2,2,3,0,4,2], val = 2
        Output: 5, nums = [0,1,4,0,3,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums containing 0, 0, 1, 3, and 4.
        Note that the five elements can be returned in any order.
        It does not matter what you leave beyond the returned k (hence they are underscores).

        

        Constraints:

            0 <= nums.length <= 100
            0 <= nums[i] <= 50
            0 <= val <= 100

        https://leetcode.com/problems/remove-element/description/
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

        #region MaxConsecutiveOnes
        /*
        Given a binary array nums, return the maximum number of consecutive 1's in the array.
        
        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.

        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
       
        Constraints:

            1 <= nums.length <= 105
            nums[i] is either 0 or 1.

        https://leetcode.com/problems/max-consecutive-ones/description/
        */
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int k = 0;
            int l = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    k++;
                }
                else
                {
                    l = Math.Max(k, l);
                    k = 0;
                }
            }
            l = Math.Max(k, l);

            return l;
        }
        #endregion

        #region Minimum Size Subarray Sum
        /*
        Given an array of positive integers nums and a positive integer target, return the minimal length of a subarray whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.
 
        Example 1:

        Input: target = 7, nums = [2,3,1,2,4,3]
        Output: 2
        Explanation: The subarray [4,3] has the minimal length under the problem constraint.

        Example 2:

        Input: target = 4, nums = [1,4,4]
        Output: 1

        Example 3:

        Input: target = 11, nums = [1,1,1,1,1,1,1,1]
        Output: 0

        

        Constraints:

            1 <= target <= 109
            1 <= nums.length <= 105
            1 <= nums[i] <= 104
        
        Follow up: If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log(n)).
        https://leetcode.com/problems/minimum-size-subarray-sum/description/

        Sample test:
        213
        [12,28,83,4,25,26,25,2,25,25,25,12]Expected out come:8
        */
        public int MinSubArrayLen(int target, int[] nums)
        {
            int i = 0;
            int j = 0;
            int min = int.MaxValue;
            int sum = 0;

            while (j < nums.Length)
            {
                sum += nums[j];
                while (target <= sum)
                {
                    min = Math.Min(min, j - i + 1);
                    sum -= nums[i];
                    i++;
                }
                j++;
            }
            return min == int.MaxValue ? 0 : min;
        }
        #endregion

        #endregion
        #region Conclusion
        #region RotateArray
        /*
          Rotate Array

             Given an array, rotate the array to the right by k steps, where k is non-negative.

            Example 1:

            Input: nums = [1,2,3,4,5,6,7], k = 3
            Output: [5,6,7,1,2,3,4]
            Explanation:
            rotate 1 steps to the right: [7,1,2,3,4,5,6]
            rotate 2 steps to the right: [6,7,1,2,3,4,5]
            rotate 3 steps to the right: [5,6,7,1,2,3,4]

            Example 2:

            Input: nums = [-1,-100,3,99], k = 2
            Output: [3,99,-1,-100]
            Explanation: 
            rotate 1 steps to the right: [99,-1,-100,3]
            rotate 2 steps to the right: [3,99,-1,-100]
                   
            Constraints:

                1 <= nums.length <= 105
                -231 <= nums[i] <= 231 - 1
                0 <= k <= 105
        

            Follow up:

            Try to come up with as many solutions as you can. There are at least three different ways to solve this problem.
            Could you do it in-place with O(1) extra space?
            https://leetcode.com/problems/rotate-array/description/
            Speed:240 ms Beats:76.85% Memory:48.6 MB Beats:98.84%
        */
        public void Rotate(int[] nums, int k)
        {
            int[] a = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                a[(i + k) % nums.Length] = nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = a[i];
            }
        }
        #endregion
        #region Pascal's Triangle II
        /*
        Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.

        In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:

        Example 1:

        Input: rowIndex = 3
        Output: [1,3,3,1]

        Example 2:

        Input: rowIndex = 0
        Output: [1]

        Example 3:

        Input: rowIndex = 1
        Output: [1,1]

         

        Constraints:

            0 <= rowIndex <= 33

        
        Follow up: Could you optimize your algorithm to use only O(rowIndex) extra space?
        https://leetcode.com/problems/pascals-triangle-ii/description/
        Runtime:96 ms Beats:93.12%
        */

        public IList<int> GetRow(int rowIndex)
        {
            List<int> MyList = new List<int>();
            int[][] myArray = new int[rowIndex + 1][];

            if (rowIndex == 0)
            {
                MyList.Add(1);
                return MyList;
            }
            for (int r = 0; r < rowIndex + 1; r++)
            {
                myArray[r] = new int[r + 1];
                myArray[r][0] = myArray[r][r] = 1;
                for (int c = 1; c < r; c++)
                {
                    myArray[r][c] = myArray[r - 1][c] + myArray[r - 1][c - 1];
                }
            }

            for (int i = 0; i < myArray[rowIndex].Length; i++)
            {
                MyList.Add(myArray[rowIndex][i]);
            }
            return MyList;
        }

        #endregion
        #region Reverse Words in a String
        /*
        Given an input string s, reverse the order of the words.

        A word is defined as a sequence of non-space characters. The words in s will be separated by at least one space.

        Return a string of the words in reverse order concatenated by a single space.

        Note that s may contain leading or trailing spaces or multiple spaces between two words. The returned string should only have a single space separating the words. Do not include any extra spaces.

         

        Example 1:

        Input: s = "the sky is blue"
        Output: "blue is sky the"

        Example 2:

        Input: s = "  hello world  "
        Output: "world hello"
        Explanation: Your reversed string should not contain leading or trailing spaces.

        Example 3:

        Input: s = "a good   example"
        Output: "example good a"
        Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.

         

        Constraints:

            1 <= s.length <= 104
            s contains English letters (upper-case and lower-case), digits, and spaces ' '.
            There is at least one word in s.

         

        Follow-up: If the string data type is mutable in your language, can you solve it in-place with O(1) extra space?

        https://leetcode.com/problems/reverse-words-in-a-string/
        Runtime:77 ms Beats:97.68% Memory:38.6 MB Beats:14.99%
        */
        public string ReverseWords(string s)
        {

            string[] Items = s.Split(" ");
            StringBuilder item = new StringBuilder();

            for (int i = Items.Length - 1; i > 0; i--)
            {
                if (!String.IsNullOrWhiteSpace(Items[i]))
                    item.Append(Items[i] + " ");
            }

            if (!String.IsNullOrWhiteSpace(Items[0]))
                item.Append(Items[0]);

            if (item[item.Length - 1] == ' ')
            {
                item.Remove(item.Length - 1, 1);
            }

            return item.ToString();
        }
        #endregion
        #region Reverse Words in a String III
        /*
        Given a string s, reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.
       
        Example 1:

        Input: s = "Let's take LeetCode contest"
        Output: "s'teL ekat edoCteeL tsetnoc"

        Example 2:

        Input: s = "God Ding"
        Output: "doG gniD"

         

        Constraints:

            1 <= s.length <= 5 * 104
            s contains printable ASCII characters.
            s does not contain any leading or trailing spaces.
            There is at least one word in s.
            All the words in s are separated by a single space.

        https://leetcode.com/problems/reverse-words-in-a-string-iii/description/
        Runtime:130 ms Beats:74.40% Memory:42.1 MB Beats:43.79%
        */
        public string ReverseWordsIII(string s)
        {
            char[] items = s.ToCharArray();
            Array.Reverse(items);
            StringBuilder answer = new StringBuilder();
            for (int i = 0; i < items.Length; i++)
            {
                answer.Append(items[i]);
            }
            //"tsetnoc edoCteeL ekat s'teL"
            //split these items have these elements
            string straightItems = answer.ToString();
            string[] straightArray = straightItems.Split(" ");
            answer.Clear();
            for (int i = straightArray.Length - 1; i >= 0; i--)
            {
                answer.Append(straightArray[i] + " ");
            }

            if (answer[answer.Length - 1] == ' ')
            {
                answer.Remove(answer.Length - 1, 1);
            }

            return answer.ToString();
        }
        #endregion
        #region Remove Duplicates From Sorted Array
        /*
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.

        Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.

        Return k after placing the final result in the first k slots of nums.

        Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.

        Custom Judge:

        The judge will test your solution with the following code:

        int[] nums = [...]; // Input array
        int[] expectedNums = [...]; // The expected answer with correct length

        int k = removeDuplicates(nums); // Calls your implementation

        assert k == expectedNums.length;
        for (int i = 0; i < k; i++) {
            assert nums[i] == expectedNums[i];
        }

        If all assertions pass, then your solution will be accepted.

         

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).

        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).

         

        Constraints:

            1 <= nums.length <= 3 * 104
            -100 <= nums[i] <= 100
            nums is sorted in non-decreasing order.

        Example test cases: nums = [1,1,1] expected = [1]
        https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        */
        public int RemoveDuplicates(int[] nums)
        {
            int insertIndex = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                // We skip to next index if we see a duplicate element
                if (nums[i - 1] != nums[i])
                {
                    /* Storing the unique element at insertIndex index and incrementing
                       the insertIndex by 1 */
                    nums[insertIndex] = nums[i];
                    insertIndex++;
                }
            }
            return insertIndex;
        }
        #endregion
        #region Move Zeroes
        /*
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.
      
        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]

        Example 2:

        Input: nums = [0]
        Output: [0]
       
        Constraints:

            1 <= nums.length <= 104
            -231 <= nums[i] <= 231 - 1

         
        Follow up: Could you minimize the total number of operations done?
        https://leetcode.com/problems/move-zeroes/description/
        */
        public void MoveZeroes(int[] nums)
        {

            int insertIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[insertIndex] = nums[i];
                    insertIndex++;
                }
            }

            for (int i = insertIndex; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

        }
        #endregion
        #endregion

    }
}