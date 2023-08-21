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
        [5,3,6,2,4,null,7]
        7
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
        #region Conclusion
        #region  Kth Largest Element in a Stream
        /*
        Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.

        Implement KthLargest class:

            KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of integers nums.
            int add(int val) Appends the integer val to the stream and returns the element representing the kth largest element in the stream.

        
        Example 1:

        Input
        ["KthLargest", "add", "add", "add", "add", "add"]
        [[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
        Output
        [null, 4, 5, 5, 8, 8]

        Explanation
        KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
        kthLargest.add(3);   // return 4
        kthLargest.add(5);   // return 5
        kthLargest.add(10);  // return 5
        kthLargest.add(9);   // return 8
        kthLargest.add(4);   // return 8

        

        Constraints:

            1 <= k <= 104
            0 <= nums.length <= 104
            -104 <= nums[i] <= 104
            -104 <= val <= 104
            At most 104 calls will be made to add.
            It is guaranteed that there will be at least k elements in the array when you search for the kth element.


        https://leetcode.com/problems/kth-largest-element-in-a-stream/description/

        Extra Testcase:
        ["KthLargest","add"] //Test case from leetcode conclusion section page. //Expected Return is 4
        [[4,[5,2,6,1,7,4]],[3]] 
        */
        //Generic PriorityQueue(Heap implementation of C#)
        public class KthLargest1
        {
            private PriorityQueue<int, int> _first = new PriorityQueue<int, int>();
            private int KthElements = 0;

            public KthLargest1(int k, int[] nums)
            {
                KthElements = k;
                foreach (var num in nums)
                {
                    AddNew(num);
                }
            }

            public int Add(int val)
            {
                AddNew(val);
                return _first.Peek();
            }

            private void AddNew(int val)
            {
                if (_first.Count < KthElements)
                {
                    _first.Enqueue(val, val);
                    return;
                }

                _first.Enqueue(val, val);
                _first.Dequeue();
            }
        }

        //Editorial Conclusion Solution mentioned here: https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/142/conclusion/1009/
        //Stats for it
        //Runtime: 414ms Beats 16.96%of users with C# -- Memory: 61.61mb Beats 8.04% of users with C#
        public class KthLargest2
        {
            TreeNode root { get; set; }
            int k;
            public KthLargest2(int k, int[] nums)
            {
                this.k = k;
                foreach (int number in nums)
                {
                    root = Add(root, number);
                }
            }

            public int Add(int val)
            {
                root = Add(root, val);
                return findKthLargest();
            }

            private TreeNode Add(TreeNode root, int val)
            {
                if (root == null) return new TreeNode(val);
                root.count++;
                if (val < root.val) root.left = Add(root.left, val);
                else root.right = Add(root.right, val);

                return root;
            }

            public int findKthLargest()
            {
                int count = k;
                TreeNode walker = root;

                while (count > 0)
                {
                    int pos = 1 + (walker.right != null ? walker.right.count : 0);
                    if (count == pos) break;
                    if (count > pos)
                    {
                        count -= pos;
                        walker = walker.left;
                    }
                    else if (count < pos)
                        walker = walker.right;
                }
                return walker.val;
            }

            public class TreeNode
            {
                public int val, count = 1;
                public TreeNode left, right;
                public TreeNode(int v) { val = v; }
            }

        }
        #endregion
        #region Lowest Common Ancestor of a Binary Search Tree
        //Same solution as Binary Tree version. Literally copy pasted it.
        /*Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST.

        According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”

        Example 1:

        Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
        Output: 6
        Explanation: The LCA of nodes 2 and 8 is 6.

        Example 2:

        Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
        Output: 2
        Explanation: The LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.

        Example 3:

        Input: root = [2,1], p = 2, q = 1
        Output: 2

        

        Constraints:

            The number of nodes in the tree is in the range [2, 105].
            -109 <= Node.val <= 109
            All Node.val are unique.
            p != q
            p and q will exist in the BST.


        */
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
            {
                return root;
            }
            else if (left != null)
            {
                return left;
            }
            else
            {
                return right;
            }
        }
        #endregion
        #region Contains Duplicate III
        /*
        You are given an integer array nums and two integers indexDiff and valueDiff.

        Find a pair of indices (i, j) such that:

            i != j,
            abs(i - j) <= indexDiff.
            abs(nums[i] - nums[j]) <= valueDiff, and

        Return true if such pair exists or false otherwise.

        Example 1:

        Input: nums = [1,2,3,1], indexDiff = 3, valueDiff = 0
        Output: true
        Explanation: We can choose (i, j) = (0, 3).
        We satisfy the three conditions:
        i != j --> 0 != 3
        abs(i - j) <= indexDiff --> abs(0 - 3) <= 3
        abs(nums[i] - nums[j]) <= valueDiff --> abs(1 - 1) <= 0

        Example 2:

        Input: nums = [1,5,9,1,5,9], indexDiff = 2, valueDiff = 3
        Output: false
        Explanation: After trying all the possible pairs (i, j), we cannot satisfy the three conditions, so we return false.

        

        Constraints:

            2 <= nums.length <= 105
            -109 <= nums[i] <= 109
            1 <= indexDiff <= nums.length
            0 <= valueDiff <= 109

        Converted Java code below(Editorial solution is only available to subscribers):
        Stats On 10th Of August 2023:
        Runtime 215ms Beats 96.30% of users with C# Memory 51.79mb  100.00% of users with C#

        Extra test case:
        [1,5,9,1,5,9]
        2
        3
        [Output:true]
        https://leetcode.com/problems/contains-duplicate-iii/description/
        */
        public class TreeNodeD
        {
            public long val;
            public TreeNodeD left;
            public TreeNodeD right;
            public TreeNodeD(long x)
            {
                val = x;
            }
        }
        public TreeNodeD add(TreeNodeD root, TreeNodeD nNode)
        {
            if (root == null)
            {
                return nNode;
            }
            else if (root.val < nNode.val)
            {
                root.right = add(root.right, nNode);
            }
            else
            {
                root.left = add(root.left, nNode);
            }
            return root;
        }

        //This problem requires us to maintain a tree of IndexDiff size
        //That's why we delete the tree members after that.
        //We want to have a certain size that can be queried for value ranges.
        public TreeNodeD delete(TreeNodeD root, TreeNodeD dNode)
        {
            if (root == null)
            {
                return null;
            }
            else if (root.val < dNode.val)
            {
                root.right = delete(root.right, dNode);
                return root;
            }
            else if (root.val > dNode.val)
            {
                root.left = delete(root.left, dNode);
                return root;
            }
            else if (root == dNode)
            {
                if (dNode.left == null && dNode.right == null) return null;
                else if (dNode.left != null && dNode.right == null) return dNode.left;
                else if (dNode.right != null && dNode.left == null) return dNode.right;
                else
                {
                    TreeNodeD p = dNode.right;
                    while (p.left != null) p = p.left;
                    dNode.right = delete(dNode.right, p);
                    p.left = dNode.left;
                    p.right = dNode.right;
                    return p;
                }
            }
            else
            {
                return root;
            }
        }

        public bool search(TreeNodeD root, long val, int valueDiff)
        {
            if (root == null)
            {
                return false;
            }
            else if (Math.Abs((root.val - val)) <= valueDiff)
            {
                return true;
            }
            else if ((root.val - val) > valueDiff)
            {
                return search(root.left, val, valueDiff);
            }
            else
            {
                return search(root.right, val, valueDiff);
            }
        }

        public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
        {
            if (indexDiff < 1 || valueDiff < 0 || nums.Length <= 1)
            {
                return false;
            }
            int len = nums.Length;
            TreeNodeD[] map = new TreeNodeD[len];
            map[0] = new TreeNodeD((long)nums[0]);
            TreeNodeD root = null;
            root = add(root, map[0]);
            for (int i = 1; i < len; i++)
            {
                if (search(root, (long)nums[i], valueDiff))
                {
                    return true;
                }
                map[i] = new TreeNodeD((long)nums[i]);
                if (i - indexDiff >= 0)
                {
                    root = delete(root, map[i - indexDiff]);
                }
                root = add(root, map[i]);
            }
            return false;
        }

        //Alternative solution without binary search tree
        private SortedSet<long> neighbours = new();

        public bool ContainsNearbyAlmostDuplicate2(int[] nums, int indexDiff, int valueDiff)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                if (neighbours.GetViewBetween(Convert.ToInt64(nums[i]) - valueDiff, Convert.ToInt64(nums[i]) + valueDiff).Any())
                    return true;

                neighbours.Add(nums[i]);

                if (i >= indexDiff) //Delete to maintain the size and make it easy to search especially in larger numbers.
                    neighbours.Remove(nums[i - indexDiff]);
            }

            return false;
        }

        #endregion
        #region Balanced Binary Tree
        /*
        Given a binary tree, determine if it is height-balanced .

        Example 1:

        Input: root = [3,9,20,null,null,15,7]
        Output: true

        Example 2:

        Input: root = [1,2,2,3,3,null,null,4,4]
        Output: false

        Example 3:

        Input: root = []
        Output: true

        Constraints:

            The number of nodes in the tree is in the range [0, 5000].
            -104 <= Node.val <= 104

        "A height-balanced binary tree is a binary tree in 
        which the depth of the two subtrees of every node never differs by more than one"
        https://leetcode.com/problems/balanced-binary-tree/
        */
        private bool res = true;
        public bool IsBalanced(TreeNode root)
        {

            //if the root is null return true since it has a height of 0
            if (root == null)
            {
                return true;
            }

            //Depth first search starting from the root with a height of 0
            DFS(root, 0);

            return res;
        }

        private int DFS(TreeNode node, int h)
        {

            // if the node is null return 0
            if (node == null)
                return 0;

            // declare left and right heights
            int lh = DFS(node.left, h + 1),
            rh = DFS(node.right, h + 1);

            // if the differences between the two is greater than one response = false.
            if (Math.Abs(lh - rh) > 1)
                res = false;

            //return max height + 1
            return Math.Max(lh, rh) + 1;
        }
        #endregion
        #region  Convert Sorted Array to Binary Search Tree
        /*
        Given an integer array nums where the elements are sorted in ascending order, convert it to a
        height-balanced
        binary search tree.

        Example 1:

        Input: nums = [-10,-3,0,5,9]
        Output: [0,-3,9,-10,null,5]
        Explanation: [0,-10,5,null,-3,null,9] is also accepted:

        Example 2:

        Input: nums = [1,3]
        Output: [3,1]
        Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.

        "A height-balanced binary tree is a binary tree in which the 
        depth of the two subtrees of every node never differs by more than one."

        https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
        */
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return CreateNode(0, nums.Length - 1);

            TreeNode CreateNode(int left, int right)
            {
                if (left > right)
                {
                    return null;
                }
                int mid = left + (right - left) / 2;
                return new TreeNode(nums[mid], CreateNode(left, mid - 1), CreateNode(mid + 1, right));
            }
        }
        #endregion

        #endregion
    }
}