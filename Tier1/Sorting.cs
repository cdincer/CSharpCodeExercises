using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpCodeExercises.Tier1
{
    //https://leetcode.com/explore/learn/card/sorting/693/introduction/ 
    public class Sorting
    {
        #region Comparison Based Sort
        #region Sort Colors -- Selection Sort
        /*Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.

        We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.

        You must solve this problem without using the library's sort function.
       
        Example 1:

        Input: nums = [2,0,2,1,1,0]
        Output: [0,0,1,1,2,2]

        Example 2:

        Input: nums = [2,0,1]
        Output: [0,1,2]

         

        Constraints:

            n == nums.length
            1 <= n <= 300
            nums[i] is either 0, 1, or 2.

         

        Follow up: Could you come up with a one-pass algorithm using only constant extra space?

        https://leetcode.com/problems/sort-colors/solutions/
        */
         public void SortColors(int[] nums) {
        // Mutates nums so that it is sorted via selecting the minimum element and
        // swapping it with the corresponding index
        int min_index;
        for (int i = 0; i < nums.Length; i++) {
            min_index = i;
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[j] < nums[min_index]) {
                    min_index = j;
                }
            }
            // Swap current index with minimum element in rest of list
            int temp = nums[min_index];
            nums[min_index] = nums[i];
            nums[i] = temp;
        }
    }
        #endregion
        #endregion
    }
}