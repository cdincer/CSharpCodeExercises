using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Tier2.BinaryTree;

namespace CSharpCodeExercises.Tier2
{
    public class BinarySearchTree
    {//https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/
        /*
        A binary search tree (BST), a special form of a binary tree, satisfies the binary search property:
        The value in each node must be greater than (or equal to) any values stored in its left subtree.
        The value in each node must be less than (or equal to) any values stored in its right subtree.
        */


        #region Introduction to BST
        #region Validate Binary Search Tree
        /*
        Given the root of a binary tree, determine if it is a valid binary search tree (BST).

        A valid BST is defined as follows:

            The left subtree of a node contains only nodes with keys less than the node's key.
            The right subtree of a node contains only nodes with keys greater than the node's key.
            Both the left and right subtrees must also be binary search trees.

        

        Example 1:

        Input: root = [2,1,3]
        Output: true

        Example 2:

        Input: root = [5,1,4,null,null,3,6]
        Output: false
        Explanation: The root node's value is 5 but its right child's value is 4.
        Pre-Made Test Case:
        [2,1,3]
        [5,1,4,null,null,3,6]
        [2,2,2]
        [0]
        [1,null,1]
        https://leetcode.com/problems/validate-binary-search-tree/
        */
        List<TreeNode> items = new();
        public bool IsValidBST(TreeNode root)
        {
            if (root.left == null && root.right == null)
                return true;

            BuildTree(root);

            int leftSide = 0;
            int rightSide = 0;
            bool CrossOver = false;
            for (int i = 0; i < items.Count() - 1; i++)
            {
                if (items[i].val > items[i + 1].val)
                    return false;

                if (items[i] == root)
                {
                    CrossOver = true;
                }

                if (!CrossOver)
                {
                    leftSide += items[i].val;
                }
                else
                {
                    rightSide += items[i].val;
                }
            }

            if (leftSide > rightSide || leftSide == rightSide)
                return false;

            return true;
        }

        public void BuildTree(TreeNode root)
        {
            if (root == null)
                return;

            BuildTree(root.left);
            items.Add(root);
            BuildTree(root.right);
        }
        #endregion
        #endregion
    }
}