using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Neetcode150
{
    public class TwoPointers
    {
        #region Valid Palindrome
        /*
        A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
        Given a string s, return true if it is a palindrome, or false otherwise.

        Example 1:
        Input: s = "A man, a plan, a canal: Panama"
        Output: true
        Explanation: "amanaplanacanalpanama" is a palindrome.

        Example 2:
        Input: s = "race a car"
        Output: false
        Explanation: "raceacar" is not a palindrome.

        Example 3:
        Input: s = " "
        Output: true
        Explanation: s is an empty string "" after removing non-alphanumeric characters.
        Since an empty string reads the same forward and backward, it is a palindrome.

        Constraints:

            1 <= s.length <= 2 * 105
            s consists only of printable ASCII characters.

        https://leetcode.com/problems/valid-palindrome/
        */
        //Extra Test Case
        //"0P" 462/485
        //On average my code and neetcode's are equal in runtime, same with memory.
        public bool IsPalindrome(string s)
        {
            StringBuilder myreader = new();

            for (int i = 0; i < s.Length; i++)
            {
                char converted = Char.ToLower(s[i]);
                if (Char.IsLetter(converted) || Char.IsNumber(converted))
                {
                    myreader.Append(converted);
                }
            }

            string myprocessed = myreader.ToString();
            int end = myprocessed.Length - 1;

            for (int i = 0; i < myprocessed.Length; i++)
            {
                if (myprocessed[i] != myprocessed[end - i])
                    return false;
            }

            return true;
        }

        public bool IsPalindromeNeet(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (!char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                else if (!char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                else
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }
                    left++;
                    right--;
                }
            }
            return true;
        }
        #endregion
        #region Two Sum II - Input Array Is Sorted
        /*
        Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. 
        Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 < numbers.length.
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
        Extra Test Case:
        [0,0,3,4]
        0
        https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
        */

        //Neetcode solution, explanation is literally Binary Search without the division and extra addition.
        public int[] TwoSum(int[] numbers, int target)
        {

            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum > target)
                {
                    right--;
                }
                else if (sum < target)
                {
                    left++;
                }
                else if (sum == target)
                {
                    return new int[] { left + 1, right + 1 };
                }
            }
            return new int[0];
        }
        #endregion
        #region 3Sum 
        /*
        Backtracking and Two Pointers ?
        https://leetcode.com/problems/3sum/
        */
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            int left, right;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                left = i + 1;
                right = nums.Length - 1;

                while (left < right)
                {
                    if (nums[i] + nums[left] + nums[right] > 0)
                    {
                        right--;
                    }
                    else if (nums[i] + nums[left] + nums[right] < 0)
                    {
                        left++;
                    }
                    else
                    {
                        res.Add(new List<int> { nums[i], nums[left], nums[right] });
                        left++;
                        while (nums[left] == nums[left - 1] && left < right)
                        {
                            left++;
                        }
                    }
                }
            }
            return res;
        }
        #endregion

    }
}