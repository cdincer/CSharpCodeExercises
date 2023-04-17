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
            MyHashMap myTestHashMap = new MyHashMap();
            myTestHashMap.put(Int32.Parse("105"), 1);
            myTestHashMap.put(Int32.Parse("104"), 2);
            myTestHashMap.put(Int32.Parse("111"), 3);
            myTestHashMap.put(Int32.Parse("55"), 22);
            myTestHashMap.put(Int32.Parse("77"), 22222);

            Console.WriteLine("1111");
            Console.WriteLine(myTestHashMap.get(int.Parse("55")));
            Console.ReadLine();
        }
    }
}
