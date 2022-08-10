using System;

namespace Tier1
{
    public class BinarySearch
    {

        public int BinarySearchOriginal(int[] nums, int target)
        {
            int pivot, left = 0, right = nums.Length;

            while (left <= right)
            {
                pivot = left + (right - left) / 2;

                if (nums[pivot] == target) return pivot;
                if (nums[pivot] > target) right = pivot - 1;
                else { left = pivot + 1; }
            }

            return 0;
        }
        //Binary Search Template 1
        public int MySqrt(int x)
        {
            if (x <= 1) return x;
            int start = 1;
            int end = x / 2;

            while (start < end)
            {
                // start is not always moving and hence we can get stuck in infinite loop with mid calculation
                // Adding 1 to mid everytime to ensure we always move the mid
                int mid = (start + (end - start) / 2) + 1;

                // use division instead of multiplication to avoid overflow
                int div = x / mid;
                if (div == mid) return mid;
                if (div > mid) start = mid;
                else end = mid - 1;
            }

            return start;
        }

        #region question
        /*
        We are playing the Guess Game. The game is as follows:

        I pick a number from 1 to n. You have to guess which number I picked.

        Every time you guess wrong, I will tell you whether the number I picked is higher or lower than your guess.

        You call a pre-defined API int guess(int num), which returns three possible results:

        -1: Your guess is higher than the number I picked (i.e. num > pick).
         1: Your guess is lower than the number I picked (i.e. num < pick).
         0: your guess is equal to the number I picked (i.e. num == pick).

         Return the number that I picked.
         Math.abs spots below replaced a special API on leetcode,it returns a guess that I can't replicate here.
        */
        #endregion
        public int GuessNumber(int n)
        {
            int left = 0;
            int right = n;
            while (left <= right)
            {
                int pivot = left + (right - left) / 2;
                if (Math.Abs(pivot) == 0) return pivot;
                if (Math.Abs(pivot) == -1) right = pivot - 1;
                else { left = pivot + 1; }
            }
            return 0;
        }
    }
}
