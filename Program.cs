using System;
using System.Collections.Generic;
using CSharpCodeExercises.Tier1;
using CSharpCodeExercises.Tier2;
using Leetcode;
using Tier1;
using Tier2;
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
            // KthLargest2 item = new(3, new int[] { 4, 5, 8, 2 });
            // Console.WriteLine(item.Add(3) + " added 3");
            // Console.WriteLine("Returned value: " + item.Add(5) + "- added 5  -- expected return 5");   // return 5
            // Console.WriteLine("Returned value: " + item.Add(10) + "- added 10  -- expected return 5 ");  // return 5
            // Console.WriteLine("Returned value: " + item.Add(9) + "- added 9  -- expected return 8");   // return 8
            // Console.WriteLine("Returned value: " + item.Add(4) + "- added 4  -- expected  return 8");   // return 8

            KthLargest2 item = new(4, new int[] { 5, 2, 6, 1, 7, 4 });
            Console.WriteLine("Returned value: " + item.Add(3) + " added 3");

            Console.WriteLine("Finished");
        }
    }

    public class KthLargest2
    {

        int remainderOfK = 0;
        int KthElement = -1;

        public class TreeNode22
        {
            public int val;
            public TreeNode22 left;
            public TreeNode22 right;
            public int CountOfItems;
            public TreeNode22(int val = 0,
            TreeNode22 left = null,
            TreeNode22 right = null,
            int CountOfItems = 1)
            {
                this.val = val;
                this.left = left;
                this.right = right;
                this.CountOfItems = CountOfItems;
            }
        }

        TreeNode22 SpecialRoot = new();
        int IndexToLookFor = 0;
        List<int> Largest = new();

        public KthLargest2(int k, int[] nums)
        {
            IndexToLookFor = k;
            SpecialRoot.val = nums[0];

            foreach (int number in nums)
            {
                AddNew(number);
            }
        }

        public int Add(int val)
        {
            int valuessss = AddNew(val);

            return valuessss;
        }

        public int AddNew(int val)
        {
            remainderOfK = IndexToLookFor;
            TreeNode22 root = SpecialRoot;
            TreeBuilder2(root, val);
            int seperateItem = 0;
            if (KthElement > -1)
            {
                seperateItem = KthElement;
            }

            return KthElement;
        }

        public TreeNode22 TreeBuilder2(TreeNode22 root, int val)
        {
            if (root == null)
                return null;

            if (val < root.val && root.left != null)
            {
                root.CountOfItems++;
                CheckValidity(root);
                return TreeBuilder2(root.left, val);
            }
            else if (val > root.val && root.right != null)
            {
                root.CountOfItems++;
                CheckValidity(root);
                return TreeBuilder2(root.right, val);
            }
            else if (root.val > val && root.left == null)
            {
                root.CountOfItems++;
                root.left = new TreeNode22(val);
                CheckValidity(root);

                return root;
            }
            else if (root.val < val && root.right == null)
            {
                root.CountOfItems++;
                root.right = new TreeNode22(val);
                CheckValidity(root);
                return root;
            }

            return null;
        }

        public void CheckValidity(TreeNode22 root)
        {
            if (root.CountOfItems < remainderOfK)
            {
                int remainders = root.right != null ? root.right.CountOfItems : 0;
                remainders += root.CountOfItems + 1;
                if (remainderOfK - remainders <= 0)
                {
                    KthElement = root.val;
                }
                remainderOfK -= remainders;
            }
        }
    }
}
