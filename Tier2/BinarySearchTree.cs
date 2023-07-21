using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        [5,4,6,null,null,3,7]
        [0,null,1]
        [3,1,5,0,2,4,6,null,null,null,3]
        [3,1,5,0,2,4,6]
        [24,-60,null,-60,-6]
        [-2147483648,null,2147483647,-2147483648]
        https://leetcode.com/problems/validate-binary-search-tree/
        First Solution below is custom and mine.
        Just mix inorder traversal for checking links below 
        and using list to check descending order and comparing with root.
        Runtime:103ms Beats 77.85%of users with C# 
        Memory:42.64mb Beats 30.02%of users with C#
        */
        List<TreeNode> items = new();
        bool result = true;
        public bool IsValidBST(TreeNode root)
        {
            if (root.left == null && root.right == null)
                return true;

            bool check = BuildTree(root);

            if (!check)
                return false;

            bool CrossOver = false;
            for (int i = 0; i < items.Count() - 1; i++)
            {
                if (items[i].val > items[i + 1].val)
                    return false;

                if (!CrossOver && root.val <= items[i].val && items[i] != root)
                    return false;

                if (CrossOver && root.val >= items[i].val && items[i] != root)
                    return false;

                if (items[i] == root)
                {
                    CrossOver = true;
                    continue;
                }
            }

            return true;
        }

        public bool BuildTree(TreeNode root)
        {
            if (root == null)
                return false;

            if (root.left != null && (root.val < root.left.val || root.val == root.left.val))
            {
                result = false;
                return result;
            }

            if (root.right != null && (root.val > root.right.val || root.val == root.right.val))
            {
                result = false;
                return result;
            }

            BuildTree(root.left);
            items.Add(root);
            BuildTree(root.right);

            return result;
        }
        #endregion
        #region Binary Search Tree Iterator
        /*
        Implement the BSTIterator class that represents an iterator over the in-order traversal of a binary search tree (BST):

        BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. The root of the BST is given as part of the constructor. The pointer should be initialized to a non-existent number smaller than any element in the BST.
        boolean hasNext() Returns true if there exists a number in the traversal to the right of the pointer, otherwise returns false.
        int next() Moves the pointer to the right, then returns the number at the pointer.

        Notice that by initializing the pointer to a non-existent smallest number, the first call to next() will return the smallest element in the BST.

        You may assume that next() calls will always be valid. That is, there will be at least a next number in the in-order traversal when next() is called.

        

        Example 1:

        Input
        ["BSTIterator", "next", "next", "hasNext", "next", "hasNext", "next", "hasNext", "next", "hasNext"]
        [[[7, 3, 15, null, null, 9, 20]], [], [], [], [], [], [], [], [], []]
        Output
        [null, 3, 7, true, 9, true, 15, true, 20, false]

        Explanation
        BSTIterator bSTIterator = new BSTIterator([7, 3, 15, null, null, 9, 20]);
        bSTIterator.next();    // return 3
        bSTIterator.next();    // return 7
        bSTIterator.hasNext(); // return True
        bSTIterator.next();    // return 9
        bSTIterator.hasNext(); // return True
        bSTIterator.next();    // return 15
        bSTIterator.hasNext(); // return True
        bSTIterator.next();    // return 20
        bSTIterator.hasNext(); // return False

        Constraints:

            The number of nodes in the tree is in the range [1, 105].
            0 <= Node.val <= 106
            At most 105 calls will be made to hasNext, and next.

        

         Follow up:

        Could you implement next() and hasNext() to run in average O(1) time and use O(h) memory, where h is the height of the tree?
        https://leetcode.com/problems/binary-search-tree-iterator/
        Custom solution below:
        Runtime: 154 ms Beats:78.28% Memory:55.1 MB Beats:66.67%
        */
        /**
        * Definition for a binary tree node.
        * public class TreeNode {
        *     public int val;
        *     public TreeNode left;
        *     public TreeNode right;
        *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        *         this.val = val;
        *         this.left = left;
        *         this.right = right;
        *     }
        * }
        */


        public class BSTIterator
        {

            List<TreeNode> nodesList = new();
            int IndexTrack = 0;
            public BSTIterator(TreeNode root)
            {
                BuilderTree(root);
            }

            public int Next()
            {
                int value = nodesList[IndexTrack].val;
                IndexTrack++;

                return value;
            }

            public bool HasNext()
            {
                bool result = true;

                if (IndexTrack >= nodesList.Count())
                {
                    return false;
                }

                if (IndexTrack + 1 < nodesList.Count() && nodesList[IndexTrack + 1] == null)
                    result = false;

                return result;
            }

            public void BuilderTree(TreeNode root)
            {
                if (root == null)
                    return;

                BuilderTree(root.left);
                nodesList.Add(root);
                BuilderTree(root.right);
            }
        }
        #endregion
        #endregion
    }
}