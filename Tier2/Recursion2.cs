using System;
using System.Collections.Generic;
using System.Text;
using static Tier2.BinaryTree;

namespace Tier2
{
    public class Recursion2
    {
        #region Quick Sort Template For Future Use

        public void quickSort(int[] lst)
        {
            /* Sorts an array in the ascending order in O(n log n) time */
            int n = lst.Length;
            qSort(lst, 0, n - 1);
        }

        public void qSort(int[] lst, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = partition(lst, lo, hi);
                qSort(lst, lo, p - 1);
                qSort(lst, p + 1, hi);
            }
        }

        public int partition(int[] lst, int lo, int hi)
        {
            /*
              Picks the last element hi as a pivot
              and returns the index of pivot value in the sorted array */
            int pivot = lst[hi];
            int i = lo;
            for (int j = lo; j < hi; ++j)
            {
                if (lst[j] < pivot)
                {
                    int tmpfloop = lst[i];
                    lst[i] = lst[j];
                    lst[j] = tmpfloop;
                    i++;
                }
            }
            int tmp = lst[i];
            lst[i] = lst[hi];
            lst[hi] = tmp;
            return i;
        }
        #endregion
        #region Divide and Conquer
        #region Sort an Array
        /*
         Sort an Array

        Given an array of integers nums, sort the array in ascending order and return it.
        You must solve the problem without using any built-in functions in O(nlog(n)) time complexity and with the smallest space complexity possible.
        */
        //Bottom-up merge sort taken from wikipedia
        /*
        Example C-like code using indices for bottom-up merge sort algorithm 
        which treats the list as an array of n sublists(called runs in this example) of size 1, 
        and iteratively merges sub-lists back and forth between two buffers: 
        */
        // array A[] has the items to sort; array B[] is a work array,n is the item arrays length
        void BottomUpMergeSort(int[] A, int[] B, int n)
        {
            // Each 1-element run in A is already "sorted".
            // Make successively longer sorted runs of length 2, 4, 8, 16... until the whole array is sorted.
            for (int width = 1; width < n; width = 2 * width)
            {
                // Array A is full of runs of length width.
                for (int i = 0; i < n; i = i + 2 * width)
                {
                    // Merge two runs: A[i:i+width-1] and A[i+width:i+2*width-1] to B[]
                    // or copy A[i:n-1] to B[] ( if (i+width >= n) )
                    BottomUpMerge(A, i, Math.Min(i + width, n), Math.Min(i + 2 * width, n), B);
                }
                // Now work array B is full of runs of length 2*width.
                // Copy array B to array A for the next iteration.
                // A more efficient implementation would swap the roles of A and B.
                CopyArray(B, A, n);
                // Now array A is full of runs of length 2*width.
            }
        }

        //  Left run is A[iLeft :iRight-1].
        // Right run is A[iRight:iEnd-1  ].
        void BottomUpMerge(int[] A, int iLeft, int iRight, int iEnd, int[] B)
        {
            int i = iLeft;
            int j = iRight;
            // While there are elements in the left or right runs...
            for (int k = iLeft; k < iEnd; k++)
            {
                // If left run head exists and is <= existing right run head.
                if (i < iRight && (j >= iEnd || A[i] <= A[j]))
                {
                    B[k] = A[i];
                    i = i + 1;
                }
                else
                {
                    B[k] = A[j];
                    j = j + 1;
                }
            }
        }

        void CopyArray(int[] B, int[] A, int n)
        {
            for (int i = 0; i < n; i++)
                A[i] = B[i];
        }
        #endregion
        #region Validate a Binary Tree
        /*
            Given the root of a binary tree, determine if it is a valid binary search tree (BST).

            A valid BST is defined as follows:

            The left
            subtree
            of a node contains only nodes with keys less than the node's key.
            The right subtree of a node contains only nodes with keys greater than the node's key.
            Both the left and right subtrees must also be binary search trees.

        
            Example 1:
            Input: root = [2,1,3]
            Output: true

            Example 2:
            Input: root = [5,1,4,null,null,3,6]
            Output: false
            Explanation: The root node's value is 5 but its right child's value is 4.

        

            Constraints:
            The number of nodes in the tree is in the range [1, 104].
            -231 <= Node.val <= 231 - 1


        https://leetcode.com/problems/validate-binary-search-tree/
        */
        //No official solution so this is it.
        public bool IsValidBST(TreeNode root)
        {
            return IsValid(root, null, null);
        }

        public bool IsValid(TreeNode root, int? min, int? max)
        {

            if (root == null)
            {
                return true;
            }

            if (max.HasValue && root.val >= max.Value)
            {
                return false;
            }

            if (min.HasValue && root.val <= min.Value)
            {
                return false;
            }

            return IsValid(root.left, min, root.val) && IsValid(root.right, root.val, max);

        }

        #endregion
        #region Search a 2D Matrix II
        /*
        Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix has the following properties:

            Integers in each row are sorted in ascending from left to right.
            Integers in each column are sorted in ascending from top to bottom.

        Example 1:
        Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 5
        Output: true

        Example 2:
        Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 20
        Output: false

        Constraints:
            m == matrix.length
            n == matrix[i].length
            1 <= n, m <= 300
            -109 <= matrix[i][j] <= 109
            All the integers in each row are sorted in ascending order.
            All the integers in each column are sorted in ascending order.
            -109 <= target <= 109

        https://leetcode.com/problems/search-a-2d-matrix-ii/
        */
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null)
                return false;
            int m = matrix.Length;
            int n = matrix[0].Length;
            if (n == 0 && m == 0)
                return false;
            return BinarySearch(matrix, target, 0, m - 1, 0, n - 1);
        }

        bool BinarySearch(int[][] matrix, int target,
        int min_i, int max_i,
        int min_j, int max_j)
        {
            if (min_i > max_i)
                return false;
            if (min_j > max_j)
                return false;
            int i = (min_i + max_i) / 2;
            int j = (min_j + max_j) / 2;

            int value = matrix[i][j];
            if (value == target)
                return true;
            else if (value < target)
            {
                return
                   BinarySearch(matrix, target, min_i, max_i, j + 1, max_j)
                || BinarySearch(matrix, target, i + 1, max_i, min_j, j);
            }
            else
            {
                return BinarySearch(matrix, target, min_i, max_i, min_j, j - 1)
                || BinarySearch(matrix, target, min_i, i - 1, j, max_j);
            }
        }
        #endregion
        #endregion
        #region Backtracking
        #region N-Queens II
        /*
        The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
        Given an integer n, return the number of distinct solutions to the n-queens puzzle.

        Example 1:
        Input: n = 4
        Output: 2
        Explanation: There are two distinct solutions to the 4-queens puzzle as shown.

        Example 2:
        Input: n = 1
        Output: 1

        Constraints:

            1 <= n <= 9

        https://leetcode.com/problems/n-queens-ii/
        */
        public int TotalNQueens(int n)
        {
            int[] columns = new int[n];
            int[] diagonals1 = new int[2 * n - 1];
            int[] diagonals2 = new int[2 * n - 1];
            int count = 0;

            TotalNQueensHelper(n, 0, columns, diagonals1, diagonals2, ref count);

            return count;
        }

        private void TotalNQueensHelper(int n, int row, int[] columns, int[] diagonals1, int[] diagonals2, ref int count)
        {
            if (row == n)
            {
                count++;
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (columns[col] == 0 && diagonals1[row + col] == 0 && diagonals2[row - col + n - 1] == 0)
                {
                    columns[col] = 1;
                    diagonals1[row + col] = 1;
                    diagonals2[row - col + n - 1] = 1;
                    TotalNQueensHelper(n, row + 1, columns, diagonals1, diagonals2, ref count);
                    columns[col] = 0;
                    diagonals1[row + col] = 0;
                    diagonals2[row - col + n - 1] = 0;
                }
            }
        }
        #endregion
        #region Sudoku Solver
        public void SolveSudoku(char[][] board)
        {

            solver(board);
        }

        public bool solver(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (char replacement = '1'; replacement <= '9'; replacement++)
                        {
                            if (isValid(i, j, board, replacement))
                            {
                                board[i][j] = replacement;
                                if (solver(board))
                                {
                                    return true;
                                }
                                else
                                {
                                    board[i][j] = '.';
                                }
                            }
                        }
                        return false;
                    }
                }
            }

            return true;
        }

        public bool isValid(int row, int col, char[][] board, char replacement)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][col] != '.' && board[i][col] == replacement) return false;
                if (board[row][i] != '.' && board[row][i] == replacement) return false;
                if (board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] != '.' &&
                   board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == replacement) return false;
            }
            return true;
        }
        #endregion
        #region Combinations
        /*
        Given two integers n and k, return all possible combinations of k numbers chosen from the range [1, n].
        You may return the answer in any order.

        Example 1:

        Input: n = 4, k = 2
        Output: [[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]
        Explanation: There are 4 choose 2 = 6 total combinations.
        Note that combinations are unordered, i.e., [1,2] and [2,1] are considered to be the same combination.

        Example 2:
        Input: n = 1, k = 1
        Output: [[1]]
        Explanation: There is 1 choose 1 = 1 total combination.

        Constraints:
            1 <= n <= 20
            1 <= k <= n

        https://leetcode.com/problems/combinations/
        */
        public IList<IList<int>> Combine(int n, int k)
        {

            List<IList<int>> returned = new();
            List<int> comb = new();
            combiner(returned, comb, 1, n, k);
            return returned;
        }

        public void combiner(IList<IList<int>> returned, List<int> comb, int start, int n, int k)
        {
            if (k == 0)
            {
                returned.Add(new List<int>(comb));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                comb.Add(i);
                combiner(returned, comb, i + 1, n, k - 1);
                comb.RemoveAt(comb.Count - 1);
            }
        }
        #endregion
        #endregion
        #region Recursion to Iteration
        //First two problems below don't have official solutions for iterative approach
        //As a result just solved them recursively.
        #region Same Tree
        /*
        Given the roots of two binary trees p and q, write a function to check if they are the same or not.
        Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

        Example 1:
        Input: p = [1,2,3], q = [1,2,3]
        Output: true

        Example 2:
        Input: p = [1,2], q = [1,null,2]
        Output: false

        Example 3:
        Input: p = [1,2,1], q = [1,1,2]
        Output: false

        Constraints:
            The number of nodes in both trees is in the range [0, 100].
            -104 <= Node.val <= 104

        Extra Test Case:
        [1,2]
        [1,null,2]
        */
        public bool IsSameTree(TreeNode p, TreeNode q)
        {

            return opener(p, q);
        }

        public bool opener(TreeNode p, TreeNode q)
        {

            if (p == null && q == null)
                return true;

            if (p?.val != q?.val)
                return false;

            bool leftTree = opener(p.left, q.left);
            bool rightTree = opener(p.right, q.right);

            return leftTree && rightTree;
        }
        #endregion
        #region Generate Paranthesis
        /*
        Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

        Example 1:
        Input: n = 3
        Output: ["((()))","(()())","(())()","()(())","()()()"]

        Example 2:
        Input: n = 1
        Output: ["()"]

        Constraints:
            1 <= n <= 8

        https://leetcode.com/problems/generate-parentheses/
        */
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> lister = new();
            StringBuilder prototype = new();
            int start = 0;
            int b = n * 2;
            int level = n * 2;
            generator(lister, prototype, start, b, level);
            return lister;
        }

        public void generator(List<string> lister, StringBuilder prototype, int start, int n, int level)
        {

            if (level == 0 && verifier(prototype))
            {
                lister.Add(prototype.ToString());
                return;
            }

            for (int i = start; i < n; i++)
            {
                prototype.Append('(');
                generator(lister, prototype, i + 1, n, level - 1);
                prototype.Length--;
                prototype.Append(')');
                generator(lister, prototype, i + 1, n, level - 1);
                prototype.Length--;
            }
        }

        public bool verifier(StringBuilder prototype)
        {
            Stack<char> verification = new();

            for (int i = 0; i < prototype.Length; i++)
            {
                if (prototype[i] == '(')
                {
                    verification.Push(')');
                }
                else
                {
                    if (verification.Count == 0)
                    {
                        return false;
                    }
                    verification.Pop();
                }
            }

            if (verification.Count != 0)
            {
                return false;
            }
            return true;
        }
        #endregion
        /*
        Binary Tree Inorder Traversal -- This problem is solved in BinaryTree part iteratively.
        Binary Tree Level Order Traversal -- This problem is solved in BinaryTree part iteratively.
        */
        #endregion
        #region Beyond Recursion
        #region Largest Rectangle in Histogram
        /*
        Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, return the area of the largest rectangle in the histogram.

        Example 1:
        Input: heights = [2,1,5,6,2,3]
        Output: 10
        Explanation: The above is a histogram where width of each bar is 1.
        The largest rectangle is shown in the red area, which has an area = 10 units.

        Example 2:
        Input: heights = [2,4]
        Output: 4

        Constraints:

            1 <= heights.length <= 105
            0 <= heights[i] <= 104

        https://leetcode.com/problems/largest-rectangle-in-histogram/
        */
        public int LargestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;

            for (int i = 0; i <= heights.Length; i++)
            {
                int h = (i == heights.Length) ? 0 : heights[i];
                while (stack.Count > 0 && h < heights[stack.Peek()])
                {
                    int height = heights[stack.Pop()];
                    int width = (stack.Count == 0) ? i : i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, height * width);
                }
                stack.Push(i);
            }

            return maxArea;
        }
        #endregion
        #region Permutations
        /*
        Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

        Example 1:
        Input: nums = [1,2,3]
        Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

        Example 2:
        Input: nums = [0,1]
        Output: [[0,1],[1,0]]

        Example 3:
        Input: nums = [1]
        Output: [[1]]

        Constraints:
        1 <= nums.length <= 6
        -10 <= nums[i] <= 10
        All the integers of nums are unique.

        https://leetcode.com/problems/permutations/description/
        */
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> carrierList = new();
            List<int> carrier = new();
            opener(carrierList, carrier, nums);
            return carrierList;
        }
        public void opener(List<IList<int>> carrierList, List<int> carrier, int[] myArray)
        {
            if (carrier.Count == myArray.Length)
            {
                carrierList.Add(new List<int>(carrier));
                return;
            }
            for (int i = 0; i < myArray.Length; i++)
            {
                if (carrier.Contains(myArray[i])) continue;

                carrier.Add(myArray[i]);
                opener(carrierList, carrier, myArray);
                carrier.Remove(myArray[i]);
            }
        }
        #endregion
        #region Letter Combinations of a Phone Number
        public IList<string> LetterCombinations(string digits)
        {
            List<string> result = new();
            int start = 0;
            int cycle = digits.Length;
            StringBuilder processed = new();
            opener(result, digits, 0, cycle, processed);

            return result;
        }

        public void opener(List<string> result, string digits, int start, int cycle, StringBuilder processed)
        {
            if (cycle == 0 && processed.Length == digits.Length)
            {
                result.Add(processed.ToString());
                return;
            }
            else
            {
                for (int i = start; i < digits.Length; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int ActualValue = (digits[i] - '0' - 2) * 2;
                        char letter = (char)((digits[i] - '0') + 95 + j + ActualValue);
                        processed.Append(letter);
                        opener(result, digits, start + 1, cycle - 1, processed);
                        processed.Length--;
                    }
                }
            }
        }
        #endregion
        #endregion
    }

}