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
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
        Notice that the solution set must not contain duplicate triplets.

        Example 1:
        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.

        Example 2:
        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.

        Example 3:
        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.

        Constraints:
            3 <= nums.length <= 3000
            -105 <= nums[i] <= 105
            
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
        #region Container With Most Water
        /*
        You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
        Find two lines that together with the x-axis form a container, such that the container contains the most water.
        Return the maximum amount of water a container can store.
        Notice that you may not slant the container.

        Example 1:
        Input: height = [1,8,6,2,5,4,8,3,7]
        Output: 49
        Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.

        Example 2:
        Input: height = [1,1]
        Output: 1

        Constraints:
            n == height.length
            2 <= n <= 105
            0 <= height[i] <= 104

        https://leetcode.com/problems/container-with-most-water/description/
        Extra Test Cases:
        [1,2] 37th Test Case.
        [1,2,4,3] 38th Test Case.
        [1,8,100,2,100,4,8,3,7] 42nd test case
        */
        public int MaxArea(int[] height)
        {
            int MaxVolume = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                int curv = right - left * Math.Min(height[left], height[right]);
                MaxVolume = Math.Max(MaxVolume, curv);
                if (height[left] < height[right])
                {
                    left++;
                }
                {
                    right--;
                }
            }
            return MaxVolume;
        }
        #endregion
        #region Trapping Rain Water
        /*
        https://leetcode.com/problems/trapping-rain-water/
        */
        public int Trap(int[] height)
        {
            int left = 0;
            int right = 0;
            bool[] visited = new bool[height.Length];
            List<catcher> myl = new();

            if (height.Length > 1)
                right = 1;


            if (height[0] == 0 && height.Length > 2)
            {
                left = 1;
                right = 2;
            }
            else if (height[0] == 0 && height.Length == 1)
            {
                return 0;
            }
            int currentHeight = 0;
            catcher newmint = new();

            while (left < height.Length && right < height.Length - 1)
            {
                currentHeight = Math.Max(currentHeight, height[left]);
                newmint.sp = left;
                newmint.sph = height[left];

                if (height[left] > height[right])
                {
                    newmint.ep = right;
                    newmint.eph = height[right];
                    left = right;
                    right++;
                    newmint.width = 1;
                    myl.Add(newmint);
                    newmint = new();

                }
                else if (height[left] < height[right])
                {
                    newmint.ep = right;
                    newmint.eph = height[right];
                    left = right;
                    right++;
                    newmint.width = 1;
                    myl.Add(newmint);
                    newmint = new();
                }

                if (left == right)
                    right++;

                if (newmint.ep == -1)
                    newmint.ep = right;
            }
            
            int sum = 0;
            foreach (catcher catched in myl)
            {
                sum = sum + (catched.width * Math.Min(catched.sph, catched.eph));
                Console.WriteLine("sp " + catched.sp + " ep " + catched.ep + " width " + catched.width);
            }

            return sum;
        }

        public class catcher
        {
            public int sp { get; set; } = -1;
            public int sph { get; set; } = -1;
            public int ep { get; set; } = -1;
            public int eph { get; set; } = -1;
            public int width { get; set; } = 1;
        }


        #endregion
    }
}