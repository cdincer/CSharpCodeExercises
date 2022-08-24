using System;
using Tier1;

namespace CSharpCodeExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearch newB = new BinarySearch();
            int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            int[] numsOrg = new int[] { 0, 1, 2, 4, 5, 6, 7 };

            int target = 0;
            //newB.SearchRotatedArray(nums, target);
            newB.BinarySearchOriginal(numsOrg, 5);
        }
    }
}
