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
            //Test Case 1
             newB.radixSort(new string[] { "24", "37", "96", "04" });
            //Test Case 2
            // newB.SmallestTrimmedNumbersv1(new string[] { "325240361872", "440618160237", "785744447413", "820980201297", "470082520306", "874146483840", "425300857082", "088636787077", "813218016629", "459000328006", "188683382600" },
            // new int[][] { new int[] { 1, 1 }, new int[] { 3, 1 }, new int[] { 11, 10 } });


            Console.ReadLine();
        }
    }
}
