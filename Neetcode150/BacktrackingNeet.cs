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
            repeater(0, nums, keep);
            return keeper;
        }

        public List<int> repeater(int index, int[] nums, List<int> keep)
        {
            for (int i = index; i < nums.Length; i++)
            {
                keep.Add(nums[i]);
                repeater(i + 1, nums, keep);
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

        https://leetcode.com/problems/combination-sum/
        */
        IList<IList<int>> result2 = new List<IList<int>>();
        public void backtrack(int index, List<int> path, int total, int[] candidates, int target)
        {
            if (total == target)
            {
                result2.Add(path.ToList());
                return;
            }

            if (total > target || index >= candidates.Length) return;

            path.Add(candidates[index]);
            backtrack(index,
                      path,
                      total + candidates[index],
                      candidates,
                      target);

            path.Remove(path.Last());

            backtrack(index + 1,
                      path,
                      total,
                      candidates,
                      target);

        }
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            backtrack(0, new List<int>(), 0, candidates, target);
            return result2;
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
        //Adapted solution from TriesNeet Word Search II.
        //run time: 246 ms beats 87.00% memory:42.7mb beats 27.5%
        public class Node
        {
            public Node[] next = new Node['z' + 1];
            public string Word;
        }
        public bool Exist(char[][] board, string word)
        {
            Node root = new Node();

            Node temp = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                if (temp.next[ch] == null)
                {
                    temp.next[ch] = new Node();
                }
                temp = temp.next[ch];
            }
            temp.Word = word;

            int rl = board.Length;
            int cl = board[0].Length;
            bool result = false;
            for (int i = 0; i < rl; i++)
            {
                Node seek = root;
                for (int j = 0; j < cl; j++)
                {
                    if (result == true)
                        break;

                    searcher(i, j, seek);
                }
            }

            void searcher(int r, int c, Node curr)
            {
                if (r < 0 || c < 0 || r == rl || c == cl)
                    return;

                char tch = board[r][c];
                if (curr.next[tch] == null || board[r][c] == '/')
                    return;

                curr = curr.next[tch];
                if (curr.Word != null && curr.Word == word)
                {
                    result = true;
                    return;
                }
                board[r][c] = '/';
                searcher(r - 1, c, curr);
                searcher(r + 1, c, curr);
                searcher(r, c - 1, curr);
                searcher(r, c + 1, curr);
                board[r][c] = tch;

            }
            return result;
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

    }
}