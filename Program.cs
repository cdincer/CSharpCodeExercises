using System;
using System.Collections.Generic;
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

            List<int> items = new List<int>();
            items.ToArray().ToString();
            string actualResult = newB.AddBinary("10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101", "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011");
            Console.WriteLine(actualResult);
        }
    }
}
