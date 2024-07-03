using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Leetcode.ArrayRelated
{
    public class ArrayLeetCode1
    {
        #region Minimum Difference
        public int MinDifference(int[] nums)
        {
            int arrayMin = nums.Min();
            int arrayMax = nums.Max();
            int[] myorg = nums;
            Array.Sort(myorg);
            //Console.WriteLine("after sorting " + String.Join("",myorg)); 
            int ti = myorg.Length - 1;
            for (int i = 3; i > 0; i--)
            {
                myorg[ti] = arrayMin;
                ti--;
            }
            int decreaseR = myorg.Max() - myorg[^2];
            Array.Copy(nums, myorg, myorg.Length);
            Array.Sort(myorg);
            for (int i = 0; i < 3; i++)
            {
                myorg[i] = arrayMax;
            }
            int increaseR = myorg.Max() - myorg.Min();
            return Math.Min(decreaseR, increaseR);
        }
        #endregion


    }
}
