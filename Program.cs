using System;
using Tier1;

namespace CSharpCodeExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayAndString newB = new ArrayAndString();
            int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            int[] numsOrg = new int[] { 1, 9 };

            int target = 0;
            //newB.SearchRotatedArray(nums, target);
            newB.PlusOne(numsOrg);
        }
    }
}
