using System;
using System.Collections.Generic;
using CSharpCodeExercises.Tier1;
using CSharpCodeExercises.Tier2;
using Leetcode;
using Tier1;
using Tier2;
using static CSharpCodeExercises.Tier2.StackQueue;
using static Tier2.BinaryTree;

namespace CSharpCodeExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            int[] numsOrg = new int[] { 1, 9 };
            int[][] twoDArray = new int[][]
            {
            new int[] {1,2,3,4,5},
            new int[] {6,7,8,9,10},
            new int[] {11,12,13,14,15},
            new int[] {16,17,18,19,20},
            };

            char[][] grid1 = new char[][]
            {
             new char[]{'1','1','1','1','0'},
             new char[]{'1','1','0','1','0'},
             new char[]{'1','1','0','0','0'},
             new char[]{'0','0','0','0','0'},
            };
            StackQueue islands = new();
            MinStack asd = new MinStack();
            asd.Push(-2);
            asd.Push(0);
            asd.Push(-3);
            asd.Pop();
            Console.WriteLine(" aaaaa");

        }
    }


}
