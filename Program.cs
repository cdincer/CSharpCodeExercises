using System;
using System.Collections.Generic;
using System.Linq;
using CSharpCodeExercises.Tier2;
using CSharpCodeExercises.Tier3;
using Neetcode150;
using Tier2;
using static Neetcode150.LinkedListNeet;

namespace CSharpCodeExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Array Examples
            int[] nums = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int[] numsOrg = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            int[][] twoDArray = new int[][]
            {
            new int[] {1,2,3,4,5},
            new int[] {6,7,8,9,10},
            new int[] {11,12,13,14,15},
            new int[] {16,17,18,19,20},
            };
            int[][] LockedRooms = new int[][]{
          new int[] {87},new int[] {33},new int[] {16,82,7,41},new int[] {},new int[] {55,29},new int[] {12},new int[] {3,84,28,56,66},new int[] {},new int[] {44,72},new int[] {78},new int[] {67,90},new int[] {30,81,88},new int[] {2,70,77},new int[] {23,27},new int[] {26},new int[] {25,48},new int[] {19,38,58,39,70},new int[] {51},new int[] {8,92,43},new int[] {},new int[] {24},new int[] {},new int[] {69,79,36,61},new int[] {95},new int[] {85},new int[] {21,28,62,66,73},new int[] {36,53,35,52},new int[] {14,34},new int[] {20,49},new int[] {4},new int[] {40,51,96},new int[] {74,76},new int[] {13,71,80,81},new int[] {42,97,31,68},new int[] {},new int[] {18,46,83,91},new int[] {15},new int[] {9},new int[] {22},new int[] {47,54},new int[] {65,98,34},new int[] {31},new int[] {9,18,55,94},new int[] {57},new int[] {45,77,32},new int[] {32,25},new int[] {24,59,14,42,63},new int[] {37,75,98},new int[] {5,20,99,30},new int[] {15,76,96},new int[] {83,89,12,46},new int[] {65,71},new int[] {10},new int[] {8,45,58},new int[] {10,49,89},new int[] {26,27,78,1,38,50},new int[] {},new int[] {},new int[] {23,62},new int[] {57},new int[] {85},new int[] {13,53},new int[] {93,4,40},new int[] {91,82,99},new int[] {50},new int[] {},new int[] {},new int[] {64,2,11,37},new int[] {88},new int[] {29,43},new int[] {11},new int[] {93,95},new int[] {},new int[] {35},new int[] {73,92},new int[] {63,80},new int[] {39},new int[] {1,60,86,5},new int[] {},new int[] {41,56,47},new int[] {54},new int[] {33,44,97},new int[] {3,48,86},new int[] {19},new int[] {87},new int[] {6,52},new int[] {75,84},new int[] {90,16},new int[] {94,21,79},new int[] {67},new int[] {61,64},new int[] {},new int[] {},new int[] {17,59},new int[] {17},new int[] {68},new int[] {72,6},new int[] {7},new int[] {74},new int[] {22,60}
         };

            int[][] lockedrooms2 = new int[][]

             {new int[] {1,3},new int[] {3,0,1},new int[] {2},new int[] {0}};

            int[][] grid1 = new int[][]
            {
                new int[] {1,0,1,1,0,0,1,0,0,1},
                new int[] {0,1,1,0,1,0,1,0,1,1},
                new int[] {0,0,1,0,1,0,0,1,0,0},
                new int[] {1,0,1,0,1,1,1,1,1,1},
                new int[] {0,1,0,1,1,0,0,0,0,1},
                new int[] {0,0,1,0,1,1,1,0,1,0},
                new int[] {0,1,0,1,0,1,0,0,1,1},
                new int[] {1,0,0,0,1,1,1,1,0,1},
                new int[] {1,1,1,1,1,1,1,0,1,0},
                new int[] {1,1,1,1,0,1,0,0,1,1}
             };

            StackQueue islands = new();
            Recursion2 myclass = new();
            Graph myGraph = new();
            char[][] mySudoku = new char[][]
            {
            new char[] {'5','3','.','.','7','.','.','.','.'},
            new char []{'6','.','.','1','9','5','.','.','.'},
            new char []{'.','9','8','.','.','.','.','6','.'},
            new char []{'8','.','.','.','6','.','.','.','3'},
            new char []{'4','.','.','8','.','3','.','.','1'},
            new char []{'7','.','.','.','2','.','.','.','6'},
            new char []{'.','6','.','.','.','.','2','8','.'},
            new char []{'.','.','.','4','1','9','.','.','5'},
            new char []{'.','.','.','.','8','.','.','7','9'}
            };
            int[] histogramExample = new int[] { 2, 1, 5, 6, 2, 3 };
            int[][] provinces = new int[][]
          {
            new int[] {1,1,0},
            new int[] {1,1,0},
            new int[] {0,0,1}
          };
            #endregion
            #region LinkedList ListNodes
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4,new ListNode(5)))));
            #endregion
            #region List Examples
            List<IList<string>> equations = new();
            equations.Add(new List<string>() { "a", "b" });
            equations.Add(new List<string>() { "b", "c" });
            double[] values = new[] { 2.0, 3.0 };
            List<IList<string>> queries = new();
            queries.Add(new List<string>() { "a", "c" });
            queries.Add(new List<string>() { "b", "a" });
            queries.Add(new List<string>() { "a", "e" });
            queries.Add(new List<string>() { "a", "a" });
            queries.Add(new List<string>() { "x", "x" });

            string stringSorted = "0P";
            #endregion
            DpTwoNeet  dpone = new();
            int[] arr = new int[] {1,2,3,0,2};
            dpone.MaxProfit(arr);


            BitManipulatiuonNeet cl1 = new();
            var result = cl1.Reverse(1056389759);
            Console.WriteLine("Result " + result);

        }
    }


}
