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
            int[][] twoDArray = new int[][]
            {
            new int[] {1,2,3,4,5},
            new int[] {6,7,8,9,10},
            new int[] {11,12,13,14,15},
            new int[] {16,17,18,19,20},
            };
            newB.SpiralOrder(twoDArray);
        }
    }
}
