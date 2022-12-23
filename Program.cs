using System;
using System.Collections.Generic;
using CSharpCodeExercises.Tier1;
using Leetcode;
using Tier1;

namespace CSharpCodeExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorting newB = new Sorting();
            int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            int[] numsOrg = new int[] { 1, 9 };
            int[][] twoDArray = new int[][]
            {
            new int[] {1,2,3,4,5},
            new int[] {6,7,8,9,10},
            new int[] {11,12,13,14,15},
            new int[] {16,17,18,19,20},
            };
            ValidParentheses can1 = new ValidParentheses();
            List<int> items = new List<int>();
            items.ToArray().ToString();
            newB.SmallestTrimmedNumbers(new string[] { "102","473","251","814" },new int[][] { new int[]{1,1},new int[]{2,3},new int[]{4,2},new int[]{1,2}});
            Console.ReadLine();
        }
    }
}
