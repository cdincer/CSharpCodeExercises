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
        #region Basic Operations in BST

        #region  Search in a Binary Search Tree
        /*
        You are given the root of a binary search tree (BST) and an integer val.

        Find the node in the BST that the node's value equals val and return the subtree rooted with that node. If such a node does not exist, return null.

        Example 1:

        Input: root = [4,2,7,1,3], val = 2
        Output: [2,1,3]

        Example 2:

        Input: root = [4,2,7,1,3], val = 5
        Output: []

        

        Constraints:

            The number of nodes in the tree is in the range [1, 5000].
            1 <= Node.val <= 107
            root is a binary search tree.
            1 <= val <= 107


        https://leetcode.com/problems/search-in-a-binary-search-tree/
        Test Case:
        [18,2,22,null,null,null,63,null,84,null,null]
        63
        [4,2,7,1,3]
        5
       
        */
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;
            if (root.val == val)
            {
                return root;
            }
            if (val > root.val)
            {
                return SearchBST(root.right, val);
            }
            else
            {
                return SearchBST(root.left, val);
            }
        }
        #endregion
        #region Insert into a Binary Search Tree
        /*
        You are given the root node of a binary search tree (BST) and a value to insert into the tree. Return the root node of the BST after the insertion. It is guaranteed that the new value does not exist in the original BST.

        Notice that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion. You can return any of them.

        Example 1:

        Input: root = [4,2,7,1,3], val = 5
        Output: [4,2,7,1,3,5]
        Explanation: Another accepted tree is:

        Example 2:

        Input: root = [40,20,60,10,30,50,70], val = 25
        Output: [40,20,60,10,30,50,70,null,null,25]

        Example 3:

        Input: root = [4,2,7,1,3,null,null,null,null,null,null], val = 5
        Output: [4,2,7,1,3,5]

        

        Constraints:

            The number of nodes in the tree will be in the range [0, 104].
            -108 <= Node.val <= 108
            All the values Node.val are unique.
            -108 <= val <= 108
            It's guaranteed that val does not exist in the original BST.


        https://leetcode.com/problems/insert-into-a-binary-search-tree/
        Extra Test Case:
        [55,28,92,26,43,null,null,null,null,null,null]
        1
        []
        5
        Stats for custom solution below:
        Runtime:98ms Beats 100.00% of users with C#
        Memory: 51.12mb Beats 95.81%of users with C#
        */
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);

            TreeBuilder(root, val);
            return root;
        }

        public TreeNode TreeBuilder(TreeNode root, int val)
        {
            if (root == null)
                return null;

            if (val < root.val && root.left != null)
            {
                return TreeBuilder(root.left, val);
            }
            else if (val > root.val && root.right != null)
            {
                return TreeBuilder(root.right, val);
            }
            else if (root.val > val && root.left == null)
            {
                return root.left = new TreeNode(val);
            }
            else if (root.val < val && root.right == null)
            {
                return root.right = new TreeNode(val);
            }

            return null;
        }
        #endregion
        #region Delete Node in a BST
        /*
        1. If the target node has no child, we can simply remove the node.
        2. If the target node has one child, we can use its child to replace itself.
        3. If the target node has two children, replace the node with its in-order successor or predecessor node and delete that node.

        Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

        Basically, the deletion can be divided into two stages:

            Search for a node to remove.
            If the node is found, delete the node.

        Example 1:

        Input: root = [5,3,6,2,4,null,7], key = 3
        Output: [5,4,6,2,null,null,7]
        Explanation: Given key to delete is 3. So we find the node with value 3 and delete it.
        One valid answer is [5,4,6,2,null,null,7], shown in the above BST.
        Please notice that another valid answer is [5,2,6,null,4,null,7] and it's also accepted.

        Example 2:

        Input: root = [5,3,6,2,4,null,7], key = 0
        Output: [5,3,6,2,4,null,7]
        Explanation: The tree does not contain a node with value = 0.

        Example 3:

        Input: root = [], key = 0
        Output: []

        

        Constraints:

            The number of nodes in the tree is in the range [0, 104].
            -105 <= Node.val <= 105
            Each node has a unique value.
            root is a valid binary search tree.
            -105 <= key <= 105

        https://leetcode.com/problems/delete-node-in-a-bst/

        Explanation:
        Steps:

        Recursively find the node that has the same value as the key, while setting the left/right nodes equal to the returned subtree
        Once the node is found, have to handle the below 4 cases

        1)node doesn't have left or right - return null
        2)node only has left subtree- return the left subtree
        3)node only has right subtree- return the right subtree
        4)node has both left and right - find the minimum value in the right subtree, set that value to the currently found node, then recursively delete the minimum value in the right subtree

        Test Cases:
        [1]
        0
        */

        /*
        Unknown source solution: extra info for recursions effect on runtime and memory
         Runtime:(Info for runtime even with 3 recursive endings)
        Details:98ms Beats 75.59%of users with C# Memory: 44.70m bBeats 19.25% of users with C#
        */
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            //1
            if (root == null)
            {
                return null;
            }

            //4
            if (key < root.val)
            {
                root.left = DeleteNode(root.left, key);
            }
            else if (key > root.val)
            {
                root.right = DeleteNode(root.right, key);
            }
            else
            {
                //2
                if (root.left == null)
                {
                    return root.right;
                }
                //3
                else if (root.right == null)
                {
                    return root.left;
                }
                //4
                TreeNode minNode = findMin(root.right);
                root.val = minNode.val;
                root.right = DeleteNode(root.right, root.val);
            }
            return root;
        }

        public TreeNode findMin(TreeNode node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }
        #endregion
        #endregion
    }
}