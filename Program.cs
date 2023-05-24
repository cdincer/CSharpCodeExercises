using System;
using System.Collections.Generic;
using CSharpCodeExercises.Tier1;
using Leetcode;
using Tier1;
using static Tier1.Hashtable;
using static Tier1.LinkedList;

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
            //ListNode2 head = new ListNode2(1, new ListNode2(2, new ListNode2(3, new ListNode2(4, new ListNode2(5)))));
            Hashtable myTestHashMap = new Hashtable();
            //myTestHashMap.TwoSum(new int[] { 44, 21, 33, 6666, 1, 4, 10000, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11);
            myTestHashMap.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });

        }
    }
}
