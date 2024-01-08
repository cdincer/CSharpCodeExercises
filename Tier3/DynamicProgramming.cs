 using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCodeExercises.Tier3
{
    public class DynamicProgramming
    {
        #region Burst Baloons
        /*
        Solution inspired by Matrix-chain multiplication in Introduction To Algorithms Section 15.2
        https://leetcode.com/problems/burst-balloons/description/
        */
        public static int MaxCoins(int[] nums)
        {
            List<int> numsl = nums.ToList();
            numsl.Insert(0, 1);
            numsl.Add(1);
            int n = numsl.Count;
            int[] newArray = numsl.ToArray();
            int[][] mem = new int[n][];

            for (int i = 0; i < mem.Length; i++)
            {
                mem[i] = new int[n];
                for (int j = 0; j < mem[i].Length; j++)
                {
                    mem[i][j] = -1;
                }
            }
            return MCM(newArray, 1, n - 1, mem);
        }

        public static int MCM(int[] nums, int left, int right, int[][] mem)
        {
            if (left >= right)
                return 0;

            if (mem[left][right] != -1)
                return mem[left][right];

            int max_cost = int.MinValue;
            for (int k = left; k < right; k++)
            {
                int total_cost = MCM(nums, left, k, mem) + MCM(nums, k + 1, right, mem) + nums[left - 1] * nums[k] * nums[right];  //after traversing any element from left to right, 
                                                                                                                                   //Assume that the traversed element is no more in nums array and find product of current element and its adjacent element

                max_cost = Math.Max(max_cost, total_cost);

                mem[left][right] = max_cost;
            }
            return mem[left][right];
        }
        #endregion
    }

}