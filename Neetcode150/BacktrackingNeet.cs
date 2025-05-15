using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neetcode150
{
    public class BacktrackingNeet
    {
        #region Subsets
        /*
        Given an integer array nums of unique elements, return all possible subsets
        (the power set).

        The solution set must not contain duplicate subsets. Return the solution in any order.

        Example 1:
        Input: nums = [1,2,3]
        Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

        Example 2:
        Input: nums = [0]
        Output: [[],[0]]

        Constraints:

            1 <= nums.length <= 10
            -10 <= nums[i] <= 10
            All the numbers of nums are unique.
            
        https://leetcode.com/problems/subsets/
        */
        List<IList<int>> keeper = new();
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<int> keep = new();
            GeneralizedPattern(0, nums, keep);
            return keeper;
        }

        public List<int> GeneralizedPattern(int index, int[] nums, List<int> keep)
        {
            for (int i = index; i < nums.Length; i++)
            {
                keep.Add(nums[i]);
                GeneralizedPattern(i + 1, nums, keep);
                keep.Remove(nums[i]);
            }

            keeper.Add(new List<int>(keep));

            return keep;
        }
        ///////////////////////
        private List<int> subset = new List<int>();
        private List<IList<int>> result = new List<IList<int>>();
        private void backtrackNeet(int i, int[] nums)
        {
            if (i >= nums.Length)
            {
                result.Add(new List<int>(subset));
                return;
            }
            subset.Add(nums[i]);
            backtrackNeet(i + 1, nums);
            subset.Remove(nums[i]);
            backtrackNeet(i + 1, nums);

        }
        public IList<IList<int>> SubsetsNeet(int[] nums)
        {
            backtrackNeet(0, nums);
            return result;
        }



        #endregion
        #region Combination Sum
        /*
        Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.
        The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the
        frequency of at least one of the chosen numbers is different.

        The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

        Example 1:
        Input: candidates = [2,3,6,7], target = 7
        Output: [[2,2,3],[7]]
        Explanation:
        2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
        7 is a candidate, and 7 = 7.
        These are the only two combinations.

        Example 2:
        Input: candidates = [2,3,5], target = 8
        Output: [[2,2,2,2],[2,3,3],[3,5]]

        Example 3:
        Input: candidates = [2], target = 1
        Output: []

        Constraints:

            1 <= candidates.length <= 30
            2 <= candidates[i] <= 40
            All elements of candidates are distinct.
            1 <= target <= 40
        Test Case:
        candidates = [8,7,4,3] 39 / 160 testcases passed
        target = 11
        https://leetcode.com/problems/combination-sum/
        */
        List<List<int>> res;
        public List<List<int>> CombinationSum(int[] nums, int target)
        {
            res = new List<List<int>>();
            Array.Sort(nums);
            GeneralizedPattern(0, new List<int>(), 0, nums, target);
            return res;
        }

        private void GeneralizedPattern(int i, List<int> cur, int total, int[] nums, int target)
        {
            if (total == target)
            {
                res.Add(new List<int>(cur));
                return;
            }

            for (int j = i; j < nums.Length; j++)
            {
                if (total + nums[j] > target)
                {
                    return;
                }
                cur.Add(nums[j]);
                GeneralizedPattern(j, cur, total + nums[j], nums, target);
                cur.RemoveAt(cur.Count - 1);
            }
        }

        #endregion
        #region Permutations
        /*
        Given an array nums of distinct integers, return all the possible permutations. 
        You can return the answer in any order.

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


        https://leetcode.com/problems/permutations/
        */
        //First solution fits the backtracking template above.
        public List<IList<int>> keeper2 = new();
        public IList<IList<int>> Permute(int[] nums)
        {
            List<int> keep = new();
            permutor(keep, nums);
            return keeper2;
        }
        public void permutor(List<int> keep, int[] nums)
        {
            if (keep.Count == nums.Length)
            {
                keeper2.Add(new List<int>(keep));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (keep.Contains(nums[i])) continue;
                keep.Add(nums[i]);
                permutor(keep, nums);
                keep.Remove(nums[i]);
            }
        }

        public IList<IList<int>> PermuteNeet(int[] nums)
        {
            var result = new List<IList<int>>();
            PermuteRecurse(result, nums, 0);
            return result;
        }

        private void PermuteRecurse(List<IList<int>> res, int[] arr, int start)
        {
            if (start == arr.Length)
            {
                var list = arr.Select(t => (t)).ToList();
                res.Add(list);
                return;
            }

            for (var i = start; i < arr.Length; i++)
            {
                (arr[start], arr[i]) = (arr[i], arr[start]);
                PermuteRecurse(res, arr, start + 1);
                (arr[start], arr[i]) = (arr[i], arr[start]);
            }
        }
        #endregion
        #region Subsets II
        /*
        Given an integer array nums that may contain duplicates, return all possible
        subsets
        (the power set).

        The solution set must not contain duplicate subsets. Return the solution in any order.

        Example 1:

        Input: nums = [1,2,2]
        Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]

        Example 2:

        Input: nums = [0]
        Output: [[],[0]]

        Constraints:

            1 <= nums.length <= 10
            -10 <= nums[i] <= 10

        */
        //T: O(N*2^N)
        public IList<IList<int>> SubsetsWithDupNeet(int[] nums)
        {
            var list = new List<IList<int>>();
            Array.Sort(nums);
            backTrack(list, new List<int>(), nums, 0);
            return list;
        }

        private void backTrack(List<IList<int>> list, List<int> curr, int[] nums, int start)
        {
            list.Add(new List<int>(curr));
            for (var i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) continue;
                curr.Add(nums[i]);
                backTrack(list, curr, nums, i + 1);
                curr.RemoveAt(curr.Count - 1);
            }
        }
        #endregion
        #region Combination Sum II
        /*
        Given a collection of candidate numbers (candidates) and a target number (target), 
        find all unique combinations in candidates where the candidate numbers sum to target.
        Each number in candidates may only be used once in the combination.
        Note: The solution set must not contain duplicate combinations.

        
        Example 1:
        Input: candidates = [10,1,2,7,6,1,5], target = 8
        Output: 
        [
        [1,1,6],
        [1,2,5],
        [1,7],
        [2,6]
        ]

        Example 2:
        Input: candidates = [2,5,2,1,2], target = 5
        Output: 
        [
        [1,2,2],
        [5]
        ]

        Constraints:

            1 <= candidates.length <= 100
            1 <= candidates[i] <= 50
            1 <= target <= 30

        https://leetcode.com/problems/combination-sum-ii/   
        */
        List<IList<int>> keeper4 = new();
        int ttarget2;
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            ttarget2 = target;
            List<int> keep = new();
            Array.Sort(candidates);
            csum2(0, keep, candidates);

            return keeper4;
        }
        public void csum2(int index, List<int> keep, int[] candidates)
        {
            int total = keep.Sum();
            if (total > ttarget2 || index > candidates.Length)
                return;

            if (total == ttarget2)
            {
                keeper4.Add(new List<int>(keep));
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                if (i > index && candidates[i] == candidates[i - 1]) continue;

                keep.Add(candidates[i]);
                csum2(i + 1, keep, candidates);
                keep.Remove(candidates[i]);

            }
        }
        #endregion
        #region Word Search
        /*
        Given an m x n grid of characters board and a string word, return true if word exists in the grid.
        The word can be constructed from letters of sequentially adjacent cells, 
        where adjacent cells are horizontally or vertically neighboring. 
        The same letter cell may not be used more than once.

        Example 1:
        Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
        Output: true

        Example 2:
        Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
        Output: true

        Example 3:
        Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
        Output: false

        Constraints:

            m == board.length
            n = board[i].length
            1 <= m, n <= 6
            1 <= word.length <= 15
            board and word consists of only lowercase and uppercase English letters.

        Follow up: Could you use search pruning to make your solution faster with a larger board?

        https://leetcode.com/problems/word-search/
        */

        private int ROWS, COLS;

        public bool ExistBackTracking(char[][] board, string word)
        {
            ROWS = board.Length;
            COLS = board[0].Length;

            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    if (Dfs(board, word, r, c, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Dfs(char[][] board, string word, int r, int c, int i)
        {
            if (i == word.Length)
            {
                return true;
            }
            if (r < 0 || c < 0 || r >= ROWS || c >= COLS ||
            board[r][c] != word[i] || board[r][c] == '#')
            {
                return false;
            }

            board[r][c] = '#';
            bool res = Dfs(board, word, r + 1, c, i + 1) ||
                       Dfs(board, word, r - 1, c, i + 1) ||
                       Dfs(board, word, r, c + 1, i + 1) ||
                       Dfs(board, word, r, c - 1, i + 1);
            board[r][c] = word[i];
            return res;
        }
        #endregion
        #region Palindrome Partitioning
        /*
        Given a string s, partition s such that every substring
        of the partition is a palindrome. Return all possible palindrome partitioning of s.

        Example 1:
        Input: s = "aab"
        Output: [["a","a","b"],["aa","b"]]

        Example 2:
        Input: s = "a"
        Output: [["a"]]

        Constraints:

            1 <= s.length <= 16
            s contains only lowercase English letters.
            
        https://leetcode.com/problems/palindrome-partitioning/
        Extra Test Cases:
        "abbab"  12 / 32 testcases passed
        "cbbbcc" 14 / 32 testcases passed
        */
        public IList<IList<string>> Partition(string s)
        {
            List<IList<string>> results = new();
            List<string> result = new();
            dfs(0);
            void dfs(int i)
            {
                if (i >= s.Length)
                {
                    results.Add(result.ToList());
                    return;
                }

                for (int j = i; j < s.Length; j++)
                {
                    if (palindrome(s, i, j))
                    {
                        result.Add(s.Substring(i, j - i + 1));
                        dfs(j + 1);
                        result.Remove(result.Last());
                    }
                }
            }

            bool palindrome(string word, int begin, int end)
            {
                while (begin < end)
                {
                    if (word[begin] != word[end])
                        return false;

                    begin++;
                    end--;
                }
                return true;
            }

            return results;
        }


        public IList<IList<string>> Partition2(string s)
        {
            List<IList<string>> result = new List<IList<string>>();
            List<string> part = new List<string>();
            Dfs(0, s, part, result);
            return result;
        }

        private void Dfs(int index, string word, List<string> part, List<IList<string>> res)
        {
            if (index >= word.Length)
            {
                res.Add(new List<string>(part));
                return;
            }
            for (int i = index; i < word.Length; i++)
            {
                if (IsPali(word, index, i))
                {
                    part.Add(word.Substring(index, i - index + 1));
                    Dfs(i + 1, word, part, res);
                    part.RemoveAt(part.Count - 1);
                }
            }
        }

        private bool IsPali(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
        #endregion
        #region Letter Combinations of a Phone Number
        /*
        Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. 
        Return the answer in any order.
        A mapping of digits to letters (just like on the telephone buttons) is given below. 
        Note that 1 does not map to any letters.

        
        Example 1:
        Input: digits = "23"
        Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

        Example 2:
        Input: digits = ""
        Output: []

        Example 3:
        Input: digits = "2"
        Output: ["a","b","c"]

        Constraints:
            0 <= digits.length <= 4
            digits[i] is a digit in the range ['2', '9'].

        https://leetcode.com/problems/letter-combinations-of-a-phone-number/
        */
        //Keeping this solution in because it fits the other backtracking questions solution style.
        public IList<string> LetterCombinations(string digits)
        {
            var lettersMap = new Dictionary<char, string>
            {
                {'2', "abc"},
                {'3', "def"},
                {'4', "ghi"},
                {'5', "jkl"},
                {'6', "mno"},
                {'7', "pqrs"},
                {'8', "tuv"},
                {'9', "wxyz"}
            };

            var result = new List<string>();

            if (!string.IsNullOrEmpty(digits))
                Backtrack(result, digits, lettersMap, "", 0);

            return result;
        }

        void Backtrack(List<string> result, string digits, Dictionary<char, string> lettersMap, string curString, int start)
        {
            if (curString.Length == digits.Length)
            { result.Add(curString); return; }

            foreach (var c in lettersMap[digits[start]])
            {
                Backtrack(result, digits, lettersMap, curString + c, start + 1);
            }
        }
        #endregion
        #region N-Queens
        /*
        Difference between this and N-Queens II is the return type.
        This returns a board which we create, other one just returns the viable solution number.
        
        The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
        Given an integer n, return all distinct solutions to the n-queens puzzle. You may return the answer in any order.
        Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space, respectively.

        Example 1:
        Input: n = 4
        Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
        Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above

        Example 2:
        Input: n = 1
        Output: [["Q"]]
        Constraints:

            1 <= n <= 9
            
        https://leetcode.com/problems/n-queens/
        */
        List<IList<string>> results = new();
        public IList<IList<string>> SolveNQueens(int n)
        {
            List<StringBuilder> result = new();
            for (int i = 0; i < n; i++)
            {
                result.Add(new StringBuilder(n));
                result[i].Append('.', n);
            }
            searcher(0, n, new HashSet<(int i, int j)>(), new HashSet<int>(), new HashSet<int>());
            void searcher(int r, int n, HashSet<(int i, int j)> col, HashSet<int> posdiag, HashSet<int> negdiag)
            {
                if (n == 0)
                {
                    results.Add(result.Select(x => x.ToString()).ToList());
                    return;
                }
                if (r == result.Count)
                    return;

                for (int c = 0; c < result.Count; c++)
                {
                    (int i, int j) column = (0, c);
                    int diag1 = (r - c);//Closing a diagonal spot for negative side.
                    int diag2 = (r + c);//Closing a diagonal spot for positive side.
                    //https://www.youtube.com/watch?v=Ph95IHmRp5M in this video these sides are shown.
                    
                    if (col.Contains(column) || posdiag.Contains(diag2) || negdiag.Contains(diag1))
                        continue;

                    col.Add(column);
                    posdiag.Add(diag2);
                    negdiag.Add(diag1);
                    result[r][c] = 'Q';
                    searcher(r + 1, n - 1, col, posdiag, negdiag);
                    col.Remove(column);
                    posdiag.Remove(diag2);
                    negdiag.Remove(diag1);
                    result[r][c] = '.';
                }
            }
            return results;
        }
        #endregion
    }
}